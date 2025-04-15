using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleEventBus;

namespace assignment_2_2
{
    public class NewsDomain
    {
        public string date { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public NewsDomain(string date, string title, string content)
        {
            this.date = date;
            this.title = title;
            this.content = content;
        }

    }
}
