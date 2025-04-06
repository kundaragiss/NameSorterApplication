Project Overview
This is a .NET Core Console Application that follows Clean Architecture principles. Its purpose is to read names from a text file, sort them by last name (and then first name), 
and write the sorted names to an output file. The application is modular, extensible, and incorporates features like dependency injection, logging, configuration management, and error handling.

Key Features--
Clean Architecture:
 -Domain Layer: Core entities (Name).
 -Application Layer: Business logic for sorting names.
 -Infrastructure Layer: File operations (read/write).
 -Presentation Layer: Main console application.
Dependency Injection: Ensures loose coupling between components
Asynchronous Operations: For file I/O
Logging: Uses  for structured logs
Configuration Management: Reads settings from appsettings.json and environment variables
Error Handling: Graceful error handling with try/catch blocks

How It Works--
Reads the input file asynchronously using FileService
Sort names by last name using NameService
Writes the sorted names to an output file
Displays the sorted names in the console
Logs important events (e.g., application start, errors) to the console
Catches and logs exceptions for operations like file I/O or invalid arguments.

Unit tests are available for key components: 
SortNamesServiceTests: Verifies sorting logic
FileServiceTests: Tests file reading and writing

