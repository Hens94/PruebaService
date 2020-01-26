using PruebaService_App.Models.HttpClients;
using PruebaService_App.ViewModels;
using PruebaService_Common.Interfaces;
using PruebaService_Common.Models;
using PruebaService_Data.Contracts;
using PruebaService_Data.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static System.ExceptionExtensions;

namespace PruebaService_App.Extensions
{
    public static class PeopleExtensions
    {
        public static async Task<IEnumerable<PeopleViewModel>> ToPeopleViewModel(this IResult<PeopleResponse> peopleResponse, IPersonData personData) =>
            await UseCatchCustomExceptionAsync<IEnumerable<PeopleViewModel>, AppException>(
                async (execError, execException) =>
                {
                    if (!peopleResponse.Code.Equals(0))
                    {
                        execException(new HttpClientException(message: peopleResponse.Message, resultCode: 111, statusCode: HttpStatusCode.OK));
                    }

                    var people = peopleResponse.Data.People;
                    var peopleViewModel = new List<PeopleViewModel>();

                    foreach (var person in people)
                    {
                        var personInfoData = await personData.GetPersonById(person.Id);

                        var personInfo = personInfoData.Code.Equals(0) ? (Result<PersonInfo>)personInfoData : null;

                        var heigth = personInfo?.Data.Height ?? 0;
                        var mass = personInfo?.Data.Mass ?? 0;

                        peopleViewModel.Add(new PeopleViewModel
                        {
                            Id = person.Id,
                            Name = person.Name,
                            Height = heigth,
                            Mass = mass,
                            Gender = person.Gender,
                            Created = person.Created,
                            Edited = person.Edited
                        });
                    }

                    return peopleViewModel;
                },
                "Ha ocurrido un error al momento de convertir los datos a personas");
    }
}
