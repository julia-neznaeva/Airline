using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPort.Passengers
{
    
    static class NameHelper
    {
        private static string[] _firstNames = { "Sophia", "Emma", "Olivia", "Ava", "Isabella", "Mia", "Zoe", "Lily", "Emily", "Madelyn", "Madison", "Chloe", "Charlotte", "Aubrey", "Avery", "Abigail", "Kaylee", "Layla", "Harper", "Ella", "Amelia", "Arianna", "Riley", "Aria", "Hailey", "Hannah", "Aaliyah", "Evelyn", "Addison", "Mackenzie", "Adalyn", "Ellie", "Brooklyn", "Nora", "Scarlett", "Grace", "Anna", "Isabelle", "Natalie", "Kaitlyn", "Lillian", "Sarah", "Audrey", "Elizabeth", "Leah", "Annabelle", "Kylie", "Mila", "Claire", "Victoria", "Maya", "Lila", "Elena", "Lucy", "Savannah", "Gabriella", "Callie", "Alaina", "Sophie", "Makayla", "Kennedy", "Sadie", "Skyler", "Allison", "Caroline", "Charlie", "Penelope", "Alyssa", "Peyton", "Samantha", "Liliana", "Bailey", "Maria", "Reagan", "Violet", "Eliana", "Adeline", "Eva", "Stella", "Keira", "Katherine", "Vivian", "Alice", "Alexandra", "Camilla", "Kayla", "Alexis", "Sydney", "Kaelyn", "Jasmine", "Julia", "Cora", "Lauren", "Piper", "Gianna", "Paisley", "Bella", "London", "Clara", "Cadence", "Jackson", "Aiden", "Liam", "Lucas", "Noah", "Mason", "Ethan", "Caden", "Jacob", "Logan", "Jayden", "Elijah", "Jack", "Luke", "Michael", "Benjamin", "Alexander", "James", "Jayce", "Caleb", "Connor", "William", "Carter", "Ryan", "Oliver", "Matthew", "Daniel", "Gabriel", "Henry", "Owen", "Grayson", "Dylan", "Landon", "Isaac", "Nicholas", "Wyatt", "Nathan", "Andrew", "Cameron", "Dominic", "Joshua", "Eli", "Sebastian", "Hunter", "Brayden", "David", "Samuel", "Evan", "Gavin", "Christian", "Max", "Anthony", "Joseph", "Julian", "John", "Colton", "Levi", "Muhammad", "Isaiah", "Aaron", "Tyler", "Charlie", "Adam", "Parker", "Austin", "Thomas", "Zachary", "Nolan", "Alex", "Ian", "Jonathan", "Christopher", "Cooper", "Hudson", "Miles", "Adrian", "Leo", "Blake", "Lincoln", "Jordan", "Tristan", "Jason", "Josiah", "Xavier", "Camden", "Chase", "Declan", "Carson", "Colin", "Brody", "Asher", "Jeremiah", "Micah", "Easton", "Xander", "Ryder", "Nathaniel", "Elliot", "Sean", "Cole" };



        private static string[] _lastName = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", "Martinez", "Robinson", "Clark", "Rodriguez", "Lewis", "Lee", "Walker", "Hall", "Allen", "Young", "Hernandez", "King", "Wright", "Lopez", "Hill", "Scott", "Green", "Adams", "Baker", "Gonzalez", "Nelson", "Carter", "Mitchell", "Perez", "Roberts", "Turner", "Phillips", "Campbell", "Parker", "Evans", "Edwards", "Collins", "Stewart", "Sanchez", "Morris", "Rogers", "Reed", "Cook", "Morgan", "Bell", "Murphy", "Bailey", "Rivera", "Cooper", "Richardson", "Cox", "Howard", "Ward", "Torres", "Peterson", "Gray", "Ramirez", "James", "Watson", "Brooks", "Kelly", "Sanders", "Price", "Bennett", "Wood", "Barnes", "Ross", "Henderson", "Coleman", "Jenkins", "Perry", "Powell", "Long", "Patterson", "Hughes", "Flores", "Washington", "Butler", "Simmons", "Foster", "Gonzales", "Bryant", "Alexander", "Russell", "Griffin", "Diaz", "Hayes" };

        private static Random _random = new Random(System.Environment.TickCount);

        internal static string GetLastName()
        {
            return _lastName[_random.Next(0, _lastName.Length)];
        }

        internal static string GetFirstName(Sex sex)
        {
            if (sex == Sex.Female) { return _firstNames[_random.Next(0, 100)]; }
            else { return _firstNames[_random.Next(100, _firstNames.Length)]; }


        }
    }


}
