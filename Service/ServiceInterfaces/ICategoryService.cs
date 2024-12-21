using DataTransferObject.DTOClasses;
using Infrastructure.RepositoryPattern;
using Model.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces;

public interface ICategoryService
{
    Task<bool> AddCategory(CategoryDTO category);
    Task<bool> DeleteCategory(Guid categoryId, string userId);
    Task<bool> UpdateCategory(EditCategoryDTO category, string userId);
    Task<List<CategoryDTO>> AllCategory();
    Task<CategoryDTO> GetCategory(Guid categoryId);
    Task<PaginatedList<CategoryDTO>> GetCategoryListAsPagination(int pagesize, int pageindex, string searchName);
}
