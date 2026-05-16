using DentalClinic.ADL.DTOs.Request;
using DentalClinic.ADL.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.PrescriptionItemService_Folder
{
    public interface IPrescriptionItemService
    {
        Task<CreatePrescriptionItemResponse> CreatePrescriptionItemAsync(CreatePrescriptionItemRequest request);
    }
}
