namespace AutoManage.Models.DTOs;

public record CreateOwnerDTO(
    string Name,
    string CPF_CNPJ,
    string Email,
    string Telephone,
    DateTime? BirthDate,
    string? CNH,
    string? AdditionalInfo
);
