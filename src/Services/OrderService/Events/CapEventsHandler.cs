using System;
using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using ServiceCommon;

namespace OrderService.Events
{
    public class CapEventsHandler: ICapSubscribe
    {
        [EventSubscribe(typeof(CapEvents))]
        public void CheckReceivedMessage(CapEvents events)
        {
            Console.WriteLine("---------------");
            Console.WriteLine(JsonConvert.SerializeObject(events));
            Console.WriteLine("---------------");

        }

        [EventSubscribe(typeof(Event2))]
        public void CheckReceivedMessage1(Event2 events)
        {
            Console.WriteLine("---------------");
            Console.WriteLine(JsonConvert.SerializeObject(events));
            Console.WriteLine("---------------");

        }
    }
}
