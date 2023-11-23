using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Doan.WebApiRestful.Data.Abstract
{
	public interface IRepository<T> where T : class
	{
		Task CommitAsync();
		void Delete(T entity);
		void Delete(Expression<Func<T, bool>> expression);
		/// <summary>
		/// Get data by expression
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
		Task<T> GetByIdAsync(object id);
		Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression = null);
		Task InsertAsync(T entity);
		Task InsertAsync(IEnumerable<T> entities);
		void Update(T entity);
	}
}
