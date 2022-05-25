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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _prodCateRepository;

        public CategoryController(ICategoryRepository productCategory)
        {
            _prodCateRepository = productCategory;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_prodCateRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
