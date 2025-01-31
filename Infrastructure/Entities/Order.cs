using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class Order
{
    public int Id { get; set; }
    [MaxLength(500)] public string OrderName { get; set; } = null!;
    [MaxLength(3000)] public string? OrderDescription { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}