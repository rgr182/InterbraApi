using Dapper;
using InterbraApi.Domain.Entities;
using InterbraApi.Domain.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace InterbraApi.Domain.Repository
{
    public class UserRepository
    {
        private readonly IServiceProvider _serviceProvider;

        public UserRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private IDbConnection CreateConnection()
        {
            return _serviceProvider.GetRequiredService<IDbConnection>();
        }

        public List<User> GetUsers()
        {
            using (var dbConnection = CreateConnection())
            {
                string sql = "SELECT UserId, [Name], LastName, Gender, Dob, UserName, [Password], [Address] FROM [User]";
                var users = dbConnection.Query<User>(sql).ToList();
                return users;
            }
        }

        public IEnumerable<ShoppingCartItemDTO> GetUserShoppingCart(int userId)
        {
            using (var dbConnection = CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("UserId", userId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Return_Value", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                var shoppingCart = dbConnection.Query<ShoppingCartItemDTO>("dbo.GetUserShoppingCart", parameters, commandType: CommandType.StoredProcedure).ToList();

                int returnValue = parameters.Get<int>("Return_Value");
                Console.WriteLine("Return Value: " + returnValue);

                return shoppingCart;
            }
        }
    }
}
