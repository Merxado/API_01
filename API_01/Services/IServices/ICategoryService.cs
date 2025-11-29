using API_01.DAL.Models;
using API_01.DAL.Models.Dtos;
using API_01.DAL.Models.Dtos.Category;

namespace API_01.Services.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryDto);
        Task<CategoryDto> UpdateCategoryAsync(CategoryCreateDto dto, int id);
        Task<bool> CategoryExistByIdAsync(int id);
        Task<bool> CategoryExistByNameAsync(string name);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
