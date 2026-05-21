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

namespace DentalClinic.BLL.Service.PrescriptionItemService_Folder
{
    public class PrescriptionItemService :  IPrescriptionItemService
    {
        private readonly IGenericRepository<PrescriptionItem> _prescriptionItem;
        private readonly IGenericRepository<Prescription> _prescriptionRepo;
        private readonly IGenericRepository<Medicine> _medicineRepo;

        public PrescriptionItemService(IGenericRepository<PrescriptionItem> prescriptionItem
            ,IGenericRepository<Prescription> PrescriptionRepo
            ,IGenericRepository<Medicine> MedicineRepo 

            )
        {
            _prescriptionItem = prescriptionItem;
            _prescriptionRepo = PrescriptionRepo;
            _medicineRepo = MedicineRepo;
        }

        public async Task<CreatePrescriptionItemResponse> CreatePrescriptionItemAsync(CreatePrescriptionItemRequest request)
        {
            var PrescriptionItemData =  request.Adapt<PrescriptionItem>();
            var prescriptionItem = await _prescriptionItem.CreateAsync(PrescriptionItemData);

            if (prescriptionItem is null)
            {
                return new CreatePrescriptionItemResponse
                {
                    Success = false,
                    Message = "create prescription Items faild"
                };

            }

            //check medicine
            var medicineExist = await _medicineRepo.ExistsAsync(m => m.Id == request.MedicineId);
            if(!medicineExist)
            {
                return new CreatePrescriptionItemResponse { Success = false, Message = "Medicine Not Found" };

            }

            //check Prescription .....correct this part caude i dlete the id
            //var PrescriptionExist =  await _prescriptionRepo.ExistsAsync(p=>p.Id == request.PrescriptionId);
            //if (!PrescriptionExist) { return new CreatePrescriptionItemResponse {Success = false, Message = "Prescription not found" }; }


            return new CreatePrescriptionItemResponse
            {
                Success = true,
                Message = "create prescription Items success"
            };
        }
    }
}
