using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AWSServerlessWebAPI.Models;

namespace AWSServerlessWebAPI.Services.Implementations
{
    public class PessoaServiceImplementation : IPessoaService
    {
        // Counter responsible for generating a fake ID
        // since we are not accessing any database
        private volatile int count;

        public Pessoa Atualizar(Pessoa pessoa)
        {
            return pessoa;
        }

        public Pessoa Criar(Pessoa pessoa)
        {
            return pessoa;
        }

        public void Exluir(long id)
        {
            throw new NotImplementedException();
        }

        public Pessoa PesquisarPorID(long id)
        {
            return new Pessoa
            {
                Id = IncrementarNumero(),
                PrimeiroNome = "Luiz",
                Sobrenome = "Forçan",
                Endereco = "Rua A, 45",
                Genero = "Masculino"
                
            };

        }

        public List<Pessoa> PesquisarTodos()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            for (int i = 0; i < 8; i++)
            {
                Pessoa pessoa = MockPessoa(i);
                pessoas.Add(pessoa);

            }
            return pessoas;
        }

        private Pessoa MockPessoa(int i)
        {
            return new Pessoa
            {
                Id = IncrementarNumero(),
                PrimeiroNome = "Primeiro Nome" + i,
                Sobrenome = "Sobrenome" + i,
                Endereco = "Endereço" + i,
                Genero = "Masculino"

            };
        }
        /// <summary>
        /// Incrementa uma autonumeração como no banco de dados
        /// </summary>
        /// <returns></returns>
        private long IncrementarNumero()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
