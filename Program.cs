using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace CISCodeTest
{
    class Program
    {
        public static StreamReader JsonFile;
        public static List<Person> PersonList = new List<Person>();

        static void Main(string[] args)
        {
            JsonFile = openFile();
            var completeString = JsonFile.ReadToEnd();
            var setting = new JsonSerializerSettings();
            setting.MissingMemberHandling = MissingMemberHandling.Error;
            PersonList = JsonConvert.DeserializeObject<List<Person>>(completeString, setting);
            PersonList = PersonList.OrderBy(s => s.age).ToList();
            PrintList(PersonList, "Total People");
            var activeMen = PersonList.Where(s => s.age > 30 && s.gender == "male" && s.eyeColor == "blue").ToList();
            PrintList(activeMen, "Active men over 30 with blue eyes");
            var lonelyPeople = PersonList.Where(s => s.friends.Count() < 3);
            Console.WriteLine($"Number of people with less than 3 friends: {lonelyPeople.Count()}");
            var quit = 'a';
            while (quit != 'q')
            {
                Console.WriteLine("Type q to quit");
                quit = (char)Console.Read();
            }
        }

        public static StreamReader openFile()
        {
            Console.WriteLine("Enter filename:");
            var fileName = Console.ReadLine();
            try
            {
                return File.OpenText(fileName);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File not found");
                return null;
            }
        }

        public static List<Person> ConvertToObject(string jsonString)
        {
            var objectList = jsonString.Split(',');
            var jsonList = objectList.Select(s => JsonConvert.DeserializeObject<Person>(s)).ToList();
            return jsonList;
        }
        
        public static void PrintList(List<Person> people, string title)
        {
            Console.WriteLine(title);
            foreach (var pers in people)
            {
                Console.WriteLine($"{pers.age} | {pers.lastName}, {pers.firstName} | {pers.eyeColor} | {pers.gender}");
            }
            Console.WriteLine($"Number of people: {people.Count}");
        }
    }
}
