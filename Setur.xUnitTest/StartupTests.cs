using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Setur.APIApp;
using Setur.Business.Services;
using Setur.Data.Models;
using Setur.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Setur.xUnitTest
{
    public class  StartupTests
    {

    [Fact]
    public void StartupTest()
    {
        var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
        Assert.NotNull(webHost);
        Assert.NotNull(webHost.Services.GetRequiredService<IPersonService>());
        Assert.NotNull(webHost.Services.GetRequiredService<IPersonRepository>());
        Assert.NotNull(webHost.Services.GetRequiredService<IPersonDatabaseSettings>());

    }
}
}
