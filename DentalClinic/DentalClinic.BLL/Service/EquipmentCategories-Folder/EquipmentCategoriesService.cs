using DentalClinic.ADL.DTOs.Request;
using DentalClinic.ADL.DTOs.Response;
using DentalClinic.ADL.Models;
using DentalClinic.ADL.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.EquipmentCategories_Folder
{
    public class EquipmentCategoriesService : IEquipmentCategoriesService
    {
        private readonly IGenericRepository<EquipmentCategories> _equipmentCategoriesRepo;

        public EquipmentCategoriesService(IGenericRepository<EquipmentCategories> EquipmentCategoriesRepo)
        {
            _equipmentCategoriesRepo = EquipmentCategoriesRepo;
        }

        public async Task<CreateEquipmentCategoriesResponse> CreateEquipmentCategoriesAsync(CreateEquipmentCategoriesRequest request)
        {
            var EquipmentCategoriesData = request.Adapt<EquipmentCategories>();
            var equipmentCategories = await _equipmentCategoriesRepo.CreateAsync(EquipmentCategoriesData);

            if(equipmentCategories is null)
            {
                return new CreateEquipmentCategoriesResponse
                {
                    Success = false,
                    Message = "can't create equipment categories"
                };

            }

            return new CreateEquipmentCategoriesResponse
            {
                Success = true,
                Message = "create equipment categories successfully "
            };



        }
    }
}
