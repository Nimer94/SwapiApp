using SwapiApp.Models;
using SwapiApp.Repository;
using SwapiApp.Services;

namespace SwapiApp.GraphQL
{
    public class Query
    {
        private readonly IClientService _service;
        private readonly IClientRepository _repo;
        public Query(IClientService service, IClientRepository repo)
        {
            _service = service;
            _repo = repo;
        }
        public async Task<Person> Person(int id)
        {
            var person = await _service.GetPersonFromApiById(id);
            // Upadte the DB and return the object
            if (person != null)
            {
                var doesxist = await _repo.DoesExist(id);
                if (doesxist)
                {
                    person.Id = id;
                    person = await _repo.Update(person);
                }
                else
                {
                    person.Id = id;
                    person = await _repo.Add(person);
                }
            }
            return person;
        }
    }
}
