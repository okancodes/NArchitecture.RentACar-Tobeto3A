using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Update;

public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, UpdatedModelResponse>
{
    private readonly IModelRepository _repository;
    private readonly IMapper _mapper;

    public UpdateModelCommandHandler(IModelRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdatedModelResponse> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        Model model = await _repository.GetAsync(x => x.Id == request.Id);
        _mapper.Map(request, model);
        await _repository.UpdateAsync(model);
        UpdatedModelResponse response = _mapper.Map<UpdatedModelResponse>(model);
        return response;
    }
}
