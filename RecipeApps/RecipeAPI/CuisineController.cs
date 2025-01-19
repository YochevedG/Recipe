using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineController : ControllerBase
    {
        [HttpGet]
        public List<BizCuisine> Get()
        {
            return new BizCuisine().GetList();
        }

        [HttpGet("{id:int:min(0)}")]
        public BizCuisine Get(int id)
        {
            BizCuisine p = new BizCuisine();
            p.Load(id);
            return p;
        }

        [HttpGet("getbycuisinetype/{cuisinetype}")]
        public List<BizCuisine> GetRecipesbyCookbook(string cuisinetype)
        {
            return new BizCuisine().Search(cuisinetype);
        }
    }
}
