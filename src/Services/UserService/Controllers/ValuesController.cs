using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ServiceCommon;

namespace UserService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        private readonly IHostingEnvironment _env;
        private readonly ICapPublisher _capPublisher;

        public ValuesController(IHostingEnvironment env,ICapPublisher capPublisher)
        {
            _env = env;
            _capPublisher = capPublisher;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() {
            _capPublisher.Publish<CapEvents>("aa",new CapEvents(){Id = Guid.NewGuid(),Name = "From user service event"});
            return new string[] { "userValue", Dns.GetHostName(), _env.EnvironmentName };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id) {
            return Program.ArgString;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
