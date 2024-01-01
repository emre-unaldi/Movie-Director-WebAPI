namespace Entity.Requests;

public class AddMovieRequest
{
    public string Name { get; set; }
    public string Type { get; set; }
    public short YearOfPublication { get; set; }
    public short Duration { get; set; }
    public short ImdbScore { get; set; }
    public int DirectorId { get; set; }
}
