namespace N_Tier.Core.Entities;

public class Surah
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AyahSize { get; set; }

    // Navigation property
    public ICollection<Issue> Issues { get; set; }
}