using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Builder;
using Server.Services.Interfaces;

namespace Server.RpcService
{
    public class RpcService : ServerRpcService.ServerRpcServiceBase
    {
        private readonly IUserService _userService;

        public RpcService(IUserService userService)
        {
            _userService = userService;
        }
        public override Task<ServerReply> GetServerInfo(ServerRpcRequest request, ServerCallContext context)
        {
            var info = new ServerInfo
            {
                Name = _userService.GetName(request.Id),
                Info =
                {
                    new CpuInfo()
                    {
                        Count = 8
                    }
                }
            };
            List<string> list = new List<string>() { "aa", "bb" };
            Header header=new Header()
            {
                Success = true,
                Description = $"Reply From Server:{request.Id}"
            };
            return Task.FromResult(new ServerReply() { Header = header, Data = info });
        }
    }
}
