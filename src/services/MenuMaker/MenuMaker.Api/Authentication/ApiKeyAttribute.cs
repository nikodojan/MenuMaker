using Microsoft.AspNetCore.Mvc;

namespace MenuMaker.Api.Authentication;

public class ApiKeyAttribute : ServiceFilterAttribute
{
    public ApiKeyAttribute() : base(typeof(ApiKeyAuthorizationFilter))
    {
    }
}
