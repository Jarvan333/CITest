using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcService1
{
    public class RpcService :ServerRpcService.ServerRpcServiceBase
    {
        private readonly ILogger<RpcService> _logger;
        public RpcService(ILogger<RpcService> logger)
        {
            _logger = logger;
        }

        public override Task<ServerReply> GetServerInfo(ServerRpcRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ServerReply
            {
                Header=new Header
                {
                    Description="yeah"+request.Id
                }
            });
        }
    }
}
