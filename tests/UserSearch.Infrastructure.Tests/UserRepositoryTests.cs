using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using UserSearch.Domain;

namespace UserSearch.Infrastructure.Tests;

public class UserRepositoryTests
{
    [Fact]
    public async Task FindUsers_WithSearchTerm_ReturnsUsers()
    {
        // Arrange
        var sut = new UserRepository(new NullLogger<UserRepository>());
        
        // Act
        var result = await sut.FindUsers("jam");
        
        // Assert
        result.Should().BeEquivalentTo(new User[]
        {
            new()
            {
                Id = 8, FirstName = "James", LastName = "Kubu", Email = "hkubu7@craigslist.org", Gender = "Male"
            },
            new()
            {
                Id = 11, FirstName = "James", LastName = "Pfeffer", Email = "bpfeffera@amazon.com", Gender = "Male"
            },
            new()
            {
                Id = 14, FirstName = "Chalmers", LastName = "Longfut", Email = "clongfujam@wp.com", Gender = "Male"
            }
        });
    }
    
    [Fact]
    public async Task FindUsersByFullName_WithSearchTerm_ReturnsUsers()
    {
        // Arrange
        var sut = new UserRepository(new NullLogger<UserRepository>());
        
        // Act
        var result = await sut.FindUsersByFullName("Katey", "Soltan");
        
        // Assert
        result.Should().BeEquivalentTo(new User[]
        {
            new()
            {
                Id = 18, FirstName = "Katey", LastName = "Soltan", Email = "ksoltanh@simplemachines.org",
                Gender = "Female"
            }
        });
    }
}