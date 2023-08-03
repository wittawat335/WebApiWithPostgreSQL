using Core.Domain.Entities;
using Core.Domain.RepositoryContracts;
using Core.DTOs;
using Core.Models;
using Core.Services.Contracts;
using Core.Utilities;
using Infrastructure.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{//
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAddressService _service;

        public HomeController(IAddressService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(AddressDTO model)
        {
            return Ok(await _service.Add(model));
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(AddressDTO model)
        {
            return Ok(await _service.Update(model));
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
