using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;

        public LogService(ILogRepository logRepository, IMapper mapper)
        {
            _logRepository = logRepository;
            _mapper = mapper;
        }


        public TResponseModel Add<TRequestModel, TResponseModel, TValidator>(TRequestModel requestModel)
            where TValidator : AbstractValidator<Log>
            where TRequestModel : class
            where TResponseModel : class
        {
            Log entity = _mapper.Map<Log>(requestModel);

            Validate(entity, Activator.CreateInstance<TValidator>());
            _logRepository.Insert(entity);

            TResponseModel responseModel = _mapper.Map<TResponseModel>(entity);

            return responseModel;
        }

        public void Delete(int id) => _logRepository.Delete(id);


        public IEnumerable<TResponseModel> Get<TResponseModel>() where TResponseModel : class
        {
            var entities = _logRepository.Select();

            var responseModels = entities.Select(s => _mapper.Map<TResponseModel>(s));

            return responseModels;
        }

        public TResponseModel GetById<TResponseModel>(int id) where TResponseModel : class
        {
            var entity = _logRepository.Select(id);

            var responseModels = _mapper.Map<TResponseModel>(entity);

            return responseModels;
        }


        public TResponseModel Update<TRequestModel, TResponseModel, TValidator>(TRequestModel inputModel)
            where TValidator : AbstractValidator<Log>
            where TRequestModel : class
            where TResponseModel : class
        {
            Log entity = _mapper.Map<Log>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());
            _logRepository.Update(entity);

            TResponseModel responseModels = _mapper.Map<TResponseModel>(entity);

            return responseModels;
        }

        private void Validate(Log obj, AbstractValidator<Log> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
