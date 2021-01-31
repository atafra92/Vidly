using DataProcessor.Models;
using System.Collections.Generic;

namespace DataProcessor
{
    public interface IMembershipTypeData
    {
        List<MembershipType> GetAll();
    }
}