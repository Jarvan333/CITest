using System;
using DotNetCore.CAP;
using Newtonsoft.Json;
using ServiceCommon;

namespace OrderService.Events
{
    public interface ICapEventsHandler
    {
        void CheckReceivedMessage(CapEvents @events);
    }
    public class CapEventsHandler: ICapEventsHandler,ICapSubscribe
    {
        [CapSubscribe("aa")]
        public void CheckReceivedMessage(CapEvents @events)
        {
            Console.WriteLine("---------------");
            Console.WriteLine(JsonConvert.SerializeObject(@events));
            Console.WriteLine("---------------");

        }
    }
}
