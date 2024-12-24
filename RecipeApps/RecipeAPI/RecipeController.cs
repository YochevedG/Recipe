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
    }
}
