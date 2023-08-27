using ExampleECommerceProject.Data.Contracts;
using ExampleECommerceProject.Data.Data;
using System.Linq.Expressions;

namespace ExampleECommerceProject.Data.Repository
{
	public class Repository<T> : IRepository<T> where T: class
	{
        private readonly ApplicationDbContext _db;

		public Repository(ApplicationDbContext db)
		{
			_db = db;
		}

		public void Add(T entity)
		{
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
        }

		public T Get(Expression<Func<T, bool>> filter)
		{
            IQueryable<T> query = _db.Set<T>();
            return query.Where(filter).FirstOrDefault();
		}

		public IEnumerable<T> GetAll()
		{
			return _db.Set<T>().ToList();
		}

		public void Remove(T entity)
		{
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

		public void RemoveRange(IEnumerable<T> entities)
		{
            _db.Set<T>().RemoveRange(entities);
            _db.SaveChanges();
        }

		public void Update(T entity)
		{
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
        }
	}
}
