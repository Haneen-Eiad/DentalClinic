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
    public class PrescriptionItemService : IPrescriptionItemService
    {
        private readonly IGenericRepository<PrescriptionItem> _prescriptionItem;
        private readonly IGenericRepository<Prescription> _prescriptionRepo;
        private readonly IGenericRepository<Medicine> _medicineRepo;

        public PrescriptionItemService(IGenericRepository<PrescriptionItem> prescriptionItem
            , IGenericRepository<Prescription> PrescriptionRepo
            , IGenericRepository<Medicine> MedicineRepo
            )
        {
            _prescriptionItem = prescriptionItem;
            _prescriptionRepo = PrescriptionRepo;
            _medicineRepo = MedicineRepo;
        }

        // Accept prescriptionId separately (do not require it on the DTO)
        public async Task<CreatePrescriptionItemResponse> CreatePrescriptionItemAsync(CreatePrescriptionItemRequest request, int prescriptionId)
        {
            if (request is null)
            {
                return new CreatePrescriptionItemResponse { Success = false, Message = "Request is null" };
            }

            if (!request.MedicineId.HasValue)
            {
                return new CreatePrescriptionItemResponse { Success = false, Message = "MedicineId is required" };
            }

            // check medicine
            var medicineExist = await _medicineRepo.ExistsAsync(m => m.Id == request.MedicineId.Value);
            if (!medicineExist)
            {
                return new CreatePrescriptionItemResponse { Success = false, Message = "Medicine Not Found" };
            }

            // check Prescription
            var prescriptionExist = await _prescriptionRepo.ExistsAsync(p => p.Id == prescriptionId);
            if (!prescriptionExist)
            {
                return new CreatePrescriptionItemResponse { Success = false, Message = "Prescription not found" };
            }

            // map and set parent id
            var prescriptionItemData = request.Adapt<PrescriptionItem>();
            prescriptionItemData.PrescriptionId = prescriptionId;

            var prescriptionItem = await _prescriptionItem.CreateAsync(prescriptionItemData);

            if (prescriptionItem is null)
            {
                return new CreatePrescriptionItemResponse
                {
                    Success = false,
                    Message = "create prescription item failed"
                };
            }

            return new CreatePrescriptionItemResponse
            {
                Success = true,
                Message = "create prescription item success"
            };
        }
    }
}