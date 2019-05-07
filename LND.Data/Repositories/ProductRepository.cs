using LND.Data.Infrastructure;
using LND.Model.Models;

namespace LND.Data.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}