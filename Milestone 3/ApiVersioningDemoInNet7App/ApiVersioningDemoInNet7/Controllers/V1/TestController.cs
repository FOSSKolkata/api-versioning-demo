using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningDemoInNet7.Controllers.V1
{
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
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
