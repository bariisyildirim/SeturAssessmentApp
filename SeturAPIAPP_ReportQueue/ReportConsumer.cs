using MassTransit;
using Setur.Entity.Models.MessageQueuing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturAPIAPP_ReportQueue
{
    public class ReportConsumer : IConsumer<ReportMessaging>
    {
        
       
        public async Task Consume(ConsumeContext<ReportMessaging> context)
        {
            var entity = context.Message.ReportStatus;
        }
    }
}
