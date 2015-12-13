using CERental.Core;
using CERental.Core.Contract.Services;
using CERental.Core.Enums;
using CERental.Core.Models;
using CERental.Core.Models.Communicator;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CERental.Server
{
    public class LogicServer
    {
        public const int BUFFSIZE = 1024;
        public const int SERVERS = 5;

        private Thread[] _pipeServers;
        private ILogger _logger;

        public LogicServer()
        {
            _logger = LogManager.GetLogger("General");
        }

        public void Run()
        {
            // Run server in different task
            Task.Factory.StartNew(() =>
            {
                _pipeServers = new Thread[SERVERS];

                for (int i = 0; i < SERVERS; i++)
                {
                    _pipeServers[i] = new Thread(ServerThread);
                    _pipeServers[i].Start(i);
                }

                Console.WriteLine("All servers running");
            });
        }

        private void ServerThread(object obj)
        {
            int serverId = (int)obj;
            var pipeSecurity = new PipeSecurity();
            pipeSecurity.AddAccessRule(new PipeAccessRule("Everyone", PipeAccessRights.FullControl, AccessControlType.Allow));

            using (NamedPipeServerStream ps = new NamedPipeServerStream(Config.CommunicationServiceName, PipeDirection.InOut, SERVERS, PipeTransmissionMode.Message, PipeOptions.None, BUFFSIZE, BUFFSIZE, pipeSecurity))
            {
                ps.WaitForConnection();

                while (ps.IsConnected)
                {
                    try
                    {
                        int read = 0;
                        byte[] buff = new byte[BUFFSIZE];

                        while ((read = ps.Read(buff, 0, BUFFSIZE)) > 0)
                        {
                            var json = Encoding.ASCII.GetString(buff, 0, read);
                            var request = JsonConvert.DeserializeObject<InternalRequest>(json);

                            Console.WriteLine($"Server: {serverId} - Processing request ({request.Type.ToString()})");
                            InternalAnswer answer = ProcessRequest(request);

                            if (request.HasAnswer)
                            {
                                byte[] data = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(answer));
                                ps.Write(data, 0, data.Length);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex, "Pipe server data processing failed");
                    }
                }
            }

            // If connection ends setup a new pipe server
            _pipeServers[serverId] = new Thread(ServerThread);
            _pipeServers[serverId].Start(serverId);
        }

        private InternalAnswer ProcessRequest(InternalRequest request)
        {
            switch (request.Type)
            {
                case InternalRequestType.GetEquipmentList:
                    return ProcessEquipmentListRequest();
                case InternalRequestType.OrderRequest:
                    return ProcessOrderRequest(request);
                default:
                    throw new Exception("Unknown request");
            }
        }

        private InternalAnswer ProcessOrderRequest(InternalRequest request)
        {
            var service = IoC.Resolve<IRentalService>();
            var equipment = JsonConvert.DeserializeObject<List<EquipmentRental>>(request.Payload.ToString());
            var result = service.RentEquipment(request.UserId, equipment);

            return new InternalAnswer()
            {
                RequestType = request.Type,
                Payload = result
            };
        }

        private InternalAnswer ProcessEquipmentListRequest()
        {
            var service = IoC.Resolve<IEquipmentService>();
            var equipments = service.GetEquipments();

            return new InternalAnswer()
            {
                RequestType = InternalRequestType.GetEquipmentList,
                Payload = equipments
            };
        }
    }
}