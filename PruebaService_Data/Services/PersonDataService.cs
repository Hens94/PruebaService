using Dapper;
using Microsoft.Extensions.Configuration;
using PruebaService_Common.Interfaces;
using PruebaService_Common.Models;
using PruebaService_Data.Contracts;
using PruebaService_Data.Models;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static System.ExceptionExtensions;

namespace PruebaService_Data.Services
{
    public class PersonDataService : IPersonData
    {
        private readonly string _pruebaConnectionString;

        public PersonDataService(IConfiguration config)
        {
            _pruebaConnectionString = config.GetConnectionString("Prueba");
        }

        public async Task<IResult> GetPersonById(int personId) =>
            await UseCatchExceptionAsync<IResult, DatabaseException>(
                async execError =>
                {
                    using var sqlConn = new SqlConnection(_pruebaConnectionString);

                    var query = $"SELECT personId, height, mass FROM dbo.PersonInfo WHERE personId = {personId}";

                    var personInfo = await sqlConn.QuerySingleOrDefaultAsync<PersonInfo>(query);

                    if (personInfo is null)
                    {
                        return new Result($"No se encontraron registro de la persona con identificador {personId}", 111);
                    }

                    return new Result<PersonInfo>(personInfo);
                },
                "Ha ocurrido un error no controlado al momento de obtener la información de persona en base de datos");
    }
}
