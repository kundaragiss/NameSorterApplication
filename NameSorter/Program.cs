using Application;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();


var serviceProvider = new ServiceCollection()
    .AddLogging(configure => configure.AddConsole())
    .AddTransient<INameService, NameService>()
    .AddSingleton<IFileService, FileService>()
    .BuildServiceProvider();

var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application started.");

try
{
    var fileService = serviceProvider.GetRequiredService<IFileService>();
    var sortService = serviceProvider.GetRequiredService<INameService>();

    // Get file paths and environment type from configuration
    var environment = configuration["Environment"];
    var outputFilePath = configuration["FilePaths:OutputFile"];

    logger.LogInformation("Environment: {environment}", environment);

    // Get file path from arguments
    var filePath = args.Length > 0 ? args[0] : throw new ArgumentException("File path not provided in arguments.");


    // Read, sort, and write names
    var names = await fileService.ReadNamesFromFileAsync(filePath);
    var sortedNames = await sortService.SortNamesAsync(names);
    await fileService.WriteNamesToFileAsync(outputFilePath, sortedNames);

    // Display sorted names in the console
    Console.WriteLine("Sorted Names:");
    foreach (var name in sortedNames)
    {
        Console.WriteLine($"{name.FirstName} {name.LastName}");
    }


    logger.LogInformation("Names sorted and written to file: {FilePath}", outputFilePath);

}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred.");
}