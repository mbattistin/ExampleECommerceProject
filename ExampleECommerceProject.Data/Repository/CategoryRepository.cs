using ExampleECommerceProject.Data.Contracts;
using ExampleECommerceProject.Data.Data;
using ExampleECommerceProject.Models.Models;

namespace ExampleECommerceProject.Data.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
