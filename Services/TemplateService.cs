using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Template.Services.Interfaces;
using Template.Services.Options;

namespace Template.Services
{
    public class TemplateService(ILogger<TemplateService> logger, IOptions<TemplateOptions> opt): ITemplateService
    {
        private readonly TemplateOptions _options = opt.Value;

        public async Task TemplateServiceMethod()
        {
            logger.LogInformation("Option1 value: {Option1}", _options.Option1);
            logger.LogInformation("Option1 value: {Option2}", _options.Option2);
            await Task.Delay(100);
        }
    }
}