using Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class FileService : IFileService
    {
       
       
        private readonly ILogger<FileService> _logger;

        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
        }

        public async Task<List<Name>> ReadNamesFromFileAsync(string filePath)
        {

            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("Input file not found.");

                var lines = await File.ReadAllLinesAsync(filePath);

                return lines.Where(line => !string.IsNullOrWhiteSpace(line))
                       .Select(line => new Name(line))
                       .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to read names.");
                throw;
            }
        }

        public async Task WriteNamesToFileAsync(string filePath,List<Name> sortedNames)
        {
            try
            {
                var lines = sortedNames.Select(p => $"{p.FirstName} {p.LastName}");
                await File.WriteAllLinesAsync(filePath, lines);

               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to write sorted names.");
                throw;
            }
        }
    }
}
