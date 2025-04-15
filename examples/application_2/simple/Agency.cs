using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleEventBus;

namespace assignment_2_2
{
    public class Agency
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public Agency(string Name, string Location)
        {
            this.Name = Name;
            this.Location = Location;
        }
        public void PublishNews(NewsDomain news)
        {
            Console.WriteLine($"\n!ALERT! {Name} a publicat o stire noua in {news.GetType().Name}: {news.title}");

            if (news is Sports sportsNews)
            {
                BasicEventBus.Instance.Publish(new SportsEvent(sportsNews));
            }
            else if (news is Culture cultureNews)
            {
                BasicEventBus.Instance.Publish(new CultureEvent(cultureNews));
            }
            else if (news is Politics politicsNews)
            {
                BasicEventBus.Instance.Publish(new PoliticsEvent(politicsNews));
            }
        }
    }
}
