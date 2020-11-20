using System;
using System.Net;
using System.Net.Sockets;

namespace SocketClient_Bellacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //ha bisogno di un endpoint dove connettersi
            string strIPAddress = "";
            string strPort = "";
            IPAddress ipAddress = null;
            int nPort;

            //il client è a più rischio di errore: cade connessione, morte server, lettura porta errata
            try
            {
                Console.WriteLine("IP del server: ");
                strIPAddress = Console.ReadLine();

                Console.WriteLine("Porta del server: ");
                strPort = Console.ReadLine();

                //prova a inserire la stringa che scrivo in un tipo ipaddress, se non ci riesce non da errore
                //se ci riesce da true
                //il punto esclamativo inverse le cose, quindi se NON ci riesce da true
                if (!IPAddress.TryParse(strIPAddress.Trim(), out ipAddress))
                {
                    Console.WriteLine("IP non valido.");
                    return;
                }

                if (!int.TryParse(strPort, out nPort))
                {
                    Console.WriteLine("Porta non valida.");
                    return;
                }

                if (nPort <= 0 || nPort >= 65535) 
                {
                    Console.WriteLine("Porta non valida.");
                    return;
                }

                Console.WriteLine("EndPoint Server: " + ipAddress.ToString() + " " + nPort);

                //effettiva connessione al serve
                //sblocca la asset nel server
                //per collegarsi al socket server 127.0.0.1  23000
                client.Connect(ipAddress, nPort);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
