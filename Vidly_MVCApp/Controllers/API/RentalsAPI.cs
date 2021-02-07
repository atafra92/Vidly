using AutoMapper;
using DataProcessor;
using DataProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly_MVCApp.Models.DTOs;

namespace Vidly_MVCApp.Controllers.API
{
    public class RentalsAPI : IRentalsAPI
    {
        private readonly IRentalsData _rentalsData;
        private readonly IMapper _mapper;

        public RentalsAPI(IRentalsData rentalsData, IMapper mapper)
        {
            _rentalsData = rentalsData;
            _mapper = mapper;
        }

        public void SaveEntity(RentalDto rentalDto)
        {
                _rentalsData.CreateNewRental(rentalDto.CustomerId, rentalDto.MovieIds);
        }
    }
}
