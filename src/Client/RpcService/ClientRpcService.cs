using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;

namespace Client.RpcService
{
    public class RpcService : ClientRpcService.ClientRpcServiceBase
    {
        public override Task<ClientReply> GetClientInfo(ClientRpcRequest request, ServerCallContext context)
        {
            var header = new Header()
            {
                Success = true,
                Description = $"Reply From Client:{request.Id}"
            };
            return Task.FromResult(new ClientReply() { Header = header });
        }
    }
}
