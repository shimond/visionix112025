using System.Text.Json;
using UseConfiguration.Model.Config;

namespace UseConfiguration.Services;

public class VxConfigurationManager
{
    public async Task UpdateName(string id, string name)
    {
        var filePath = Path.Combine("motors.json");
        var json = await File.ReadAllTextAsync(filePath);
        var motorsConfig = JsonSerializer.Deserialize<MotorsConfiguration>(json);
        if (motorsConfig == null)
        {
            throw new InvalidOperationException("Failed to deserialize motors configuration.");
        }
        var motor = motorsConfig.Motors.FirstOrDefault(m => m.Id == id);
        if (motor == null)
        {
            throw new InvalidOperationException(
                $"Motor with ID {id} not found.");
        }
        
        var updatedMotor = motor with { Name = name };
        
        var updatedMotors = motorsConfig.Motors
             .Select(m => m.Id == id ? updatedMotor : m)
             .ToArray();
     
        var updatedConfig = new MotorsConfiguration
        {
            Motors = updatedMotors
        };
        
        var updatedJson = JsonSerializer.Serialize(updatedConfig, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        
        await File.WriteAllTextAsync(filePath, updatedJson);
    }
}
