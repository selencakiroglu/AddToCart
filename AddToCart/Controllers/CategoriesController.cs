using AddToCart.Models;
using AddToCart.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AddToCart.Controllers
{
    [Route("api/movie")]
    public class CategoriesController : ControllerBase
    {
        private IAddToCartRepository _addToCartRepository;

        public CategoriesController(IAddToCartRepository addToCartRepository)
        {
            _addToCartRepository = addToCartRepository;
        }

        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            var categoryEntities = _addToCartRepository.GetCategories();
            var results = Mapper.Map<CategoryListDto>(categoryEntities);

            if (results.Categories.Count == 0)
            {
                return StatusCode(204, "No categories found.");
            }

            return Ok(results);
        }
    }
}
