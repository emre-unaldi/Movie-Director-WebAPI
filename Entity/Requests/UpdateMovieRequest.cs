namespace Entity.Requests;

public class UpdateMovieRequest
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Type { get; set; }
    public short YearOfPublication { get; set; }
    public short Duration { get; set; }
    public short ImdbScore { get; set; }
    public int DirectorId { get; set; }
}
