using DataTransferObject.DTOClasses;
using Infrastructure.RepositoryPattern;
using Infrastructure.RepositoryPattern.Classes;
using Infrastructure.RepositoryPattern.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Model.Entities;
using Service.ServiceInterfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServicClasses;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly UserManager<User> _userManager;

    public CategoryService(ICategoryRepository categoryRepository, UserManager<User> userManager)
    {
        _categoryRepository = categoryRepository;
        _userManager = userManager;
    }

    public async Task<bool> AddCategory(CategoryDTO category)
    {
        bool isValid = false;
        var resultCategory = _categoryRepository.CreateDataAsync(category.Adapt<Category>());

        if (resultCategory != null)
            isValid = true;

        return isValid;
    }

    public async Task<List<CategoryDTO>> AllCategory()
    {
        var categorys = await _categoryRepository.QueryAsync(p => true);
        if (categorys == null)
            categorys = new();

        return categorys.Select(c => c.Adapt<CategoryDTO>()).ToList();
    }

    public async Task<bool> DeleteCategory(Guid categoryId, string userId)
    {
        if (userId.IsNullOrEmpty())
            throw new Exception("The user ID is incorrect.");

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            throw new Exception("User not found.");

        if (categoryId == Guid.Empty)
            throw new Exception("The categoryId is incorrect. ");

        return await _categoryRepository.DeleteDataAsync(categoryId);
    }

    public async Task<CategoryDTO> GetCategory(Guid categoryId)
    {
        var category = await _categoryRepository.GetAsync(categoryId);

        if (category == null)
            throw new Exception("There is no such Catagory.");

        return category.Adapt<CategoryDTO>();
    }

    public async Task<PaginatedList<CategoryDTO>> GetCategoryListAsPagination(int pagesize, int pageindex, string searchName)
    {
        List<Category> categorys = await _categoryRepository.QueryAsync(c => true);

        if (!string.IsNullOrEmpty(searchName))
            categorys = categorys.Where(c => c.Name.Contains(searchName)).ToList();

        PaginatedList<Category> data = PaginatedList<Category>.Create(categorys, pageindex, pagesize);
        return new PaginatedList<CategoryDTO>(data.Select(c => c.Adapt<CategoryDTO>()).ToList(), categorys.Count(), pageindex, pagesize);
    }

    public async Task<bool> UpdateCategory(EditCategoryDTO category, string userId)
    {
        if (userId.IsNullOrEmpty())
            throw new Exception("The user ID is incorrect.");

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            throw new Exception("User not found.");

        var fullCategory = await GetCategory(category.Id);
        fullCategory.Name = category.Name;
        fullCategory.Description = category.Description;

        var resultCategory = await _categoryRepository.UpdateDataAsync(fullCategory.Adapt<Category>());
        bool isValid = true;

        if (resultCategory == null)
            isValid = false;

        return isValid;
    }
}
