using DentalClinic.ADL.DTOs.Request.Create;
using DentalClinic.ADL.DTOs.Response.Create;
using DentalClinic.ADL.Models;
using DentalClinic.ADL.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.Equipment_Folder
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IGenericRepository<Equipment> _equipmentRepo;

        public EquipmentService(IGenericRepository<Equipment> EquipmentRepo) {
            _equipmentRepo = EquipmentRepo;
        }

        public async Task<CreateEquipmentResponse> CreateEquipmentAsync(CreateEquipmentRequest request)
        {
            var equipmentData =  request.Adapt<Equipment>();
            var equipment = await _equipmentRepo.CreateAsync(equipmentData);
            if (equipment is null) {
                return new CreateEquipmentResponse{ Success = false, Message = "create Equipment faild"};}
                return new CreateEquipmentResponse{Success = true,  Message = "Equipment created successfully " };
            }
    }
}
