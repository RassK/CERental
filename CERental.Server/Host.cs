using System.Threading;

namespace CERental.Server
{
    public static class Host
    {
        private static ManualResetEvent _blockEvent;
        private static LogicServer _server;

        public static void Main(string[] args)
        {
            // Init
             _blockEvent = new ManualResetEvent(false);
            _server = new LogicServer();

            // Setup server
            Setup.Run();
            _server.Run();

            _blockEvent.WaitOne();
        }
    }
}