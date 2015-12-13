using CERental.Core.Contract.Repository;
using CERental.Core.Contract.Services;
using CERental.Core.Dto;
using System.Collections.Generic;
using System.Linq;

namespace CERental.ApplicationServices.Services
{
    public class EquipmentService : IEquipmentService
    {
        public IEquipmentRepository EquipmentRepository { get; set; }

        public IEnumerable<EquipmentDto> GetEquipments()
        {
            return EquipmentRepository.All.Select(x => new EquipmentDto()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type
            }).AsEnumerable();
        }
    }
}