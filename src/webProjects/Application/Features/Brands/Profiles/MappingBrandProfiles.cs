using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetListDynamic;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Profiles;

public class MappingBrandProfiles:Profile
{
    public MappingBrandProfiles()
    {
        CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
        CreateMap<Brand, UpdateBrandCommand>().ReverseMap();

        CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
        CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();
        CreateMap<Brand, GetListedBrandResponse>().ReverseMap();
        CreateMap<Brand, DeletedBrandResponse>().ReverseMap();
        CreateMap<Brand, UpdatedBrandResponse>().ReverseMap();

        CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
    }
}
