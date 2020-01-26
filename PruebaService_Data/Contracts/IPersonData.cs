using PruebaService_Common.Interfaces;
using PruebaService_Common.Models;
using PruebaService_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaService_Data.Contracts
{
    public interface IPersonData
    {
        Task<IResult> GetPersonById(int personId);
    }
}
