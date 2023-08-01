using Core.Domain.Entities;
using Core.Domain.RepositoryContracts;
using Core.Models;
using Core.Services.Contracts;
using Core.Utilities;
using Infrastructure.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
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
    }
}
