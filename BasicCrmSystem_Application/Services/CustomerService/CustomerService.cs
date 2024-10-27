using AutoMapper;
using BasicCrmSystem_Application.Models.DTOs;
using BasicCrmSystem_Application.Models.VMs;
using BasicCrmSystem_Domain.Entities;
using BasicCrmSystem_Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace BasicCrmSystem_Application.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, ILogger<Customer> logger) {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Create(CreateCustomerDTO model)
        {
            Customer customer = _mapper.Map<Customer>(model);
            customer.CreatedAt = DateTime.Now;
            bool result = await _customerRepository.Add(customer);
            if (result)
            {
                _logger.LogInformation("Yeni Müşteri Oluşturuldu.", $"Fullname: {model.FirstName} {model.LastName}", $"Email: {model.Email}");
            }
            else
            {
                _logger.LogInformation("Müşteri oluşturulurken hata alındı.", $"Fullname: {model.FirstName} {model.LastName}", $"Email: {model.Email}");
            }
            return result;
        }

        public async Task Delete(int id)
        {
            Customer customer = await _customerRepository.GetDefault(x => x.Id == id);
            if (customer != null)
            {
                bool result = await _customerRepository.Delete(customer);
                if (result)
                {
                    _logger.LogInformation("Müşteri silindi", $"Id: {id}");
                }
                else
                {
                    _logger.LogInformation("Müşteri silinirken hata alındı.", $"Id: {id}");
                }
            }
            else
            {
                _logger.LogInformation("Müşteri bulunamadı", $"Id: {id}");
            }
        }

        public async Task<UpdateCustomerDTO> GetById(int id)
        {
            Customer customer = await _customerRepository.GetDefault(x => x.Id == id);
            _logger.LogInformation("Müşteri bulundu", $"Id: {id}", $"Fullname: {customer.FirstName} {customer.LastName}", $"Email: {customer.Email}");
            return _mapper.Map<UpdateCustomerDTO>(customer);
        }

        public async Task<bool> Update(UpdateCustomerDTO model)
        {
            Customer customer = await _customerRepository.GetDefault(x => x.Id == model.Id);
            Customer updatedCustomer = _mapper.Map<Customer>(model);
            updatedCustomer.CreatedAt = customer.CreatedAt;
            updatedCustomer.UpdatedAt = DateTime.Now;
            bool result = await _customerRepository.Update(updatedCustomer);
            if (result)
            {
                _logger.LogInformation("Müşteri güncellendi.", $"Fullname: {customer.FirstName} {customer.LastName}", $"Email: {customer.Email}");

            }
            else
            {
                _logger.LogInformation("Müşteri güncellenirken hata alındı.", $"Fullname: {customer.FirstName} {customer.LastName}", $"Email: {customer.Email}");

            }
            return result;
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
            _logger.LogInformation("Tüm Müşteriler listelendi.");
            return customers;
        }
    }
}
