using DentalClinic.ADL.DTOs.Request;
using DentalClinic.ADL.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.Equipment_Folder
{
    public interface IEquipmentService 
    {
        Task<CreateEquipmentResponse> CreateEquipmentAsync(CreateEquipmentRequest request);
    }
}
