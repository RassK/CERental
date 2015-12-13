using CERental.Core.Dto;
using System.Collections.Generic;

namespace CERental.Core.Contract.Services
{
    public interface IEquipmentService : IApplicationService
    {
        IEnumerable<EquipmentDto> GetEquipments();
    }
}