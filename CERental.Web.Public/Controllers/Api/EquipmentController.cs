using CERental.Core.Contract.Services;
using CERental.Core.Dto;
using System.Collections.Generic;
using System.Web.Http;

namespace CERental.Web.Public.Controllers.Api
{
    public class EquipmentController : BaseApiController
    {
        public ICommunicationService CommunicationService { get; set; }

        [HttpGet]
        public IEnumerable<EquipmentDto> GetEquipments()
        {
            return CommunicationService.GetEquipments();
        }
    }
}