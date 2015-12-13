using CERental.Core;
using CERental.Core.Contract.Services;
using CERental.Core.Helpers;
using System;
using System.IO.Pipes;
using System.Text;
using CERental.Core.Models.Communicator;
using Newtonsoft.Json;
using CERental.Core.Dto;
using System.Collections.Generic;
using CERental.Core.Enums;
using CERental.Core.Models;
using NLog;

namespace CERental.ApplicationServices.Services
{
    public class CommunicationService : ICommunicationService
    {
        private ILogger _logger;

        public CommunicationService()
        {
            _logger = LogManager.GetLogger("General");
        }

        public ICollection<EquipmentDto> GetEquipments()
        {
            try
            {
                var answer = SendRequest(new InternalRequest()
                {
                    Type = InternalRequestType.GetEquipmentList,
                    HasAnswer = true
                });

                return JsonConvert.DeserializeObject<List<EquipmentDto>>(answer.Payload.ToString());
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Communication service error. Unable to process command {InternalRequestType.GetEquipmentList}.");
                return null;
            }
        }

        public RentalResult RegisterRent(string requesterId, IEnumerable<EquipmentRental> equipment)
        {
            try
            {
                var answer = SendRequest(new InternalRequest()
                {
                    Type = InternalRequestType.OrderRequest,
                    HasAnswer = true,
                    UserId = requesterId,
                    Payload = equipment
                });

                return JsonConvert.DeserializeObject<RentalResult>(answer.Payload.ToString());
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Communication service error. Unable to process command {InternalRequestType.OrderRequest}.");
                return null;
            }
        }

        private InternalAnswer SendRequest(InternalRequest request)
        {
            if (!PipesHelper.DoesNamedPipeExist(Config.CommunicationServiceName))
            {
                throw new Exception("Unable to connect to the internal logic server");
            }

            using (var client = new NamedPipeClientStream(Config.CommunicationServiceName))
            {
                client.Connect(5000);
                if (client.IsConnected)
                {
                    client.ReadMode = PipeTransmissionMode.Message;

                    string message = JsonConvert.SerializeObject(request);
                    byte[] msgBuff = Encoding.ASCII.GetBytes(message);

                    client.Write(msgBuff, 0, msgBuff.Length);
                    if (request.HasAnswer)
                    {
                        int count = 0;
                        byte[] buff = new byte[Config.CommunicatorBufferSize];
                        StringBuilder mb = new StringBuilder();

                        do
                        {
                            count = client.Read(buff, 0, Config.CommunicatorBufferSize);
                            mb.Append(Encoding.ASCII.GetString(buff, 0, count));
                        } while (!client.IsMessageComplete);

                        return JsonConvert.DeserializeObject<InternalAnswer>(mb.ToString());
                    }
                }

                return null;
            }
        }
    }
}