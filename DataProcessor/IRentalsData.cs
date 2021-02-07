using DataProcessor.Models;
using System.Collections.Generic;

namespace DataProcessor
{
    public interface IRentalsData
    {
        void CreateNewRental(int customerId, List<int> movieIds);
    }
}