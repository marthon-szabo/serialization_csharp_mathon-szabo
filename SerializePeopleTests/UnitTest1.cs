using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializePeople;

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
    }
}
