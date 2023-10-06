using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController
    {
        private readonly IConfiguration _configuration;
        private readonly EmailDomainsForUsername _options;

        public TestController(IConfiguration configuration, IOptions<EmailDomainsForUsername> options)
        {
            _configuration = configuration;
            _options = options.Value;
        }

        [HttpGet]
        public void TestGet()
        {
            var cTemplateWorkflow = _options.cTemplateWorkflow;
            var defaultTemplateWorkflow = _options.defaultTemplateWorkflow;
        }
    }
}