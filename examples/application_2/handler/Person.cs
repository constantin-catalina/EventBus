using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HandlerBasedEventBus;

namespace assignment_2_2_2
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
        public void HandleSportsEvent(SportsEvent e)
        {
            Console.WriteLine($"{Name} a primit o notificare (Sports): {e.News.title}");
        }
        public void HandleCultureEvent(CultureEvent e)
        {
            Console.WriteLine($"{Name} a primit o notificare (Culture): {e.News.title}");
        }
        public void HandlePoliticsEvent(PoliticsEvent e)
        {
            Console.WriteLine($"{Name} a primit o notificare (Politics): {e.News.title}");
        }
    }
}
