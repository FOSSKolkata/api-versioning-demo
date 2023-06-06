using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningDemoInNet7.Controllers
{
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
