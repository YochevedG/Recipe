using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeSystem;

namespace RecipeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookbookController : ControllerBase
    {
        [HttpGet]
        public List<BizCookbook> get()
        {
            return new BizCookbook().GetList();
        }


        [HttpGet("getbycookbook/{cookbookid:int:min(1)}")]
        public BizCookbook Get(int cookbookid)
        {
            BizCookbook c = new BizCookbook();
            c.Load(cookbookid);
            return c;
        }
    }
}
