using Doan.WebApiRestful.Service;
using Microsoft.AspNetCore.Mvc;

namespace Doan.WebApiRestful.Controllers
{
	[Route("api/[controller]")]  //api/category
	[ApiController]
	public class CategoryController : Controller
	{
		ICategoryService _categoryService;
		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
			
		}

		[Route("")]
		public async Task<IActionResult> Index()
		{
			return Ok(await _categoryService.GetCategories());
		}
	}
}
