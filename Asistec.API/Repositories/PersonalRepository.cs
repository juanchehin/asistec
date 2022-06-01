using asistec.CapaLogica;
using Asistec.API.Entities;

namespace Asistec.API.Repositories
{
    public class PersonalRepository: IPersonalRepository
    {
        private readonly IConfiguration _configuration;

        public PersonalRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public Task? GetPersonal(int idPersonal)
        {
            string rpta;

            LPersonal lpersonal = new LPersonal();

            lpersonal.DamePersonal(idPersonal);

            return null;
        }

        public async Task<bool> CreatePersonal(Personal personal)
        {
            //using var connection = new NpgsqlConnection
            //    (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            //var affected =
            //    await connection.ExecuteAsync
            //        ("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
            //                new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

            //if (affected == 0)
            //    return false;

            return true;
        }

        public async Task<bool> UpdatePersonal(Personal personal)
        {
            //using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            //var affected = await connection.ExecuteAsync
            //        ("UPDATE Coupon SET ProductName=@ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
            //                new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

            //if (affected == 0)
            //    return false;

            return true;
        }

        public async Task<bool> DeletePersonal(int idPersonal)
        {
            //using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            //var affected = await connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName",
            //    new { ProductName = productName });

            //if (affected == 0)
            //    return false;

            return true;
        }

    }
}
