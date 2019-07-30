using SuperWebSocket;
using System;

// https://www.websocket.org/echo.html
// Edit Location to 'ws://localhost:8088'
// https://youtu.be/JbXurSfeceY

namespace WebSocketExample
{
    class Program
    {
        private static WebSocketServer wsServer; 
        static void Main(string[] args)
        {
            wsServer = new WebSocketServer();
            int port = 8088;
            wsServer.Setup(port);
            wsServer.NewSessionConnected += WsServer_NewSessionConnected;
            wsServer.NewMessageReceived += WsServer_NewMessageReceived;
            wsServer.NewDataReceived += WsServer_NewDataReceived;
            wsServer.SessionClosed += WsServer_SessionClosed;
            wsServer.Start();
            Console.WriteLine("Server executando na porta " + port + ". Aperte ENTER para sair...");
            Console.ReadKey();
            wsServer.Stop();
        }

        private static void WsServer_SessionClosed(WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
        {
            Console.WriteLine("SessionClosed.");
        }
        private static void WsServer_NewDataReceived(WebSocketSession session, byte[] value)
        {
            Console.WriteLine("NewDataReceived");
        }
        private static void WsServer_NewMessageReceived(WebSocketSession session, string value)
        {
            Console.WriteLine("NewMessageReceived:" + value);
        }
        private static void WsServer_NewSessionConnected(WebSocketSession session)
        {
            Console.WriteLine("SessionConnected");
        }

    }
}
