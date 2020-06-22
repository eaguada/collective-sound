using CollectiveSound.Web.Core.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CollectiveSound.Web.Api.Controllers.Tests
{
    public class TestController : BaseController
    {
        [HttpGet("[action]")]
        public ObjectResult Get(string userNameOrEmail)
        {
            return Ok(new { TestMessage = "Test success!" });
        }
    }
}
