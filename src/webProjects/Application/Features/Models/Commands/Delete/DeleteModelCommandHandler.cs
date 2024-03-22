using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Delete;

public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, DeletedModelResponse>
{
    private readonly IModelRepository _repository;
    private readonly IMapper _mapper;

    public DeleteModelCommandHandler(IModelRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<DeletedModelResponse> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        Model model = await _repository.GetAsync(x=>x.Id == request.Id);
        _mapper.Map(request, model);
        Model deletedModel = await _repository.DeleteAsync(model);
        DeletedModelResponse response = _mapper.Map<DeletedModelResponse>(deletedModel);
        return response;
    }
}
