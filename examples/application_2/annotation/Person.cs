using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AnnotationsEventBus;

namespace assignment_2_2_3
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

        [EventHandler(typeof(SportsEvent))]
        public void onSportEvent(SportsEvent e)
        {
            Console.WriteLine($"{Name} a primit o notificare (Sports): {e.News.title}");
        }
        [EventHandler(typeof(CultureEvent))]
        public void onCultureEvent(CultureEvent e)
        {
            Console.WriteLine($"{Name} a primit o notificare (Culture): {e.News.title}");
        }
        [EventHandler(typeof(PoliticsEvent))]
        public void onPoliticsEvent(PoliticsEvent e)
        {
            Console.WriteLine($"{Name} a primit o notificare (Politics): {e.News.title}");
        }
    }
}
