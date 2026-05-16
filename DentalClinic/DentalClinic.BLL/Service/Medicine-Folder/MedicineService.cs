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

namespace DentalClinic.BLL.Service.Medicine_Folder
{
    public class MedicineService :  IMedicineService
    {
        private readonly IGenericRepository<Medicine> _medicineRepo;

        public MedicineService(IGenericRepository<Medicine> MedicineRepo)
        {
            _medicineRepo = MedicineRepo;
        }
        public async Task<CreateMedicineResponse> CreateMedicineAsync(CreateMedicineRequest request)
        {
            var MedicineData =  request.Adapt<Medicine>();
            var medicine  = await _medicineRepo.CreateAsync(MedicineData);
            if(medicine is null)
            {
                return new CreateMedicineResponse { Success = false, Message = "Can't create Medicine" };
            }

            return new CreateMedicineResponse { Success = true, Message = " Medicine created successfully" };
        }
    }
}
