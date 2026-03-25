namespace minimal_users_api.Mappings;

using AutoMapper;
using minimal_users_api.Dtos;
using minimal_users_api.Dtos.Responses;
using minimal_users_api.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDTO, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => false))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

        CreateMap<User, CreateUserResponseDTO>()
            .ConstructUsing(src => new CreateUserResponseDTO(src.Id.ToString()));

        CreateMap<List<User>, GetAllUsersResponseDTO>()
            .ConstructUsing(src => new GetAllUsersResponseDTO(src));
    }
}