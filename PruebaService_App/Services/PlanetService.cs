using PruebaService_App.Contracts;
using PruebaService_App.Contracts.HttpClients;
using PruebaService_App.Extensions;
using PruebaService_App.Models.HttpClients;
using PruebaService_App.ViewModels;
using PruebaService_Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static System.ExceptionExtensions;

namespace PruebaService_App.Services
{
    public class PlanetService : IPlanet
    {
        private readonly IPruebaHttpClient _pruebaHttpClient;

        public PlanetService(IPruebaHttpClient pruebaHttpClient)
        {
            _pruebaHttpClient = pruebaHttpClient;
        }

        public async Task<IResult> GetAll() =>
            await UseCatchCustomExceptionAsync<IResult, AppException>(
                async (execError, execException) =>
                {
                    var planetsResponse = await _pruebaHttpClient.GetPlanets().GetFromJson<PeopleResponse>();

                    if (!planetsResponse.Code.Equals(0))
                    {
                        execException(new HttpClientException(message: planetsResponse.Message, resultCode: 111, statusCode: HttpStatusCode.OK));
                    }

                    return new ResultViewModel<IEnumerable<PersonResponse>>(planetsResponse.Data.People);
                },
                "Ha ocurrido un error no controlado al momento de obtener la información de personas");
    }
}
