
namespace AutoManage.Models;

public class Salesperson : IEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required decimal Salary { get; set; }
    public ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
}
