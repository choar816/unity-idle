using Microsoft.AspNetCore.Mvc;
using WebServer.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServer.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : ControllerBase
    {
        AccountService _service;

        public TestController(AccountService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("hello")]
        public TestPacketRes TestPost([FromBody] TestPacketReq value)
        {
            TestPacketRes result = new TestPacketRes();
            result.success = true;

            int id = _service.GenerateAccountId();

            return result;
        }
    }
}
