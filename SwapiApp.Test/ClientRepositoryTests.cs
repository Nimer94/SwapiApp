using Newtonsoft.Json;
using SwapiApp.Models;
using SwapiApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Priority;

namespace SwapiApp.Test
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class ClientRepositoryTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture fixture;

        public ClientRepositoryTests(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact, Priority(1)]
        public async void Test_AddPerson()
        {
            //Arrange
            var jsonData = System.IO.File.ReadAllText("MockData/luke.json");
            var person = JsonConvert.DeserializeObject<Person>(jsonData);

            var _repo = new ClientRepository(this.fixture.ContextFactory);

            //Act
            var result = await _repo.Add(person);
            var objectsCount = _repo.Count();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(person.Id, result.Id);
            Assert.Equal(1, objectsCount);
        }

        [Fact, Priority(2)]
        public async void Test_UpdatePerson()
        {
            //Arrange
            var jsonData = System.IO.File.ReadAllText("MockData/luke.json");
            var person = JsonConvert.DeserializeObject<Person>(jsonData);
            person.Name = "Test";

            var _repo = new ClientRepository(this.fixture.ContextFactory);
            //Act
            var result = await _repo.Update(person);
            var objectsCount = _repo.Count();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(person.Id, result.Id);
            Assert.Equal("Test", result.Name);
            Assert.Equal(1, objectsCount);
        }

        [Fact, Priority(3)]
        public async void Test_GetPerson()
        {
            //Arrange
            var jsonData = System.IO.File.ReadAllText("MockData/luke.json");
            var person = JsonConvert.DeserializeObject<Person>(jsonData);

            var _repo = new ClientRepository(this.fixture.ContextFactory);

            //Act
            var result = await _repo.GetByID(person.Id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(person.Id, result.Id);
        }
    }
}
