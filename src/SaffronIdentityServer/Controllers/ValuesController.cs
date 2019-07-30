using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaffronIdentityServer.Database.Models;

namespace SaffronIdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private CoreContext _ctx;
        private IUserStore<User> _userStore;
        private IdentityErrorDescriber _errorDescriber;

        public ValuesController(CoreContext ctx, IdentityErrorDescriber errorDescriber, IUserStore<User> userStore)
        {
            _errorDescriber = errorDescriber;
            _userStore = userStore; // new UserStore<User>(ctx);
            _ctx = ctx;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
