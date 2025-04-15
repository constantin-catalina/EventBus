using System;
using AnnotationsEventBus;

namespace assignment_2_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Agency agency1 = new Agency("Global News", "New York");
            Agency agency2 = new Agency("Hot News", "London");
            Agency agency3 = new Agency("Tion", "Timisoara");

            Person person1 = new Person("Alice", "alice@gmail.com", "0731231233");
            Person person2 = new Person("Bob", "bob@gmail.com", "076543875");

            Sports sportsNews1 = new Sports("24-02-2025", "Echipa nationala castiga!", "Echipa nationala a obtinut victoria in finala.");
            Sports sportsNews2 = new Sports("01-03-2025", "Simona Halep se retrage!", "Performanta sportiva a Romaniei a decazut brusc.");
            Culture cultureNews1 = new Culture("03-03-2004", "Festivalul de arta", "Un nou festival de arta a fost anuntat.");
            Culture cultureNews2 = new Culture("05-05-2024", "Noaptea Muzeelor", "Muzeele isi deschid portile in aceasta seara pentru toata lumea.");
            Culture cultureNews3 = new Culture("08-12-2022", "Orchestra germana ajunge in Romania", "Poti sa iti rezervi un loc la spectacolul din luna august, cumparand un bilet online.");
            Politics politicsNews1 = new Politics("02-12-2023", "Alegeri anticipate", "S-a anuntat organizarea de alegeri anticipate.");

            HandlerEventBus.Instance.Subscribe<SportsEvent>(person1);
            HandlerEventBus.Instance.Subscribe<CultureEvent>(person1);
            HandlerEventBus.Instance.Subscribe<PoliticsEvent>(person1);

            HandlerEventBus.Instance.Subscribe<CultureEvent>(person2);

            agency1.PublishNews(sportsNews1);
            Thread.Sleep(2000);
            agency2.PublishNews(cultureNews1);
            Thread.Sleep(2000);
            agency3.PublishNews(sportsNews2);
            Thread.Sleep(2000);
            agency1.PublishNews(cultureNews2);
            Thread.Sleep(2000);
            agency2.PublishNews(cultureNews3);
            Thread.Sleep(2000);
            agency3.PublishNews(politicsNews1);
            Thread.Sleep(2000);

            HandlerEventBus.Instance.Unsubscribe<CultureEvent>(person1);
            Culture cultureNews4 = new Culture("10-10-2025", "Festivalul de film", "Un nou festival de film a fost anuntat.");

            agency3.PublishNews(cultureNews4);
            Thread.Sleep(2000);
            agency3.PublishNews(sportsNews2);

            Console.ReadLine();
        }
    }
}