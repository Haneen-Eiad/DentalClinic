using DentalClinic.ADL.Models;
using DentalClinic.ADL.Repository;
using DentalClinic.ADL.Repository.PatientRepo;
using DentalClinic.ADL.Utilities;
using DentalClinic.BLL.Service;
using DentalClinic.BLL.Service.Appointment_Folder;
using DentalClinic.BLL.Service.Authntication;
using DentalClinic.BLL.Service.Equipment_Folder;
using DentalClinic.BLL.Service.EquipmentCategories_Folder;
using DentalClinic.BLL.Service.Expense_Folder;
using DentalClinic.BLL.Service.Medicine_Folder;
using DentalClinic.BLL.Service.PateintService_Folder;
using DentalClinic.BLL.Service.PatientTreatment_Folder;
using DentalClinic.BLL.Service.PrescriptionItemService_Folder;
using DentalClinic.BLL.Service.PrescriptionService_Folder;
using DentalClinic.BLL.Service.SupplierService_Folder;
using DentalClinic.BLL.Service.TreatmentService_Folder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace DentalClinic.PL
{
    public class AppConfiguration
    {
        public static void Config(IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExcpetionHandler>();
            services.AddProblemDetails();
            services.AddScoped<ISeedData, RoleSeedData>();
            services.AddScoped<ISeedData, UserSeedData>();
            services.AddScoped<ISeedData, SupplierSeedData>();
            services.AddScoped<ISeedData, TreatmentSeedData>();
            services.AddScoped<IAuthnticationService, AuthnticationService>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientSerive,PatientSerive>();
            //generic
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepostitory<>));
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ITreatmentService, TreatmentSerivce>();
            services.AddScoped<IPrescriptionItemService,PrescriptionItemService>();
            services.AddScoped<IMedicineService, MedicineService>();
            services.AddScoped<IExpenseService, ExpenseService>();
            services.AddScoped<IEquipmentCategoriesService, EquipmentCategoriesService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IPatientTreatmentService, PatientTreatmentService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IAppointmentQueueService, AppointmentQueueService>();
        }
    }
}
