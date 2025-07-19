using Microsoft.Extensions.Configuration;
using TickTickSharp.Client;

namespace TickTickSharp.Tests
{
    public abstract class TestBase : IDisposable
    {
        protected readonly TickTickClient Client;
        protected readonly IConfiguration Configuration;

        protected TestBase()
        {
            // Build configuration with user secrets
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<TestBase>()
                .Build();

            var accessToken = Configuration["TickTick:AccessToken"];
        
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new InvalidOperationException(
                    "TickTick access token is required. Set it using:\n" +
                    "dotnet user-secrets set \"TickTick:AccessToken\" \"your_token_here\" --project TickTickSharp.Tests\n" +
                    "Or set the TICKTICK_ACCESS_TOKEN environment variable");
            }

            Client = new TickTickClient(accessToken);
        }

        public virtual void Dispose()
        {
            Client?.Dispose();
        }
    }
}