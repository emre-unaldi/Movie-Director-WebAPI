namespace Entity.Entities;

public class Movie : BaseEntity<int>
{
    public string Name { get; set; }
    public string Type { get; set; }
    public short YearOfPublication { get; set; }
    public short Duration { get; set; }
    public short ImdbScore { get; set; }

    public int DirectorId { get; set; }
    public virtual Director? Director { get; set; }

    public Movie()
    {
        
    }

    public Movie(int id, int directorId, string name, string type, short yearOfPublication, short duration, short ımdbScore) : this()
    {
        Id = id;
        DirectorId = directorId;
        Name = name;
        Type = type;
        YearOfPublication = yearOfPublication;
        Duration = duration;
        ImdbScore = ımdbScore;
    }
}
