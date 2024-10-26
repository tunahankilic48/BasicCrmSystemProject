using AutoMapper;
using BasicCrmSystem_Application.Models.DTOs;
using BasicCrmSystem_Domain.Entities;

namespace BasicCrmSystem_Application.Mapping
{
    internal class Mapping : Profile
    {
        public Mapping() {
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDTO>().ReverseMap();

        }
    }
}
