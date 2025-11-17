namespace UseConfiguration.Model.Config;

public record RedisConfiguration
{
    public required string UserName { get; init; }
    public required string Password { get; init; }
    public string[] AllowIps { get; init; } = new string[0];
    public int DefaultPort { get; init; }
    public bool UseSsl { get; init; }
}
