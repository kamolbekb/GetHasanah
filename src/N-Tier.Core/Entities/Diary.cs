using N_Tier.Core.Common;

namespace N_Tier.Core.Entities;

public class Diary: BaseEntity
{
    public Guid StudentId { get; set; }
    //public Student Student { get; set; }
    //public ICollection<DiaryRecord> DiaryRecords { get; set; }
}