using CERental.Core.Enums;

namespace CERental.Core.Models.Communicator
{
    public class InternalRequest
    {
        public InternalRequestType Type { get; set; }
        public object Payload { get; set; }
        public string UserId { get; set; }
        public bool HasAnswer { get; set; }
    }
}