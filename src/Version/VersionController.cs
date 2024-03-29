using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Seguradora.Version
{
    [Route("api/[controller]")]
    public class VersionController : Controller
    {
        private readonly AppConfig _config;

        public VersionController(IOptions<AppConfig> options)
        {
            _config = options.Value;

        }

        [HttpGet]
        public string Version()
        {
            return _config.Version;
        }
    }
}