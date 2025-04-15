using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AnnotationsEventBus;

namespace assignment_2_2_3
{
    public class Culture : NewsDomain
    {
        public Culture(string date, string title, string content) : base(date, title, content) { }
    }
}
