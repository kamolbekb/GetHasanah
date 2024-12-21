using System.Text.Json.Serialization;
using N_Tier.Core.Common;
using N_Tier.Core.Enums;

namespace N_Tier.Core.Entities;

public class Employee : BaseEntity
{
    public Guid PersonId { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }
    public DateOnly HireDate { get; set; }
    //public Person Person { get; set; }
    //[JsonIgnore] public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}