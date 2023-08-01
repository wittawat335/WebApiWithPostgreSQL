using Core.Domain.Entities;
using Core.Domain.RepositoryContracts;
using Core.Models;
using Core.Services.Contracts;
using Core.Utilities;

namespace Core.Services
{
    public class AddressService : IAddressService
    {
        private readonly IGenericRepository<address> _repository;

        public AddressService(IGenericRepository<address> repository)
        {
            _repository = repository;
        }

        public Response<List<address>> GetAll()
        {
            var response = new Response<List<address>>();
            try
            {
                var model = _repository.AsQueryable();

                response.Value = model.ToList();
                if (response.Value.Count() > 0)
                {
                    response.Status = Constants.StatusData.True;
                    response.Message = Constants.Msg.GetList;
                }
                else
                {
                    response.Status = Constants.StatusData.False;
                    response.Message = Constants.Msg.NoRecord;
                }
            }
            catch (Exception ex)
            {
                response.Status = Constants.StatusData.False;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
