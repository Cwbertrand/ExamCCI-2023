using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class PersonServiceTests
    {
        [TestMethod]
        public void GetAll_ShouldReturnListOfPersons()
        {
            // Arrange
            var mockPersonRepository = new Mock<IPersonRepository>();
            var expectedPersons = new List<Person> { new Person { Id = 1, Name = "John" }, new Person { Id = 2, Name = "Jane" } };
            mockPersonRepository.Setup(repo => repo.GetAll()).Returns(expectedPersons);

            var personService = new PersonService(mockPersonRepository.Object);

            // Act
            var result = personService.GetAll();

            // Assert
            CollectionAssert.AreEqual(expectedPersons, result);
        }

        [TestMethod]
        public void GetAll_WhenRepositoryReturnsNull_ShouldReturnEmptyList()
        {
            // Arrange
            var mockPersonRepository = new Mock<IPersonRepository>();
            mockPersonRepository.Setup(repo => repo.GetAll()).Returns((List<Person>)null);

            var personService = new PersonService(mockPersonRepository.Object);

            // Act
            var result = personService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}
