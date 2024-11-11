using Dapper;
using InterbraApi.Domain.Entities;
using System.Data;

namespace InterbraApi.Domain.Repository
{

    public interface IProductRepository
    {
        public Product SaveProduct(Product Product);
        public IEnumerable<Product> GetTopProducts(int topCount);
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
                string sql = "INSERT INTO [Product] (Name, Description, Size, ImageUrl, Quantity]) " +
                                 "VALUES (@Name, @Description, @ImageUrl, @Size, @Quantity);";

                dbConnection.Execute(sql, new
                {
                    Name = Product.Name,
                    Description = Product.Description,
                    Size = Product.Size,
                    ImageUrl = Product.ImageUrl,
                    Quantity = Product.Quantity,
                });
                return Product;
            }
        }

        public IEnumerable<Product> GetTopProducts(int topCount)
        {
            using (var dbConnection = CreateConnection())
            {
                string sql = "SELECT TOP (@TopCount) * FROM [Product];";

                var products = dbConnection.Query<Product>(sql, new { TopCount = topCount });
                return products;
            }
        }
    }
}
