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

namespace DentalClinic.BLL.Service.SupplierService_Folder
{
    public class SupplierService : ISupplierService
    {

        private readonly IGenericRepository<Supplier> _supplierRepository;

        public SupplierService(IGenericRepository<Supplier> SupplierRepository)
        {
            _supplierRepository = SupplierRepository;
        }
        public async Task<CreateSupplierResponse> CreateSupplierAsync(CreateSupplierRequest supplierRequest)
        {
            var supplierData = supplierRequest.Adapt<Supplier>();
            var supplier = await _supplierRepository.CreateAsync(supplierData);
            try
            {
                if (supplier is null)
                {
                    return new CreateSupplierResponse
                    {
                        Success = false,
                        Message = "Cant create supplier",
                        //Errors = new List<string>()


                    };
                }

                return new CreateSupplierResponse
                {
                    Success = true,
                    Message = " suppler created successfully"
                };
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;

                if (innerMessage.Contains("duplicate key") || innerMessage.Contains("IX_Supplier_SupplierIdentificationCard")) ;
                return new CreateSupplierResponse { Success = false, Message = "A patient with this identification card already exists" };
            }
        }
    }
}
