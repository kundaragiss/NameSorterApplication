using Domain;
using Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{

    public class NameService : INameService
    {
        private readonly ILogger<NameService> _logger;

        public NameService(ILogger<NameService> logger)
        {
            _logger = logger;
        }
        public Task<List<Name>> SortNamesAsync(List<Name> names)

        {
            try
            {
                var sorted = names.OrderBy(p => p.LastName).ThenBy(p => p.FirstName).ToList();
                return Task.FromResult(sorted);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while sorting names.");
                throw;
            }
        }
    }
}

