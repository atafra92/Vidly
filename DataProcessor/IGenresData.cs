using DataProcessor.Models;
using System.Collections.Generic;

namespace DataProcessor
{
    public interface IGenresData
    {
        List<Genre> GetAll();
    }
}