using AutoMapper;
using Core.Domain.Entities;
using Core.Domain.RepositoryContracts;
using Core.DTOs;
using Core.Models;
using Core.Services.Contracts;
using Core.Utilities;

namespace Core.Services
{
    public class AddressService : IAddressService
    {
        private readonly IGenericRepository<address> _repository;
        private readonly IMapper _mapper;

        public AddressService(IGenericRepository<address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
       
        public async Task<Response<address>> GetById(int id)
        {
            var response = new Response<address>();
            try
            {
                response.Value = await _repository.GetAsync(x => x.address_id == id);
                if (response.Value != null)
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
                response.Message = ex.Message;
            }

            return response;
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
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response> Add(AddressDTO model)
        {
            var response = new Response();
            try
            {
                _repository.Add(_mapper.Map<address>(model));
                await _repository.SaveChangesAsync();
                response.Status = Constants.StatusData.True;
                response.Message = Constants.Msg.InsertComplete;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response> Update(AddressDTO model)
        {
            var response = new Response();
            try
            {
                var findId = await _repository.GetAsync(x => x.address_id == model.address_id);
                if(findId != null)
                {
                    _repository.Update(_mapper.Map(model, findId));
                    await _repository.SaveChangesAsync();
                    response.Status = Constants.StatusData.True;
                    response.Message = Constants.Msg.InsertComplete;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response> Delete(int id)
        {
            var response = new Response();
            try
            {
                _repository.Delete(await _repository.GetAsync(x => x.address_id == id));
                await _repository.SaveChangesAsync();
                response.Status = Constants.StatusData.True;
                response.Message = Constants.Msg.InsertComplete;
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
