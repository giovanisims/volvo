
namespace AutoManage.Model;

public class Salesperson
{
    public int Id {get;set;}
    public string Name {get;set;}
    public decimal Salary {get;set;}
    public List<Sale> Sales {get;set;}
}
// ●​ Vendedores: Id, Nome, SalarioBase.