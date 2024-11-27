using AutoMapper;
using ECommerceAPI.DTOModels;
using ECommerceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper mapper;

        public ProductsController(IProductRepository _productRepository , IMapper mapper)
        {
            this._productRepository = _productRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllproducts()
        { 
        var products = await _productRepository.GetAllAsync();

            var productsDTO = mapper.Map<List<ProductDTO>>(products);
            return Ok(productsDTO);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPrioductByID(int id)
        { 
        var prod = _productRepository.GetByIdAsync(id);
            if (prod is null)
            {
                return BadRequest(ModelState);
            }
            return Ok(prod);
        }
            
    }
}
