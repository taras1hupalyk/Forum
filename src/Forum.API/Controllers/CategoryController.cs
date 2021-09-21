using Forum.BusinessLogic.Models;
using Forum.BusinessLogic.Services;
using Forum.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Forum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<CategoryDTO>> GetAll()
        {
            var response = await _categoryService.GetAllCategoriesAsync();
            return response;
        }

        

        [HttpPost]
        [Authorize(Roles = "Moderator")]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO)
        {
           var response = await _categoryService.AddCategoryAsync(categoryDTO);
            return Ok(response);
        }

        
        

        
        [HttpDelete("{id}")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _categoryService.DeleteCategory(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
