using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningDemoInNet7.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        
        [HttpGet, Route("testmethod")]
        public string TestMethod()
        {
            return "Test method call successful";
        }
    }
}
