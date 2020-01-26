using PruebaService_Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaService_App.Contracts
{
    public interface IPeople
    {
        Task<IResult> GetAll();
    }
}
