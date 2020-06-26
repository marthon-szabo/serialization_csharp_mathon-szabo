using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace SerializePeople
{
    [Serializable]
    public class Person : IDeserializationCallback
    {
        protected string _name;
        protected DateTime _birthDate;
        protected Gender _gender;
        
        [NonSerialized]
        protected int _age;


        public Person(string name, DateTime birthDate, Gender gender)
        {
            this._name = name;
            this._birthDate = birthDate;
            this._age = CheckAge();
            this._gender = gender;

        }

        public Person()
        {
        }

        protected Person(SerializationInfo serInfo, StreamingContext context)
        {
            if (serInfo == null) throw new ArgumentNullException();

            _name = (string)serInfo.GetValue("Name", typeof(string));
            _birthDate = (DateTime)serInfo.GetValue("Birth", typeof(DateTime));
            _gender = (Gender)serInfo.GetValue("Gender", typeof(Gender));
            _age = CheckAge();

        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Gender Gender { get; }

        public DateTime BirthDate => _birthDate;

        private int CheckAge()
        {
            int currentAge = int.Parse(DateTime.Now.Year.ToString()) - int.Parse(_birthDate.Year.ToString());

            if (int.Parse(DateTime.Now.ToString("MMdd")) < int.Parse(_birthDate.ToString("MMdd")))
            {
                currentAge--;
            }

            return currentAge;
        }

        public int Age
        {
            get
            {
                return _age;
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

            return (Person)new BinaryFormatter().Deserialize(fs);
        }

        public override string ToString()
        {
            return $"Person: [Name: {_name}, birth: {_birthDate:dd/MM/yyyy}, gender: {_gender}, age{Age}.]";

        }

        public void OnDeserialization(object sender)
        {
            _age = CheckAge();
        }

        public void GetObjectData(SerializationInfo serInfo, StreamingContext context)
        {
            serInfo.AddValue("Name", _name);
            serInfo.AddValue("Birth", _birthDate);
            serInfo.AddValue("Gender", _gender);

        }
    }
    
}
