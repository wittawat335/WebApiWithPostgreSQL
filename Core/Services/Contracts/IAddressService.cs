using Core.Domain.Entities;
using Core.DTOs;
using Core.Models;
using System;

namespace Core.Services.Contracts
{
    public interface IAddressService
    {
        Response<List<address>> GetAll();
        Task<Response<address>> GetById(int id);
        Task<Response> Add(AddressDTO model);
        Task<Response> Update(AddressDTO model);
        Task<Response> Delete(int id);
    }
}
