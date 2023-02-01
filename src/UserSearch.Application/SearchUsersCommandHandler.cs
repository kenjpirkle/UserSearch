using Mediator;
using Microsoft.Extensions.Logging;

namespace UserSearch.Application;

public sealed record SearchUsersCommand(string SearchTerm) : ICommand<IEnumerable<UserDto>>;

public sealed class SearchUsersCommandHandler : ICommandHandler<SearchUsersCommand, IEnumerable<UserDto>>
{
    private readonly ILogger<SearchUsersCommandHandler> _logger;
    private readonly IUserRepository _userRepository;
    private readonly IUserMapper _userMapper;

    public SearchUsersCommandHandler(ILogger<SearchUsersCommandHandler> logger, IUserRepository userRepository, IUserMapper userMapper)
    {
        _logger = logger;
        _userRepository = userRepository;
        _userMapper = userMapper;
    }

    public async ValueTask<IEnumerable<UserDto>> Handle(SearchUsersCommand searchUsersCommand, CancellationToken cancellationToken)
    {
        var searchTerms = searchUsersCommand.SearchTerm
            .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        return searchTerms.Length switch
        {
            1 => (await _userRepository.FindUsers(searchTerms[0])).Select(user => _userMapper.From(user)),
            2 => (await _userRepository.FindUsersByFullName(searchTerms[0], searchTerms[1])).Select(user =>
                _userMapper.From(user)),
            _ => Enumerable.Empty<UserDto>()
        };
    }
}