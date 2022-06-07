using asistec.CapaLogica;
using Asistec.API.Entities;
using Asistec.API.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Asistec.API.Repositories
{
    public class PersonalRepository : IPersonalRepository
    {
        private MySqlConfiguration _connectionString;

        public PersonalRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection("Server=localhost;Port=3306;Database=asistec;User Id=root;Password=;");
        }

        public async Task? GetPersonal(int idPersonal)
        {
            //var db = dbConnection();

            //var sql = @"SELECT * from personal";

            //return await db.OpenAsync();

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
