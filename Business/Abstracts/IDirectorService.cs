using Core.Utilities.Results.Abstracts;
using Entity.Requests;
using Entity.Responses;

namespace Business.Abstracts;

public interface IDirectorService
{
    Task<IDataResult<AddDirectorResponse>> Add(AddDirectorRequest addDirectorRequest);
    Task<IDataResult<UpdateDirectorResponse>> Update(UpdateDirectorRequest updateDirectorRequest);
    Task<IResult> Delete(int directorId);
    Task<IDataResult<List<GetListDirectorResponse>>> GetList();
    Task<IDataResult<GetListDirectorResponse>> GetDirectorById(int directorId);
}
