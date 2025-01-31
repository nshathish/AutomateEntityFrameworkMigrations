namespace Infrastructure.Entities;

public class Job
{
    public int Id { get; set; }
    public string JobName { get; set; } = null!;

    public int OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;
}