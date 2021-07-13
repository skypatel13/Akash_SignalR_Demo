using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akash_SignalR_Demo.Model
{
    public class ServerDateTime
    {
        public DateTime CurrentDateTime
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
