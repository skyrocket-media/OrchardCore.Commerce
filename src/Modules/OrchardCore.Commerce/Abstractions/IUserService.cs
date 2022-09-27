using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using OrchardCore.Users.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OrchardCore.Commerce.Abstractions;

/// <summary>
/// A service for managing user properties.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Returns the user associated with the <paramref name="claimsPrincipal"/>, but only if it's a <see cref="User"/>.
    /// </summary>
    Task<User> GetFullUserAsync(ClaimsPrincipal claimsPrincipal);

    /// <summary>
    /// Alters the JSON of a custom user setting content item and saves the result. If the setting doesn't exist for the
    /// user then also creates it.
    /// </summary>
    Task AlterUserSettingAsync(User user, string contentType, Func<JObject, JObject> updateContentItemJson);
}

public static class UserServiceExtensions
{
    public static Task<User> GetCurrentFullUserAsync(this IUserService service, IHttpContextAccessor hca) =>
        hca.HttpContext?.User is { } user &&
        hca.HttpContext.User.Identity?.IsAuthenticated == true
            ? service.GetFullUserAsync(user)
            : Task.FromResult<User>(null);
}
