using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;

namespace UserSearch.Application.Tests;

public class SearchUsersCommandHandlerTests
{
    [Fact]
    public async Task Handle_WithSingleWordSearchTerm_SearchesRepository()
    {
        // Arrange
        var userRepository = Substitute.For<IUserRepository>();
        var sut = new SearchUsersCommandHandler(new NullLogger<SearchUsersCommandHandler>(), userRepository,
            new UserMapper());

        // Act
        var searchUsersCommand = new SearchUsersCommand("James");
        var result = await sut.Handle(searchUsersCommand, CancellationToken.None);

        // Assert
        await userRepository.Received(1).FindUsers(Arg.Any<string>());
    }
    
    [Fact]
    public async Task Handle_WithTwoWordsSearchTerm_SearchesRepositoryByFullName()
    {
        // Arrange
        var userRepository = Substitute.For<IUserRepository>();
        var sut = new SearchUsersCommandHandler(new NullLogger<SearchUsersCommandHandler>(), userRepository,
            new UserMapper());

        // Act
        var searchUsersCommand = new SearchUsersCommand("Katey Soltan");
        var result = await sut.Handle(searchUsersCommand, CancellationToken.None);

        // Assert
        await userRepository.Received(1).FindUsersByFullName(Arg.Any<string>(), Arg.Any<string>());
    }
    
    [Fact]
    public async Task Handle_WithInvalidSearchTermCount_ReturnsNoResults()
    {
        // Arrange
        var userRepository = Substitute.For<IUserRepository>();
        var sut = new SearchUsersCommandHandler(new NullLogger<SearchUsersCommandHandler>(), userRepository,
            new UserMapper());

        // Act
        var searchUsersCommand = new SearchUsersCommand("");
        var result = await sut.Handle(searchUsersCommand, CancellationToken.None);

        // Assert
        result.Should().BeEmpty();
    }
}