using Vidly_MVCApp.Models.DTOs;

namespace Vidly_MVCApp.Controllers.API
{
    public interface IRentalsAPI
    {
        void SaveEntity(RentalDto rentalDto);
    }
}