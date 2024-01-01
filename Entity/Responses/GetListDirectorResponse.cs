namespace Entity.Responses;

public class GetListDirectorResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PlaceOfBirth { get; set; }
    public string Country { get; set; }
    public List<GetDirectorMovieResponse> Movies { get; set; }
    public DateTime CreatedDate { get; set; }
}
