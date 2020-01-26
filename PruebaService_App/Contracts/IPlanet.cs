using PruebaService_Common.Interfaces;
using System.Threading.Tasks;

namespace PruebaService_App.Contracts
{
    public interface IPlanet
    {
        Task<IResult> GetAll();
    }
}
