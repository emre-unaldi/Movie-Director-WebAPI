namespace Entity.Responses;

public class UpdateDirectorResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PlaceOfBirth { get; set; }
    public string Country { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}