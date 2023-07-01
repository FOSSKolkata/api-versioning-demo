using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningDemoInNet7.Controllers
{
 
    [ApiVersion("2.0")]
    [Route("api/test")] 
    [ApiController] 
    public class Test2Controller : ControllerBase
    {
        [HttpGet, Route("testmethod")]
        public string TestMethod()
        {
            return "Test method V2 call successful";
        }

        [HttpGet, Route("unchanged")]
        public string Unchanged()
        {
            return "I remain unchanged across versions";
        }
    }
}
