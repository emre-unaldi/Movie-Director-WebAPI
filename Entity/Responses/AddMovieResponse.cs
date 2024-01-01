namespace Entity.Responses;

public class AddMovieResponse
{
    public string Name { get; set; }
    public string Type { get; set; }
    public short YearOfPublication { get; set; }
    public short Duration { get; set; }
    public short ImdbScore { get; set; }
    public Guid DirectorId { get; set; }
    public DateTime CreatedDate { get; set; }
}
