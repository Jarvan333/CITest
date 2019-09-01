using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
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
            //var headers = new Metadata {{"Authorization", $"Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IjMzQjAyOTNENEQxRDFFQTI1NUI5MjY0MDM5M0FFN0U3NDVDMTEyRTIiLCJ0eXAiOiJKV1QiLCJ4NXQiOiJNN0FwUFUwZEhxSlZ1U1pBT1RybjUwWEJFdUkifQ.eyJuYmYiOjE1NjcxNzI3NjEsImV4cCI6MTU2NzE3NjM2MSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDoxMDAwMiIsImF1ZCI6WyJodHRwOi8vbG9jYWxob3N0OjEwMDAyL3Jlc291cmNlcyIsImFwaS5pZGVudGl0eSIsImFwaS5iYXNpYyJdLCJjbGllbnRfaWQiOiJ3ZWIuYmFja2dyb3VuZCIsInN1YiI6ImM3Y2M5YWVhLTFjNzItNDk2Yi1iYTMyLTU5MWMzOTAyMTA4OSIsImF1dGhfdGltZSI6MTU2NzE3Mjc1OSwiaWRwIjoibG9jYWwiLCJuYW1lIjoiYWRtaW4iLCJzY29wZSI6WyJvcGVuaWQiLCJwcm9maWxlIiwiYXBpLmlkZW50aXR5IiwiYXBpLmJhc2ljIl0sImFtciI6WyJwd2QiXX0.rOfzi7lLz9jx-Qh_rZZePfJj6sHzG9cgca4Lns_rg4AiaOPlMUeFU9AtBJd5yQUxhgURCNJ1WiTruEdfoZa8MKTEmqgyxc54cT2a8g2Qh7q_c3voiGzhuS9oC6o008XQ00FN_XIkqzTNBstymH8xlCkdxQshtArJ9pYVWOcdJZHVFY5s1CbnyUGu4sJic99QkXPuZJGhZ8s-gYr1pMhyBAkepLjRu-WRNh-u5DHIHWjaQW3hkRQ4hoVF7odt2X462IPXEgYj3cTa-KFWv_euIRdXujMoyHYoRPOGYALJRBsxPEQjS_xt9dh_QIywUz6AU1yOTSmlk_u7VmUrXU4EqQ" }};
            //ChannelOptions options=ChannelOptions.;
            //Channel channel = new Channel("localhost:10000", ChannelCredentials.Insecure, new[]{
            //    new ChannelOption(ChannelOptions.MaxSendMessageLength , 2*1024*1024),
            //    new ChannelOption(ChannelOptions.MaxReceiveMessageLength , 5 *1024*1024)
            //});
            //var client = new ServerRpcService.ServerRpcServiceClient(channel);
            //var reply = client.GetServerInfo(new ServerRpcRequest { Id = id });
            //channel.ShutdownAsync().Wait();

            var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:10000") };
            var client = GrpcClient.Create<ServerRpcService.ServerRpcServiceClient>(httpClient);
            var reply = client.GetServerInfo(new ServerRpcRequest { Id = id });
            return JsonConvert.SerializeObject(reply);
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
