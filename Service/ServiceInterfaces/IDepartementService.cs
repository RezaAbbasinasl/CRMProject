using DataTransferObject.DTOClasses;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces;

public interface IDepartementService
{
    Task<bool> AddDepartement(DepartementDTO departement);
    Task<bool> DeleteDepartement(Guid departementId, Guid userId);
    Task<bool> UpdateDepartement(DepartementDTO departement, Guid userId);
    Task<DepartementDTO> GetDepartement(string departementId);
    Task<List<DepartementDTO>> AllDepartement(Expression<Func<Departement, bool>> predicate);
}
