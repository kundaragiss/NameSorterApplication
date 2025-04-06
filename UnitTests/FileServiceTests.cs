using Xunit;
using Moq;
using Infrastructure;
using Domain;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using Application;
using Microsoft.Extensions.Logging;

public class FileServiceTests
{
    private readonly FileService _fileService;
  

    public FileServiceTests()
    {
        var logger = new LoggerFactory().CreateLogger<FileService>();
        _fileService = new FileService(logger);
    }
    [Fact]
    public async Task ReadNamesFromFileAsync_ShouldReadAndParseNames()
    {
        
        var filePath = "test.txt";

        // Simulate file content
        await File.WriteAllLinesAsync(filePath, new[] { "Santosh Kundaragi", "Satish Patil", "Alice Brown" });

        // Act
        var names = await _fileService.ReadNamesFromFileAsync(filePath);

        // Assert
        Assert.Equal(3, names.Count);
        Assert.Equal("Santosh", names[0].FirstName);
        Assert.Equal("Kundaragi", names[0].LastName);

        // Clean up test file
        File.Delete(filePath);

    }

    [Fact]
    public async Task WriteNamesToFileAsync_ShouldWriteSortedNames()
    {
        // Arrange
       
        var filePath = "sorted_test.txt";
        var names = new List<Name>
        {
            new Name("Santosh Kundaragi"),
            new Name("Satish Patil"),
            new Name("Alice Brown")
        };

        // Act
        await _fileService.WriteNamesToFileAsync(filePath, names);

        // Assert
        var writtenLines = await File.ReadAllLinesAsync(filePath);
        Assert.Equal("Santosh Kundaragi", writtenLines[0]);
        Assert.Equal("Satish Patil", writtenLines[1]);
        Assert.Equal("Alice Brown", writtenLines[2]);

        // Clean up test file
        File.Delete(filePath);
    }
}