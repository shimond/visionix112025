
using Microsoft.Extensions.Options;
using UseConfiguration.Model.Config;

namespace UseConfiguration.Services;

public class HostedServiceEx(IOptionsMonitor<MotorsConfiguration> optionsMonitor) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        optionsMonitor.OnChange(config =>
        {
            Console.WriteLine("Motors configuration has changed");
        });
        DoTheProcess();
        return Task.CompletedTask;
    }


    async void DoTheProcess()
    {
        while (true)
        {
            await Task.Delay(10000);
            Console.WriteLine("Wait for changes");
        }
    }


    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
