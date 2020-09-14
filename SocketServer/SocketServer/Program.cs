using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criar o secket para conexão
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // Definir o IP e porta de comunicação
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            // Associar o socket de conexão com o endPoint de comunicação
            socket.Bind(endPoint);
            // Coloca o socket em estado de escuta, definindo como parâmetro o comprimento máximo da fila de conexões pendentes.
            socket.Listen(5);

            // Mensagem de status
            Console.WriteLine("Escutando...");

            // Quando escutar algum cliente, aceita a conexão e cria um objeto socket para guardar o socket cliente.
            Socket escutar = socket.Accept();
            // Mensagem de status
            Console.WriteLine("Conctado com exito...");

            // Array de bytes para guardar a informação recebida
            byte[] bytes = new byte[1024];
            // Tamanho em bytes da informação recebida
            int tamanho = escutar.Receive(bytes, 0, bytes.Length, SocketFlags.None);
            // Redimensiona o array de bytes para o tamanho da informação recebida
            Array.Resize(ref bytes, tamanho);
            // Mensagem mostrando a informação recebida
            Console.WriteLine($"Cliente falou: {Encoding.Default.GetString(bytes)}");

            // Fecha o socket de comunicação
            socket.Close();

            // Finaliza a aplicação
            Console.WriteLine("Pressione qualquer tecla para finalizar...");
            // Apenas pra fazer uma pausa em modo de debug
            Console.ReadKey();
        }
    }
}
