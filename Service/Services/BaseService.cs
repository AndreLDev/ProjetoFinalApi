using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;

namespace Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public TResponseModel Add<TRequestModel, TResponseModel, TValidator>(TRequestModel requestModel)
            where TValidator : AbstractValidator<TEntity>
            where TRequestModel : class
            where TResponseModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(requestModel);

            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(entity);

            TResponseModel responseModel = _mapper.Map<TResponseModel>(entity);

            return responseModel;
        }

        public void Delete(int id) => _baseRepository.Delete(id);

        public IEnumerable<TResponseModel> Get<TResponseModel>() where TResponseModel : class
        {
            var entities = _baseRepository.Select();

            var responseModels = entities.Select(s => _mapper.Map<TResponseModel>(s));

            return responseModels;
        }

        public TResponseModel GetById<TResponseModel>(int id) where TResponseModel : class
        {
            var entity = _baseRepository.Select(id);

            var responseModels = _mapper.Map<TResponseModel>(entity);

            return responseModels;
        }

        public TResponseModel Update<TRequestModel, TResponseModel, TValidator>(TRequestModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TRequestModel : class
            where TResponseModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(entity);

            TResponseModel responseModels = _mapper.Map<TResponseModel>(entity);

            return responseModels;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
