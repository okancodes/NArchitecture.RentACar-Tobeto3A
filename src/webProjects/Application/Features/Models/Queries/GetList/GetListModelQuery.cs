using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Queries.GetList;

public class GetListModelQuery : IRequest<List<GetListedModelResponse>>
{
    public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, List<GetListedModelResponse>>
    {
        private readonly IModelRepository _ModelRepository;
        private readonly IMapper _mapper;

        public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _ModelRepository = modelRepository;
            _mapper = mapper;
        }
        public async Task<List<GetListedModelResponse>> Handle(GetListModelQuery request, CancellationToken cancellationToken)
        {
            List<Model> Model = await _ModelRepository.GetAllAsync();
            List<GetListedModelResponse> response = _mapper.Map<List<GetListedModelResponse>>(Model);
            return response;
        }
    }
}

