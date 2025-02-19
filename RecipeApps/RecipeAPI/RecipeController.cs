using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        [HttpGet]
        public List<BizRecipe> get()
        {
            return new BizRecipe().GetList();
        }


        [HttpGet("getbyrecipe/{recipeid:int:min(1)}")]
        public BizRecipe Get(int recipeid)
        {
            BizRecipe r = new BizRecipe();
            r.Load(recipeid);
            return r;
        }

        [HttpGet("getbyName/{cookbookname}")]
        public List<BizRecipe> GetRecipesbyCookbook(string cookbookname)
        {
            return new BizRecipe().Search(cookbookname);
        }


        [HttpGet("getbycuisine/{cuisineid:int:min(1)}")]
        public List<BizRecipe> GetByCuisine(int cuisineid)
        {
            return new BizRecipe().SearchRecipes(cuisineid, "", "");
        }

        [HttpPost]
        //public IActionResult Post(BizRecipe recipe)
        //{
        //    try
        //    {
        //        recipe.Save();
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { ex.Message });
        //    }

        public IActionResult Post(BizRecipe recipe)
        {
            try
            {
                recipe.Save();
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                recipe.ErrorMessage = ex.Message;
                return BadRequest(recipe);
            }

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            BizRecipe p = new();
            try
            {
                p.Delete(id);
                return Ok(p);
            }
            catch (Exception ex)
            {
                p.ErrorMessage = ex.Message;
                return BadRequest(p);
            }
        }

        [HttpGet("users")]
        public List<BizUsers> GetUsers()
        {
            return new BizUsers().GetList();
        }

        [HttpGet("cuisine")]
        public List<BizCuisine> GetCuisine()
        {
            return new BizCuisine().GetList();
        }
    }
}
