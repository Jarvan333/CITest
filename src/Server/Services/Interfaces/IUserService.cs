using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services.Interfaces
{
    public interface IUserService
    {
        string GetName(int id);
    }
}
