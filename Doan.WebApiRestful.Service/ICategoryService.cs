using Doan.WebApiRestful.Domain.Entities;

namespace Doan.WebApiRestful.Service
{
	public interface ICategoryService
	{
		Task<IEnumerable<Categories>> GetCategories();
	}
}