using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Services.Interfaces;

namespace Server.Services
{
    public class UserService : IUserService
    {
        public string GetName(int id)
        {
            return $"The name is:User{id}";
        }
    }
}
