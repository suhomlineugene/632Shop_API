using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SixThreeTwo_shop.Products;
using SixThreeTwo_shop.Shared.Viscosities;
using SixThreeTwo_shop.Shared.Viscosities.Dto;

namespace SixThreeTwo_shop.Viscosities;

public class ViscositiesAppService(
    IRepository<EngineOilViscosity> engineOilViscosityRepository,
    IRepository<TransmissionOilViscosity> transmissionOilViscosityRepository)
    : SixThreeTwo_shopAppServiceBase, IViscositiesAppService
{
    public async Task<List<EngineOilViscosityDto>> GetEngineViscositiesList()
    {
        try
        {
            var viscosities = await (await engineOilViscosityRepository.GetAllAsync()).ToListAsync();
            return ObjectMapper.Map<List<EngineOilViscosityDto>>(viscosities);
        }
        catch (Exception ex)
        {
            Logger.Error("Error while getting engine viscosities list.", ex);
            throw;
        }
    }

    public async Task<List<TransmissionOilViscosityDto>> GetTransmissionViscositiesList()
    {
        try
        {
            var viscosities = await (await transmissionOilViscosityRepository.GetAllAsync()).ToListAsync();
            return ObjectMapper.Map<List<TransmissionOilViscosityDto>>(viscosities);
        }
        catch (Exception ex)
        {
            Logger.Error("Error while getting transmission viscosities list.", ex);
            throw;
        }
    }

    public async Task<int> CreateEditEngineViscosity(CreateEditEngineOilViscosityDto dto)
    {
        try
        {
            if (dto.Id == 0)
            {
                var entity = ObjectMapper.Map<EngineOilViscosity>(dto);
                var id = await engineOilViscosityRepository.InsertAndGetIdAsync(entity);
                return id;
            }

            var existing = await engineOilViscosityRepository.GetAsync(dto.Id);
            ObjectMapper.Map(dto, existing);
            await engineOilViscosityRepository.UpdateAsync(existing);
            return existing.Id;
        }
        catch (Exception ex)
        {
            Logger.Error($"Error while creating/editing engine viscosity '{dto?.Name}'.", ex);
            throw;
        }
    }

    public async Task<int> CreateEditTransmissionViscosity(CreateEditTransmissionOilViscosityDto dto)
    {
        try
        {
            if (dto.Id == 0)
            {
                var entity = ObjectMapper.Map<TransmissionOilViscosity>(dto);
                var id = await transmissionOilViscosityRepository.InsertAndGetIdAsync(entity);
                return id;
            }

            var existing = await transmissionOilViscosityRepository.GetAsync(dto.Id);
            ObjectMapper.Map(dto, existing);
            await transmissionOilViscosityRepository.UpdateAsync(existing);
            return existing.Id;
        }
        catch (Exception ex)
        {
            Logger.Error($"Error while creating/editing transmission viscosity '{dto?.Name}'.", ex);
            throw;
        }
    }

    public async Task DeleteEngineViscosity(int id)
    {
        try
        {
            await engineOilViscosityRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            Logger.Error($"Error while deleting engine viscosity with id '{id}'.", ex);
            throw;
        }
    }

    public async Task DeleteTransmissionViscosity(int id)
    {
        try
        {
            await transmissionOilViscosityRepository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            Logger.Error($"Error while deleting transmission viscosity with id '{id}'.", ex);
            throw;
        }
    }

    public async Task<EngineOilViscosityDto> GetEngineViscosityById(int id)
    {
        var viscosity = await engineOilViscosityRepository.FirstOrDefaultAsync(v => v.Id == id);
        return ObjectMapper.Map<EngineOilViscosityDto>(viscosity);
    }

    public async Task<TransmissionOilViscosityDto> GetTransmissionViscosityById(int id)
    {
        var viscosity = await transmissionOilViscosityRepository.FirstOrDefaultAsync(v => v.Id == id);
        return ObjectMapper.Map<TransmissionOilViscosityDto>(viscosity);
    }
}