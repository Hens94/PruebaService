using System.Net;
using System.Threading.Tasks;

namespace PruebaService_App.Contracts.HttpClients
{
    public interface IPruebaHttpClient
    {
        Task<(string, HttpStatusCode)> GetPeople();
        Task<(string, HttpStatusCode)> GetPlanets();
    }
}
