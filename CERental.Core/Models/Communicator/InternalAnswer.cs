using CERental.Core.Enums;

namespace CERental.Core.Models.Communicator
{
    public class InternalAnswer
    {
        public InternalRequestType RequestType { get; set; }
        public object Payload { get; set; }
    }
}