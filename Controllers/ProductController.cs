using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
	public class ProductController : Controller
	{
		private IProductRepository _repository;
		public int PageSize = 4;
		public ProductController(IProductRepository repository)
		{
			_repository = repository;
		}
		//[Route("/Product/List", Name = "Custom")]
		public ViewResult List(int productPage = 1)
		=> View(new ProductListViewModel
		{
			Products = _repository.Products
			.OrderBy(p => p.ProductID)
			.Skip((productPage - 1) * PageSize)
			.Take(PageSize),
			PagingInfo = new PagingInfo()
			{
				CurrentPage = productPage,
				ItemsPerPage = PageSize,
				TotalItems = _repository.Products.Count()
			}
		});
		

	}
}
