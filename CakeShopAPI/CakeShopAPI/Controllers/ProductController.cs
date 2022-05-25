using CakeShopAPI.Models;
using CakeShopAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAll(string search, string category, string orderBy, int page = 1)
        {
            try
            {
                return Ok(_productRepository.GetAll(search, category, orderBy, page));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _productRepository.GetById(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("list/{idArray}")]
        public IActionResult GetByArray(string idArray)
        {
            try
            {
                var result = _productRepository.GetByArray(idArray);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("trending")]
        public IActionResult GetTrendingProducts()
        {
            try
            {
                return Ok(_productRepository.GetTrendingProducts(8));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("newProducts")]
        public IActionResult GetNewProducts()
        {
            try
            {
                return Ok(_productRepository.GetNewProducts(8));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost()]
        public IActionResult Create(ProductVM product)
        {
            try
            {
                _productRepository.Create(product);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(ProductVM product)
        {
            try
            {
                _productRepository.Update(product);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
