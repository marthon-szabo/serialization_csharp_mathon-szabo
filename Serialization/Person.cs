using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
    [Serializable]
    public class Person
    {
        protected string name;
        protected DateTime _birthDate;
        protected Gender gender;


        public Person(string name, DateTime birthDate, Gender gender)
        {
            this.name = name;
            this._birthDate = birthDate;
            this.gender = gender;

        }

        public Person()
        {
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public Gender Gender { get; }

        public DateTime BirthDate => _birthDate;

        public int Age
        {
            get
            {
                int currentAge = int.Parse(DateTime.Now.Year.ToString()) - int.Parse(_birthDate.Year.ToString());
                
                if (int.Parse(DateTime.Now.ToString("MMdd")) < int.Parse(_birthDate.ToString("MMdd")))
                {
                    currentAge--;
                }

                return currentAge;
            }

        }

        public Employee Employee { get; }

        public void Serialize(string output)
        {
            if (File.Exists(output))
            {
                File.Delete(output);
            }

            FileStream fs = new FileStream(output, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            
            bf.Serialize(fs, this);
            fs.Close();
        }

        public static Person Deserialize()
        {
            FileStream fs = new FileStream(
                @"C:\Users\DELL\serialization_csharp_mathon-szabo\Test.bin",
                FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();


            return (Person)bf.Deserialize(fs);
        }

        public override string ToString()
        {
            return $"Person: [Name: {name}, birth: {_birthDate:dd/MM/yyyy}, gender: {gender}, age{Age}.]";

        }
    }
    
}
