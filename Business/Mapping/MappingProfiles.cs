using AutoMapper;
using Entity.Entities;
using Entity.Requests;
using Entity.Responses;

namespace Business.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Director, AddDirectorRequest>().ReverseMap();
        CreateMap<Director, UpdateDirectorRequest>().ReverseMap();
        CreateMap<Director, GetListDirectorResponse>().ReverseMap();
        CreateMap<Director, GetMovieDirectorResponse>().ReverseMap();
        CreateMap<Director, AddDirectorResponse>().ReverseMap();
        CreateMap<Director, UpdateDirectorResponse>().ReverseMap();

        CreateMap<Movie, AddMovieRequest>().ReverseMap();
        CreateMap<Movie, UpdateMovieRequest>().ReverseMap();
        CreateMap<Movie, GetListMovieResponse>().ReverseMap();
        CreateMap<Movie, GetDirectorMovieResponse>().ReverseMap();
        CreateMap<Movie, AddMovieResponse>().ReverseMap();
        CreateMap<Movie, UpdateMovieResponse>().ReverseMap();
    }
}
