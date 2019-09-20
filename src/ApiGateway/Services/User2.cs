using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGateway.Services
{
    public class User2:IUser
    {
        public void Hello()
        {
            Console.WriteLine("user2 hello");
        }
    }
}
