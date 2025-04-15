using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleEventBus;

namespace assignment_2_2
{
    public class Person : ISubscriber
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Person(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public void Inform(IEvent e)
        {
            if (e is SportsEvent sportsEvent)
            {
                Console.WriteLine($"{Name} a primit o notificare (Sports): {sportsEvent.News.title}");
            }
            else if (e is CultureEvent cultureEvent)
            {
                Console.WriteLine($"{Name} a primit o notificare (Culture): {cultureEvent.News.title}");
            }
            else if (e is PoliticsEvent politicsEvent)
            {
                Console.WriteLine($"{Name} a primit o notificare (Politics): {politicsEvent.News.title}");
            }
        }
    }
}
