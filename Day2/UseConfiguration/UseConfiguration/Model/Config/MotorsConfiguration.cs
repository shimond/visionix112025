namespace UseConfiguration.Model.Config;

public record MotorsConfiguration
{
    public Motor[] Motors { get; init; } = Array.Empty<Motor>();
}

public record Motor
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Type { get; init; }
    public int MaxSpeed { get; init; }
    public int Power { get; init; }
    public string Manufacturer { get; init; } = string.Empty;
    public bool IsActive { get; init; }
}
