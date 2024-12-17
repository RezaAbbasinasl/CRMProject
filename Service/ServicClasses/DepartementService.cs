using DataTransferObject.DTOClasses;
using Infrastructure.RepositoryPattern;
using Infrastructure.RepositoryPattern.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Model.Entities;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServicClasses;

public class DepartementService : IDepartementService
{
    private readonly IDepartementRepository _departementRepository;
    private readonly UserManager<User> _userManager;

    public DepartementService(IDepartementRepository departementRepository, UserManager<User> userManager)
    {
        _departementRepository = departementRepository;
        _userManager = userManager;
    }

    public async Task<bool> AddDepartement(DepartementDTO departement)
    {
        //departement.CreateUserId = departement.Id;
        var resultDepartement = await _departementRepository.CreateDataAsync(departement.Adapt<Departement>());

        if (resultDepartement == null)
            throw new Exception("");

        return true;

    }

    public async Task<List<DepartementDTO>> AllDepartement(Expression<Func<Departement, bool>> predicate = null)
    {
        var departementResult = await _departementRepository.QueryAsync(predicate ?? (d => true));

        if (departementResult == null)
            departementResult = new List<Departement>();

        
        var result =   departementResult.Select(d => d.Adapt<DepartementDTO>()).ToList();
        return result;
    }
    public async Task<DepartementDTO> GetDepartement(string departementId)
    {
        var department = await _departementRepository.GetAsync(new Guid(departementId));
        
        if (department == null)
            throw new Exception("");

        return department.Adapt<DepartementDTO>();

    }

    public async Task<bool> DeleteDepartement(Guid departementId, Guid userId)
    {
        if (userId == Guid.Empty)
            throw new Exception("");

        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
            throw new Exception("");

        var departement = await _departementRepository.GetAsync(departementId);
        bool isValid = false;
        if (departement != null)
        {
            await _departementRepository.DeleteDataAsync(departementId);
            isValid = true;
        }
        return isValid;           
    }


    public async Task<bool> UpdateDepartement(DepartementDTO departement, Guid userId)
    {
        if (userId == Guid.Empty)
            throw new Exception("");

        var user = await _userManager.FindByIdAsync(userId.ToString());
        bool isValid = false;

        if (user != null)
        {
            await _departementRepository.UpdateDataAsync(departement.Adapt<Departement>());
            isValid = true;
        }
        return isValid;
    }
}
