namespace AutoManage.Models;

// We need to have a base interface with at least an argument (Id is just the only common one across every model)
// Because otherwise we could have any class be passsed to "T" in IBaseService, BaseService and BaseController
public interface IEntity
{
    int Id { get; set; }
}