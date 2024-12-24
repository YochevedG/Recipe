using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        [HttpGet]
        public List<BizMeal> get()
        {
            return new BizMeal().GetList();
        }


        [HttpGet("getbymeal/{mealid:int:min(1)}")]
        public BizMeal Get(int mealid)
        {
            BizMeal m = new BizMeal();
            m.Load(mealid);
            return m;
        }
    }
}
