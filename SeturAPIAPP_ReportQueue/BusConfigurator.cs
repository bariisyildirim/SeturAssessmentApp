using MassTransit;
using MassTransit.RabbitMqTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturAPIAPP_ReportQueue
{
    public static class BusConfigurator
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(factory =>
            {
                factory.Host("localhost","/", configurator =>
                {
                    configurator.Username("guest");
                    configurator.Password("guest");
                });
             

                registrationAction?.Invoke(factory);
            });
        }
    }
}

