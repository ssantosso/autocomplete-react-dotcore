using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using Xunit;

namespace Autocomplete.Test.Config
{
    [CollectionDefinition(nameof(IntegrationWebTestsFixtureCollections))]
    public class IntegrationWebTestsFixtureCollections : ICollectionFixture<IntegrationTestsFixture<Startup>> { }
    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public IntegrationTestsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {

            };
            Factory = new AutoCompleateFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }

        public readonly AutoCompleateFactory<TStartup> Factory;
        public HttpClient Client;

        public void Dispose()
        {
            Client?.Dispose();
            Factory?.Dispose();
        }
    }
}
