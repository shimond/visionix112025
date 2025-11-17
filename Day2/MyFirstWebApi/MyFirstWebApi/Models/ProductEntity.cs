namespace MyFirstWebApi.Models;

public record CategoryEntity(Guid Id, string Name, decimal Price, string Description) {

    public List<ProductEntity> Products { get; init; } = new List<ProductEntity>();
};

public record ProductEntity(Guid Id, string Name, decimal Price, string Description, Guid? CategoryId = null)
{
    public CategoryEntity? Category { get; init; } 

}
