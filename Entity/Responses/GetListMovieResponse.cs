namespace Entity.Responses;

public class GetListMovieResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public short YearOfPublication { get; set; }
    public short Duration { get; set; }
    public short ImdbScore { get; set; }
    public int DirectorId { get; set; }
    public GetMovieDirectorResponse Director { get; set; }
    public DateTime CreatedDate { get; set; }
}
