using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializePeople
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("John Doe", DateTime.Parse("1996.08.10"), Gender.MALE);
            person.Serialize(@"C:\Users\DELL\serialization_csharp_mathon-szabo\Test.bin");
            Person per = Person.Deserialize();
            Console.WriteLine(per.ToString());
        }
    }
}
