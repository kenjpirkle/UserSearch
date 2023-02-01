using Microsoft.Extensions.Logging;
using UserSearch.Application;
using UserSearch.Domain;

namespace UserSearch.Infrastructure;

public sealed class UserRepository : IUserRepository
{
    private readonly ILogger<UserRepository> _logger;
    
    public UserRepository(ILogger<UserRepository> logger)
    {
        _logger = logger;
        using var userContext = new UserContext();
        userContext.Database.EnsureCreated();
    }

    public Task<IReadOnlyList<User>> FindUsers(string searchTerm)
    {
        using var userContext = new UserContext();
        var result = userContext.Users.Where(user =>
                user.FirstName.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase) ||
                user.LastName.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase) ||
                user.Email.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase))
            .ToArray();

        return Task.FromResult((IReadOnlyList<User>) result);
    }

    public Task<IReadOnlyList<User>> FindUsersByFullName(string firstName, string secondName)
    {
        using var userContext = new UserContext();
        var result = userContext.Users.Where(user =>
                user.FirstName.Contains(firstName, StringComparison.InvariantCultureIgnoreCase) &&
                user.LastName.Contains(secondName, StringComparison.InvariantCultureIgnoreCase))
            .ToArray();

        return Task.FromResult((IReadOnlyList<User>)result);
    }
}