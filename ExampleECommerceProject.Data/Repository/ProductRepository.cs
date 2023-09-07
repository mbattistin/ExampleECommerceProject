using ExampleECommerceProject.Data.Contracts;
using ExampleECommerceProject.Data.Data;
using ExampleECommerceProject.Models.Models;

namespace ExampleECommerceProject.Data.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
