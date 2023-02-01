using FluentAssertions;
using UserSearch.Domain;

namespace UserSearch.Application.Tests;

public class UserMapperTests
{
    [Fact]
    public void From_WithValidUser_ReturnsValidUserDto()
    {
        // Arrange
        var user = new User
            { Id = 1, FirstName = "Katey", LastName = "Soltan", Email = "ksoltan@gmail.com", Gender = "Female" };
        var sut = new UserMapper();

        // Act
        var result = sut.From(user);

        // Assert
        result.Should().BeEquivalentTo(new UserDto
            { Id = 1, FirstName = "Katey", LastName = "Soltan", Email = "ksoltan@gmail.com", Gender = "Female" });
    }
}