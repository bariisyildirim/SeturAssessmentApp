using MassTransit;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace SeturAPIAPP_ReportQueue
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var bus = BusConfigurator.ConfigureBus(factory =>
            {
                factory.ReceiveEndpoint("request-report", endpoint =>
                {
                    endpoint.Consumer<ReportConsumer>();
                });
            });

            await bus.StartAsync();
            await Task.Run(() => Console.ReadLine());
            await bus.StopAsync();
        }

    }
}
