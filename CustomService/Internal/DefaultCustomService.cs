using Microsoft.Extensions.Options;

namespace TestServiceCollection.CustomService
{
    internal class DefaultCustomService : ICustomService
    {
        private readonly CustomServiceOptions _options;

        public DefaultCustomService(IOptions<CustomServiceOptions> customServiceOptions)
        {
            _options = customServiceOptions.Value;
        }

        public string GetOption1()
        {
            return _options.Option1;
        }
    }
}