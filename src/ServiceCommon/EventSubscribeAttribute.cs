using System;
using System.Collections.Generic;
using System.Text;
using DotNetCore.CAP;

namespace ServiceCommon
{
    public class EventSubscribeAttribute :CapSubscribeAttribute
    {
        public EventSubscribeAttribute(Type type) : base(type.FullName)
        {
        }
    }
}
