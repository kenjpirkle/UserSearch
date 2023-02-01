using UserSearch.Domain;

namespace UserSearch.Application;

public interface IUserMapper
{
    public UserDto From(User user);
}

public sealed class UserMapper : IUserMapper
{
    public UserDto From(User user)
        => new()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Gender = user.Gender,
        };
}