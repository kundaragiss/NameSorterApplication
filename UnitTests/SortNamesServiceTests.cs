using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Domain;
using Application;
using Infrastructure;
using Moq;
using Microsoft.Extensions.Logging;

public class SortNamesServiceTests
{
    
    private readonly NameService _nameService;

    public SortNamesServiceTests()
    {
        var logger = new LoggerFactory().CreateLogger<NameService>();
        _nameService = new NameService(logger);
    }

    [Fact]
    public async Task SortNamesAsync_ShouldSortByLastName()
    {
        var names = new List<Name>
        {
            new Name("Santosh Kundaragi"),
            new Name("Satish Patil"),
            new Name("Alice Brown")
        };

        // Act
        var sorted = await _nameService.SortNamesAsync(names);

        // Assert
        Assert.Equal("Brown", sorted[0].LastName);
        Assert.Equal("Kundaragi", sorted[1].LastName);
        Assert.Equal("Patil", sorted[2].LastName);
    }

    [Fact]
    public async Task SortNamesAsync_ShouldHandleEmptyList()
    {
        // Arrange
        var names = new List<Name>();

        // Act
        var sorted = await _nameService.SortNamesAsync(names);

        // Assert
        Assert.Empty(sorted);
    }
}