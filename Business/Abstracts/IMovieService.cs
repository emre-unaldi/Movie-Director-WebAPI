using Core.Utilities.Results.Abstracts;
using Entity.Requests;
using Entity.Responses;

namespace Business.Abstracts;

public interface IMovieService
{
    Task<IDataResult<AddMovieResponse>> Add(AddMovieRequest addMovieRequest);
    Task<IDataResult<UpdateMovieResponse>> Update(UpdateMovieRequest updateMovieRequest);
    Task<IResult> Delete(int movieId);
    Task<IDataResult<List<GetListMovieResponse>>> GetList();
    Task<IDataResult<GetListMovieResponse>> GetMovieById(int movieId);
}
