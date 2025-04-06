using Domain;
using System;

namespace Infrastructure
{
    public interface IFileService
    {
        Task<List<Name>> ReadNamesFromFileAsync(string filePath);
        Task WriteNamesToFileAsync(string filePath, List<Name> sortedPeople);
    }
}
