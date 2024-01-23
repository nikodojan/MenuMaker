using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MenuMaker.Api.Authentication;

public class ApiKeyAuthorizationFilter : IAuthorizationFilter
{
    private readonly IConfiguration _configuration;

    public ApiKeyAuthorizationFilter(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string apiKeyHeader = context.HttpContext.Request.Headers[Constants.ApiKeyHeaderName]!;

        if (!IsValid(apiKeyHeader))
        {
            context.Result = new UnauthorizedResult();
        }
        
    }

    private bool IsValid(string? apiKeyHeader)
    {
        if (string.IsNullOrWhiteSpace(apiKeyHeader))
        {
            return false;
        }

        var apiKey = _configuration.GetValue<string>(Constants.ApiKeySettingName);

        if (apiKeyHeader == apiKey || apiKey == null)
        {
            return true;
        }

        return false;
    }
}