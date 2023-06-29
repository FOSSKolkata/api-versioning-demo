using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;

namespace ApiVersioningDemoInNet7.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [MapToApiVersion("1.0")]
        [HttpGet, Route("testmethod")]
        public string TestMethod()
        {
            return "Test method call successful";
        }

        [MapToApiVersion("2.0")]
        [HttpGet, Route("testmethod")]
        public string TestMethod2()
        {
            return "Test method V2 call successful";
        }
    }
}
