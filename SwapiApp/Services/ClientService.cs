using SwapiApp.Models;

namespace SwapiApp.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _client;
        public ClientService(HttpClient client)
        {
            _client = client;
        }

        public Task<Person> GetPersonFromApiById(int id) =>
            this._client.GetFromJsonAsync<Person>(id.ToString())!;
    }
}
