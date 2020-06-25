using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using SerializePeople;
using Assert = NUnit.Framework.Assert;

namespace SerializePeopleTests
{
    [TestClass]
    public class SerializePeopleTest
    {
        
        [TestMethod]
        public void ToString_ShouldReturnPropertyValues()
        {
            //Arrange
            Person person = new Person("John Doe", DateTime.Parse("1996.08.10"), Gender.MALE);
            string expected = "Person: [Name: John Doe, birth: 10/08/1996, gender: MALE, age23.]";

            //Act
            string actual = person.ToString();

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Serialize_GivenStringTest_ShouldWriteStringIntoFile()
        {
            //Arrange
            Person person = new Person("John Doe", DateTime.Parse("1996.08.10"), Gender.MALE);
            string expected = "Person: [Name: John Doe, birth: 10/08/1996, gender: MALE, age23.]";

            //Act
            person.Serialize(person.ToString());
            FileStream fs = new FileStream(@"C:\Users\DELL\serialization_csharp_mathon-szabo\Test.txt",
                FileMode.Open, FileAccess.Read);
            string actual = (string)new BinaryFormatter().Deserialize(fs);

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
