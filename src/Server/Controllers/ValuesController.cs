using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Server.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() {
            return new string[] { "value1", $"value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id) {
            //Channel channel = new Channel("127.0.0.1:10002", ChannelCredentials.Insecure, new[]{
            //    new ChannelOption(ChannelOptions.MaxSendMessageLength , 2*1024*1024),
            //    new ChannelOption(ChannelOptions.MaxReceiveMessageLength , 5 *1024*1024)
            //});
            //var client = new ClientRpcService.ClientRpcServiceClient(channel);
            //var reply = client.GetClientInfo(new ClientRpcRequest { Id = id });
            //channel.ShutdownAsync().Wait();

            var httpClient = new HttpClient {BaseAddress = new Uri("https://localhost:10002")};
            var client = GrpcClient.Create<ClientRpcService.ClientRpcServiceClient>(httpClient);
            var reply = client.GetClientInfo(new ClientRpcRequest { Id = id });
            return JsonConvert.SerializeObject(reply);
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
