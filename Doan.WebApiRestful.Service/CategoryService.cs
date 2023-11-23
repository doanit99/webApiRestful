using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doan.WebApiRestful.Data.Abstract;
using Doan.WebApiRestful.Domain.Entities;

namespace Doan.WebApiRestful.Service
{
	public class CategoryService : ICategoryService
	{
		IRepository<Categories> _categoryRepository;
		public CategoryService(IRepository<Categories> categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<IEnumerable<Categories>> GetCategories()
		{
			return await _categoryRepository.GetAllAsync();
		}
	}
}
