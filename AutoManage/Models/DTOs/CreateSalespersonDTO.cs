// This one isnt necessary yet but it will be if we ever add new relationships and it's good to keep the pattern
namespace AutoManage.Models.DTOs;
public record CreateSalespersonDTO(
    string Name,
    decimal Salary
);
