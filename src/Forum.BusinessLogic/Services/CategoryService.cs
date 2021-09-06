using Forum.BusinessLogic.Models;
using Forum.BusinessLogic.Services.Interfaces;
using Forum.DataAccess;
using Forum.DataAccess;
using Forum.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;


        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
        {
            var result = await _unitOfWork.Categories.GetAllAsync();

            var mappedResult = result.Select(item => new CategoryDTO()
            {
                Title = item.Title,
                Description = item.Description
            }).ToList();

            return mappedResult;
        }

        public async Task<Category> AddCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = new Category()
            {
                Title = categoryDTO.Title,
                Description = categoryDTO.Description
            };
            var result = await _unitOfWork.Categories.InsertAsync(category);
            return result;
        }
    }
}
