using PruebaService_Common.Interfaces;
using System.Threading.Tasks;

namespace PruebaService_Data.Contracts
{
    public interface IPersonData
    {
        Task<IResult> GetPersonById(int personId);
    }
}
