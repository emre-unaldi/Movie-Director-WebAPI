namespace Entity.Entities;

public class Director : BaseEntity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PlaceOfBirth { get; set; }
    public string Country { get; set; }

    public virtual ICollection<Movie> Movies { get; set; }

    public Director()
    {
        Movies = new HashSet<Movie>();
    }

    public Director(int id, string firstName, string lastName, string placeOfBirth, string country) : this()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PlaceOfBirth = placeOfBirth;
        Country = country;
    }
}
