using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SwapiApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapiApp.Test
{
    internal class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            var collection = new ServiceCollection();
            collection.AddPooledDbContextFactory<DataContext>(opt => opt.UseInMemoryDatabase(databaseName: "People"));

            var serviceProvider = collection.BuildServiceProvider();

            this.ContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<DataContext>>();
        }

        public void Dispose()
        {
            //nothing.
        }

        public IDbContextFactory<DataContext> ContextFactory { get; private set; }
    }
}
