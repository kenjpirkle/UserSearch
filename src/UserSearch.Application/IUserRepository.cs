using UserSearch.Domain;

namespace UserSearch.Application;

public interface IUserRepository
{
    Task<IReadOnlyList<User>> FindUsers(string searchTerm);
    Task<IReadOnlyList<User>> FindUsersByFullName(string firstName, string secondName);
}