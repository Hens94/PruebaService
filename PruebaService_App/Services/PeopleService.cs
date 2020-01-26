using PruebaService_App.Contracts;
using PruebaService_App.Contracts.HttpClients;
using PruebaService_App.Extensions;
using PruebaService_App.Models.HttpClients;
using PruebaService_App.ViewModels;
using PruebaService_Common.Interfaces;
using PruebaService_Data.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.ExceptionExtensions;

namespace PruebaService_App.Services
{
    public class PeopleService : IPeople
    {
        private readonly IPruebaHttpClient _pruebaHttpClient;
        private readonly IPersonData _personData;

        public PeopleService(IPruebaHttpClient pruebaHttpClient, IPersonData personData)
        {
            _pruebaHttpClient = pruebaHttpClient;
            _personData = personData;
        }

        public async Task<IResult> GetAll() =>
            await UseCatchExceptionAsync<IResult, AppException>(
                async execError => 
                {
                    var people = await _pruebaHttpClient.GetPeople().GetFromJson<PeopleResponse>();

                    return new ResultViewModel<IEnumerable<PeopleViewModel>>(await people.ToPeopleViewModel(_personData));
                },
                "Ha ocurrido un error no controlado al momento de obtener la información de personas");
    }
}
