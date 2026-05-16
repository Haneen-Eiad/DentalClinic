using DentalClinic.ADL.DTOs.Request;
using DentalClinic.ADL.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.Medicine_Folder
{
    public interface IMedicineService
    {
        Task<CreateMedicineResponse> CreateMedicineAsync(CreateMedicineRequest request);
    }
}
