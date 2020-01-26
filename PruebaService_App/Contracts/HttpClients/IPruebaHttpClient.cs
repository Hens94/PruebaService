using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PruebaService_App.Contracts.HttpClients
{
    public interface IPruebaHttpClient
    {
        Task<(string, HttpStatusCode)> GetPeople();
    }
}
