using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using MediatR;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommand : IRequest<CreatedModelResponse>, IIntervalRequest, ILoggableRequest
{
    public int BrandId { get; set; }
    public string Name { get; set; }
    public int Interval => 1;
}
