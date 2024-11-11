using Dapper;
using InterbraApi.Domain.Entities;
using InterbraApi.Domain.Model;
using System.Data;
using System.Data.Common;

namespace InterbraApi.Domain.Repository
{

    public interface IProductRepository
    {
        public Product SaveProduct(Product Product);
    }

    public class ProductRepository : IProductRepository
    {
         
        private readonly IServiceProvider _serviceProvider;

        public ProductRepository(IServiceProvider serviceProvider) 
        {
         _serviceProvider = serviceProvider;
        }
        private IDbConnection CreateConnection()
        {
            return _serviceProvider.GetRequiredService<IDbConnection>();
        }
        public Product SaveProduct(Product Product)
        {


            using (var dbConnection = CreateConnection())
            {
                string sql = "INSERT INTO [Product] (Name, Description, Size, Quantity]) " +
                                 "VALUES (@Name, @Description, @Size, @Quantity);";

                dbConnection.Execute(sql, new
                {
                    Name = Product.Name,
                    Description = Product.Description,
                    Size = Product.Size,
                    Quantity = Product.Quantity,
                });
                return Product;


            }
        }
    }
}
