using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HandlerBasedEventBus;

namespace assignment_2_2_2
{
    public class Politics : NewsDomain
    {
        public Politics(string date, string title, string content) : base(date, title, content) { }
    }
}
