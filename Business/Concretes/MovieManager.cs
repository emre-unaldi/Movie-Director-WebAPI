using AutoMapper;
using Business.Abstracts;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Repositories.Abstracts;
using Entity.Entities;
using Entity.Requests;
using Entity.Responses;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class MovieManager : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public MovieManager(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<AddMovieResponse>> Add(AddMovieRequest addMovieRequest)
    {
        try
        {
            Movie movie = _mapper.Map<Movie>(addMovieRequest);
            await _movieRepository.AddAsync(movie);

            AddMovieResponse addedMovie = _mapper.Map<AddMovieResponse>(movie);
            return new SuccessDataResult<AddMovieResponse>(addedMovie, "Movie added successfly");
        }
        catch (Exception exception)
        {
            return new ErrorDataResult<AddMovieResponse>(exception.Message);
        } 
    }

    public async Task<IDataResult<UpdateMovieResponse>> Update(UpdateMovieRequest updateMovieRequest)
    {
        try
        {
            Movie movie = _mapper.Map<Movie>(updateMovieRequest);
            await _movieRepository.UpdateAsync(movie);

            UpdateMovieResponse updatedMovie = _mapper.Map<UpdateMovieResponse>(movie);
            return new SuccessDataResult<UpdateMovieResponse>(updatedMovie, "Movie updated successfly");
        }
        catch (Exception exception)
        {
            return new ErrorDataResult<UpdateMovieResponse>(exception.Message);
        }
    }

    public async Task<IResult> Delete(int movieId)
    {
        try
        {
            Movie? movie = await _movieRepository.GetAsync(predicate: movie => movie.Id == movieId);
            await _movieRepository.DeleteAsync(movie);

            return new SuccessResult("Movie deleted succesfly");
        }
        catch (Exception exception)
        {
            return new ErrorResult(exception.Message);
        }
    }

    public async Task<IDataResult<List<GetListMovieResponse>>> GetList()
    {
        try
        {
            List<Movie> movieList = await _movieRepository.GetListAsync(include: movie => movie.Include(movie => movie.Director));
            List<GetListMovieResponse> movies = _mapper.Map<List<GetListMovieResponse>>(movieList);

            return new SuccessDataResult<List<GetListMovieResponse>>(movies, "Movies listed successfully");
        } catch (Exception exception)
        {
            return new ErrorDataResult<List<GetListMovieResponse>>(exception.Message);
        }
    }

    public async Task<IDataResult<GetListMovieResponse>> GetMovieById(int movieId)
    {
        try
        {
            Movie? getMovie = await _movieRepository.GetAsync(
                predicate: movie => movie.Id == movieId, 
                include: movie => movie.Include(movie => movie.Director)
            );
            GetListMovieResponse? movie = _mapper.Map<GetListMovieResponse>(getMovie);

            return new SuccessDataResult<GetListMovieResponse>(movie, "Movie listed successfully");
        }
        catch (Exception exception)
        {
            return new ErrorDataResult<GetListMovieResponse>(exception.Message);
        }
    }
}
