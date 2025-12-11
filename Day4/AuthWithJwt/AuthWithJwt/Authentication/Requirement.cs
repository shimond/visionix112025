using Microsoft.AspNetCore.Authorization;

namespace AuthWithJwt.Authentication;

public class FileBasedAuthenticationRequirement(string filePath) : IAuthorizationRequirement
{
    public string FilePath
    {
        get
        {
            return filePath;
        }
    }
}

public class FileBasedAuthenticationHandler : AuthorizationHandler<FileBasedAuthenticationRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        FileBasedAuthenticationRequirement requirement)
    {

        bool isAuthRequired = false;

        if (File.Exists(requirement.FilePath))
        {
            string fileContent = File.ReadAllText(requirement.FilePath).Trim();
            bool.TryParse(fileContent, out isAuthRequired);
        }

        if (!isAuthRequired || (isAuthRequired && context.User.Identity != null && context.User.Identity.IsAuthenticated))
        {
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }
}
