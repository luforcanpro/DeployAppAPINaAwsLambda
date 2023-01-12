using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLerAPIObjeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Note que estamos chamando um método async chamado RunAsync que será bloqueado até que termine sua execução.
            RunAsync().Wait();
            Console.ReadKey();
        }


        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                //https://xa68vkv6il.execute-api.us-east-1.amazonaws.com/Prod/api/pessoa
                client.BaseAddress = new System.Uri("https://xa68vkv6il.execute-api.us-east-1.amazonaws.com/Prod/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("api/pessoa/3");
                if (response.IsSuccessStatusCode)
                {  //GET
                    Pessoa produto = await response.Content.ReadAsAsync<Pessoa>();
                    Console.WriteLine("{0}\tR${1}\t{2}\t{3}", produto.PrimeiroNome, produto.Sobrenome, produto.Endereco, produto.Genero);
                    Console.WriteLine("Produto acessado e exibido.  Tecle algo para incluir um novo produto.");
                    Console.ReadKey();
                }
                ////POST
                //var cha = new Produto() { Nome = "Chá Verde", Preco = 1.50M, Categoria = "Bebidas" };
                //response = await client.PostAsJsonAsync("api/produtos", cha);
                //Console.WriteLine("Produto cha verde incluído. Tecle algo para atualizar o preço do produto.");
                //Console.ReadKey();
                //if (response.IsSuccessStatusCode)
                //{   //PUT
                //    Uri chaUrl = response.Headers.Location;
                //    cha.Preco = 2.55M;   // atualiza o preco do produto
                //    response = await client.PutAsJsonAsync(chaUrl, cha);
                //    Console.WriteLine("Produto preço do atualizado. Tecle algo para excluir o produto");
                //    Console.ReadKey();
                //    //DELETE
                //    response = await client.DeleteAsync(chaUrl);
                //    Console.WriteLine("Produto deletado");
                //    Console.ReadKey();
                //}
            }
        }
    }
}
