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

public class DirectorManager : IDirectorService
{
    private readonly IDirectorRepository _directorRepository;
    private readonly IMapper _mapper;

    public DirectorManager(IDirectorRepository directorRepository, IMapper mapper)
    {
        _directorRepository = directorRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<AddDirectorResponse>> Add(AddDirectorRequest addDirectorRequest)
    {
        try
        {
            Director director = _mapper.Map<Director>(addDirectorRequest);
            await _directorRepository.AddAsync(director);

            AddDirectorResponse addedDirector = _mapper.Map<AddDirectorResponse>(director);
            return new SuccessDataResult<AddDirectorResponse>(addedDirector, "Director added successfly");
        }
        catch (Exception exception)
        {
            return new ErrorDataResult<AddDirectorResponse>(exception.Message);
        }
    }
    public async Task<IDataResult<UpdateDirectorResponse>> Update(UpdateDirectorRequest updateDirectorRequest)
    {
        try
        {
            Director director = _mapper.Map<Director>(updateDirectorRequest);
            await _directorRepository.UpdateAsync(director);

            UpdateDirectorResponse updatedDirector = _mapper.Map<UpdateDirectorResponse>(director);
            return new SuccessDataResult<UpdateDirectorResponse>(updatedDirector, "Director updated successfly");
        }
        catch (Exception exception)
        {
            return new ErrorDataResult<UpdateDirectorResponse>(exception.Message);
        }
    }

    public async Task<IResult> Delete(int directorId)
    {
        try
        {
            Director? director = await _directorRepository.GetAsync(predicate: director => director.Id == directorId);
            await _directorRepository.DeleteAsync(director);

            return new SuccessResult("Director deleted succesfly");
        }
        catch (Exception exception)
        {
            return new ErrorResult(exception.Message);
        }
    }
    public async Task<IDataResult<List<GetListDirectorResponse>>> GetList()
    {
        try
        {
            List<Director> directorList = await _directorRepository.GetListAsync(include: director => director.Include(director => director.Movies));
            List<GetListDirectorResponse> directors = _mapper.Map<List<GetListDirectorResponse>>(directorList);

            return new SuccessDataResult<List<GetListDirectorResponse>>(directors, "Directors listed successfully");
        }
        catch (Exception exception)
        {
            return new ErrorDataResult<List<GetListDirectorResponse>>(exception.Message);
        }
    }

    public async Task<IDataResult<GetListDirectorResponse>> GetDirectorById(int directorId)
    {
        try
        {
            Director? directorList = await _directorRepository.GetAsync(
                predicate: director => director.Id == directorId, 
                include: director => director.Include(director => director.Movies)
            );
            GetListDirectorResponse? director = _mapper.Map<GetListDirectorResponse>(directorList);

            return new SuccessDataResult<GetListDirectorResponse>(director, "Director listed successfully");
        }
        catch (Exception exception)
        {
            return new ErrorDataResult<GetListDirectorResponse>(exception.Message);
        }
    }
}
