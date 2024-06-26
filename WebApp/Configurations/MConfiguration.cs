using ClassLibraryUtilities.Contracts;

namespace WebApp.Configurations
{
    public class MConfiguration : IMConfiguration
    {
        private readonly IConfiguration _configuration;

        public MConfiguration(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string GetClienteStrCon()
        {
            return _configuration.GetSection("ConnectionStrings:ClienteDB").Value.ToString();
        }
    }
}