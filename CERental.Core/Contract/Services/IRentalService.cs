using CERental.Core.Models;
using System.Collections.Generic;

namespace CERental.Core.Contract.Services
{
    public interface IRentalService : IApplicationService
    {
        RentalResult RentEquipment(string userId, IEnumerable<EquipmentRental> rentals);
    }
}