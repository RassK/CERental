using CERental.Core.Dto;
using CERental.Core.Models;
using System.Collections.Generic;

namespace CERental.Core.Contract.Services
{
    public interface ICommunicationService : IApplicationService
    {
        ICollection<EquipmentDto> GetEquipments();
        RentalResult RegisterRent(string requesterId, IEnumerable<EquipmentRental> equipment);
    }
}