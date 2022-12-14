using Microsoft.EntityFrameworkCore;
using SwapiApp.Data;
using SwapiApp.Models;

namespace SwapiApp.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _db;

        public ClientRepository(IDbContextFactory<DataContext> db)
        {
            _db = db.CreateDbContext();
        }

        public async Task<Person> Add(Person person)
        {
            await _db.People.AddAsync(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task<Person> GetByID(int id)
        {
            return await _db.People.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> DoesExist(int id)
        {
            bool isexist = false;
            var result = await _db.People.FirstOrDefaultAsync(p => p.Id == id);
            if (result != null)
            {
                isexist = true;
            }
            return isexist;
        }

        public int Count()
        {
            return _db.People.Count();
        }

        public async Task<Person> Update(Person person)
        {
            //_db.Entry(person).State = EntityState.Modified;
            var result = await _db.People.FirstOrDefaultAsync(p => p.Id == person.Id);
            result.Name = person.Name;
            result.Mass = person.Mass;
            result.Edited = person.Edited;
            result.BirthYear = person.BirthYear;
            result.Url = person.Url;
            result.EyeColor = person.EyeColor;
            result.Height = person.Height;
            result.HomeworId = person.HomeworId;
            result.HairColor = person.HairColor;
            result.Vehicles = person.Vehicles;
            result.Created = person.Created;
            result.Films = person.Films;
            result.Gender = person.Gender;
            result.SkinColor = person.SkinColor;
            await _db.SaveChangesAsync();
            return result;
        }
    }
}
