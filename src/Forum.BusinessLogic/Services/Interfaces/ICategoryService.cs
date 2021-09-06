using Forum.BusinessLogic.Models;
using Forum.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.BusinessLogic.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> AddCategoryAsync(CategoryDTO categoryDTO);
        Task<List<CategoryDTO>> GetAllCategoriesAsync();
    }
}