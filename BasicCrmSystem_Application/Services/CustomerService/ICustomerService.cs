using BasicCrmSystem_Application.Models.DTOs;
using BasicCrmSystem_Application.Models.VMs;

namespace BasicCrmSystem_Application.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<bool> Create(CreateCustomerDTO model);
        Task<bool> Update(UpdateCustomerDTO model);
        Task Delete(int id);
        Task<UpdateCustomerDTO> GetById(int id);
        Task<List<CustomerVM>> GetAllCustomers();
    }
}
