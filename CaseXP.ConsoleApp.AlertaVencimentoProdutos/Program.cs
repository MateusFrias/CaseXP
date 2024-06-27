using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("(não implementado) Console app representando serviço diário de envio de alertas via e-mail para os usuários, sobre produtos próximos da data de validade.\n" +
            "Cada ProdutoDisponivel tem um IdUsuario representando o usuário responsável por sua negociação.\n" +
            "O serviço pode também gerir automaticamente a lista de ProdutosDisponiveis, removendo itens já vencidos.\n\n" +
            "O console app representa um serviço agendável que pode também ser implementado como Windows Service, background tasks\n" +
            "ou utilizando serviços serverless em cloud como AWS Lambda\n");
        Console.ReadLine();
    }
}
   