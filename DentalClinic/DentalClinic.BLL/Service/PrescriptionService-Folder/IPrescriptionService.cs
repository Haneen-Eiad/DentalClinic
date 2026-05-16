using DentalClinic.ADL.DTOs.Request;
using DentalClinic.ADL.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.PrescriptionService_Folder
{
    public interface IPrescriptionService
    {
        Task<CreatePrescriptionResponse> CreatePrescriptionAsync(CreatePrescriptionRequest prescriptionRequest);
    }
}
