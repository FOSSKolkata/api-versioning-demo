using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningDemoInNet7.Controllers.V2
{
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet, Route("testmethod")]
        public string TestMethod()
        {
            return "Test method V2 call successful";
        }
    }
}
