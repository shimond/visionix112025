namespace MyFirstWebApi.Models.Dtos;

public record ProductDto(Guid Id , string Name, decimal Price, string Description);
