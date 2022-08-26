using Moq;
using SwapiApp.Models;
using SwapiApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SwapiApp.Test
{
    public class ClientServiceTests
    {
        public static IEnumerable<object[]> PersonData => new List<Person[]>
        {
            new Person[] {new Person
            {
                BirthYear = "1990",
                EyeColor = "Blue",
                Name ="James",
                Id = 1
            }},
            new Person[] {new Person
            {
                BirthYear = "1990",
                EyeColor = "Blue",
                Name ="James",
                Id = 2
            }},
            new Person[] {new Person
            {
                BirthYear = "1990",
                EyeColor = "Blue",
                Name ="James",
                Id = 3
            }},
            new Person[] {new Person
            {
                BirthYear = "1990",
                EyeColor = "Blue",
                Name ="James",
                Id = 4
            }},
        }.ToArray();

        [Theory]
        [MemberData(nameof(PersonData))]
        public async void Test_GetPersonFromApiById(Person person)
        {
            //Arrange
            var mockedService = new Mock<IClientService>();

            mockedService.Setup(t => t.GetPersonFromApiById(person.Id)).Returns(async () => await Task<Person>.FromResult(person));

            var service = mockedService.Object;

            //Act
            var result = await service.GetPersonFromApiById(person.Id);

            //Assert
            Assert.NotNull(result);
        }
    }
}
