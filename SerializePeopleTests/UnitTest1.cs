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
        public void SerializeAndDeserialize_GivenStringOutput_ShouldWriteObjectIntoFileAndReturnIt()
        {
            //Arrange
            Person expectedPerson = new Person("John Doe", DateTime.Parse("1996.08.10"), Gender.MALE);
            string expected = expectedPerson.ToString();

            //Act
            expectedPerson.Serialize(Path.FULL_NAME);
            FileStream fs = new FileStream(Path.FULL_NAME,
                FileMode.Open, FileAccess.Read);
            Person actualPerson = (Person)new BinaryFormatter().Deserialize(fs);
            fs.Close();
            string actual = actualPerson.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
