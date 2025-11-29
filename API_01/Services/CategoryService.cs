using API_01.DAL.Models;
using API_01.DAL.Models.Dtos;
using API_01.DAL.Models.Dtos.Category;
using API_01.Repository.IRepository;
using API_01.Services.IServices;
using AutoMapper;

namespace API_01.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> CategoryExistByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CategoryExistByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateUpdateDto categoryCreateDto)
        {
            var categoryExist = await _categoryRepository.CategoryExistByNameAsync(categoryCreateDto.Name);

            if (categoryExist)
            {
                throw new InvalidOperationException($"Ya existe una categoría con el nombre de '{categoryCreateDto.Name}'");
            }

            var category = _mapper.Map<Category>(categoryCreateDto);  

            var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new Exception("Ocurrió un error al crear la categoría");
            }

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var categoryExist = await _categoryRepository.GetCategoryAsync(id);

            if (categoryExist == null)
            {
                throw new InvalidOperationException($"No se encontró la categoria con ID: '{id}'");
            }
            var categoryDeleted = await _categoryRepository.DeleteCategoryAsync(id);
            
            if (!categoryDeleted)
            {
                throw new Exception("Ocurrió un error al eliminar la categoría");
            }
            return categoryDeleted;
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();

            return _mapper.Map<ICollection<CategoryDto>>(categories);
        }
        public async Task<CategoryDto> UpdateCategoryAsync(CategoryCreateUpdateDto dto, int id)
        {
            var categoryExist = await _categoryRepository.GetCategoryAsync(id);

            if (categoryExist == null)
            {
                throw new InvalidOperationException($"No se encontró la categoria con ID: '{id}'");
            }

            var nameExist = await _categoryRepository.CategoryExistByNameAsync(dto.Name);   

            if (nameExist)
            {
                throw new InvalidOperationException($"Ya existe una categoría con el nombre de '{dto.Name}'");
            }

            _mapper.Map(dto, categoryExist);

            var categoryUpdated = await _categoryRepository.UpdateCategoryAsync(categoryExist);

            if (!categoryUpdated)
            {
                throw new Exception("Ocurrió un error al actualizar la categoría");
            }

            return _mapper.Map<CategoryDto>(categoryExist);
        }
        public async Task<CategoryDto> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);

            return _mapper.Map<CategoryDto>(category);
        }

    }
}
