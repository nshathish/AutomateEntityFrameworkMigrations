namespace Infrastructure.Entities;

public class Order
{
    public int Id { get; set; }
    public string OrderName { get; set; } = null!;
    public string? OrderDescription { get; set; }

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

}