using SwapiApp.Models;

namespace SwapiApp.Services
{
    public interface IClientService
    {
        /// <summary>
        /// Get the person, identified by its ID, from the remote API service
        /// </summary>
        /// <param name="id">The ID of the desired person to be retrieved</param>
        /// <returns>The person object, if exists, NULL otherwise</returns>
        Task<Person> GetPersonFromApiById(int id);
    }
}
