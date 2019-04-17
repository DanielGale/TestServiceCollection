using System;
using Microsoft.Extensions.Options;

namespace TestServiceCollection.CustomService
{
    internal class CustomServiceOptionsSetup : IConfigureOptions<CustomServiceOptions>
    {
        public CustomServiceOptionsSetup()
        {

        }
        public void Configure(CustomServiceOptions options)
        {
            if(options == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}