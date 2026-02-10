namespace AutoManage.Models.DTOs;

public record CreateAddressDTO(
    string CEP,
    string State,
    string City,
    string Neighborhood,
    string Street,
    string Number,
    string? Complement,
    int OwnerId
);
