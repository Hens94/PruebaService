using PruebaService_App.Contracts;
using PruebaService_App.ViewModels;
using PruebaService_Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaService_App.Services
{
    public class PeopleService2 : IPeople
    {
        public async Task<IResult> GetAll()
        {
            return await Task.Run(() =>
            {
                return new ResultViewModel<IEnumerable<PeopleViewModel>>(new List<PeopleViewModel>
                {
                    new PeopleViewModel
                    {
                        Id = 1,
                        Name = "Allan",
                        Height = 170,
                        Mass = 140,
                        Gender = "No definido",
                        Created = DateTime.Now,
                        Edited = DateTime.Now
                    }
                });
            });


        }
    }
}
