using DataProcessor.DataAccess;
using DataProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProcessor
{
    public class MembershipTypeData : IMembershipTypeData
    {
        private readonly VidlyDbContext _context;

        public MembershipTypeData(VidlyDbContext context)
        {
            _context = context;
        }
        public List<MembershipType> GetAll()
        {
            return _context.MembershipTypes.ToList();
        }
    }
}
