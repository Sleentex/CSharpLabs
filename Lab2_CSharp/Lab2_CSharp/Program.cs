using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Створити 2 об'єкти типу Team з однаковими даними та перевірити, що посилання на об'єкти різні, а об'єкти рівні, вивести значення хеш-кодів для об'єктів.\n");
            Team team1 = new Team();
            Team team2 = new Team();
            Console.WriteLine(team1 == team2);
            Console.WriteLine(team1 as object == team2 as object);
            Console.WriteLine("Хеш-коди: \n\tteam1: " + team1.GetHashCode().ToString() + "\n\tteam2: " + team2.GetHashCode().ToString());


            Console.WriteLine("\n\n\n2. В блоці try/catch присвоїти властивості з номером реєстрації некоректне з-ня, а в обробнику виключних ситуацій вивести повідомлення про помилку.\n");
            team1.RegisterNumberTeam = 0;


            Console.WriteLine("\n\n\n3. Створити об'єкт типу ResearchTeam, додати елементи в список публікацій та список учасників пректу та вивести дані об'єкту ResearchTeam. \n");
            ResearchTeam researchTeam = new ResearchTeam("Research_Sleentex", "Team_NewSleentex", 1, TimeFrame.LONG);
            Person[] workers = new Person[]
            {
                new Person( "Pasha", "Lalader", new DateTime(1965, 5, 1, 8, 30, 52)),
                new Person( "Valera", "Trupca", new DateTime(1976, 5, 1, 8, 30, 52)),
                new Person( "Vasea", "Tulpanocich", new DateTime(1983, 5, 1, 8, 30, 52)),
                new Person( "Mikea", "Policia", new DateTime(1990, 5, 1, 8, 30, 52)),
                new Person( "Adam", "Britney", new DateTime(1999, 5, 1, 8, 30, 52)),
            };

            Paper[] publications = new Paper[]
            {
                new Paper("First pub", workers[0], new DateTime(1965, 5, 1, 8, 30, 52)),
                new Paper("Second pub", workers[1], DateTime.Now)
            };

            researchTeam.AddPersons(workers);
            researchTeam.AddPapers(publications);
            Console.WriteLine("\n" + researchTeam.ToString());


            Console.WriteLine("\n\n\n4. Вивести значення властивості Team для об'єкту Research Team.\n");
            Console.WriteLine(researchTeam.Team.ToString());


            Console.WriteLine("\n\n\n5. За допомогою метода DeepCopy() створити повну копію об'єкта ResearchTeam. Змінити дані у вихідному об'єкті ResearchTeam та вивести копію та оригінал, копія повинна залишатися без змін \n");
            ResearchTeam researchTeamCopy = new ResearchTeam();
            researchTeamCopy = researchTeam.DeepCopy() as ResearchTeam;

            researchTeam.Name = "New Name";
            researchTeam.OrganizationNameTeam = "New Organ Team";

            Console.WriteLine("ResearchTeam: \n" + researchTeam + "\n");
            Console.WriteLine("ResearchTeamCopy: \n" + researchTeamCopy + "\n");


            Console.WriteLine("\n\n\n6. За допомогою оператора foreach для ітератора, визначеного в класі ResearchTeam, вивести список учасників проекту, які не мають публікації \n");
            foreach (Person person in researchTeam.GetPersonEnumerator())
                Console.WriteLine(person);

            Console.WriteLine("\n\n\n7. За допомогою оператора foreach для ітератора з параметром, визначеного в класі ResearchTeam, вивести список всіх публікаций за останні 2 роки. \n");
            foreach (Paper paper in researchTeam.GetPublicationsEnumerator(2))
                Console.WriteLine(paper);

            Console.ReadLine();
        }
    }
}
