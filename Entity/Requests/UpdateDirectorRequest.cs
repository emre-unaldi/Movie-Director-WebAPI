namespace Entity.Requests;

public class UpdateDirectorRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PlaceOfBirth { get; set; }
    public string Country { get; set; }
}
