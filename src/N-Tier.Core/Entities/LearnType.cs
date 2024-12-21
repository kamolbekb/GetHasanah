namespace N_Tier.Core.Entities;

public class LearnType
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Navigation property
    public ICollection<Issue> Issues { get; set; }
}