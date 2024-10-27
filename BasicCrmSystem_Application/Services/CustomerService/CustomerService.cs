using AutoMapper;
using BasicCrmSystem_Application.Models.DTOs;
using BasicCrmSystem_Application.Models.VMs;
using BasicCrmSystem_Domain.Entities;
using BasicCrmSystem_Domain.Repositories;

namespace BasicCrmSystem_Application.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper) {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(CreateCustomerDTO model)
        {
            Customer customer = _mapper.Map<Customer>(model);
            customer.CreatedAt = DateTime.Now;
            return await _customerRepository.Add(customer);
        }

        public async Task Delete(int id)
        {
            Customer customer = await _customerRepository.GetDefault(x => x.Id == id);
            if (customer != null)
            {
                await _customerRepository.Delete(customer);
            }
        }

        public async Task<UpdateCustomerDTO> GetById(int id)
        {
            Customer customer = await _customerRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<UpdateCustomerDTO>(customer);
        }

        public async Task<bool> Update(UpdateCustomerDTO model)
        {
            Customer customer = await _customerRepository.GetDefault(x => x.Id == model.Id);
            Customer updatedCustomer = _mapper.Map<Customer>(model);
            updatedCustomer.CreatedAt = customer.CreatedAt;
            updatedCustomer.UpdatedAt = DateTime.Now;
            return await _customerRepository.Update(updatedCustomer);
        }

        public async Task<List<CustomerVM>> GetAllCustomers()
        {
            var customers = await _customerRepository.GetFilteredList(
              select: x => new CustomerVM()
              {
                  Id = x.Id,
                  FullName = x.FirstName + " " + x.LastName,
                  Email = x.Email,
                  RegionId = x.RegionId

              },
              where: null!,
              orderby: x => x.OrderByDescending(x => x.FirstName)
              );

            return customers;
        }
    }
}
