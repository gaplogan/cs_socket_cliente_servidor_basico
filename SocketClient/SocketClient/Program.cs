using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criar o objeto socket para conexão
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Definir o endPoint que contém as informações de IP e Porta de comunicação
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);

                // Conectar o cliente com o servidor definido no endPoint
                socket.Connect(endPoint);

                // Mensagem de status
                Console.WriteLine("Conectado com exito...");
                // Pedir para o usuario inserir uma mensagem para enviar
                Console.WriteLine("Insira a informação para enviar:");
                Console.WriteLine();

                // Ler a mensagem do usuario
                string info = Console.ReadLine();
                // Converter a string da mensagem em array de bytes par poder enviar
                byte[] infoEnviar = Encoding.Default.GetBytes(info);
                // Enviar a mensagem para o servidor
                socket.Send(infoEnviar, 0, infoEnviar.Length, SocketFlags.None);
            }
            catch (Exception ex)
            {
                // Exibir mensagem de erro, caso aconteça algum
                Console.WriteLine("Não foi possível conectar ao servidor...\n" + ex.Message);
            }

            // Fechar o socket de comunicação
            socket.Close();

            // Mensagem de status, aguardando pessionar um tecla para finalizar
            Console.WriteLine("Pressione qualquer tecla para finalizar...");
            // Apenas para aguradar o usuario pressionar uma tecla
            Console.ReadKey();
        }
    }
}
