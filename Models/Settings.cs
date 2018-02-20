using Microsoft.Extensions.Configuration;

namespace ApiEstudiante.Models
{
    public class Settings
    {

        public string ConectionString { get; set; }
        public string Database { get; set; }
        public IConfigurationRoot configuration { get; set; }

    }
}