using DentalClinic.ADL.DTOs.Request.Create;
using DentalClinic.ADL.DTOs.Response.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.EquipmentCategories_Folder
{
    public interface IEquipmentCategoriesService
    {
        Task<CreateEquipmentCategoriesResponse> CreateEquipmentCategoriesAsync(CreateEquipmentCategoriesRequest request);
    }
}
