using Core.Domain.Entities;
using Core.Models;
using System;

namespace Core.Services.Contracts
{
    public interface IAddressService
    {
        Response<List<address>> GetAll();
    }
}
