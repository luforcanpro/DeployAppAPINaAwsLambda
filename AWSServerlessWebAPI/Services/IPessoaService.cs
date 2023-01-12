using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSServerlessWebAPI.Models;

namespace AWSServerlessWebAPI.Services
{
    public interface IPessoaService
    { 
        Pessoa Criar(Pessoa pessoa);
        Pessoa PesquisarPorID(long id);
        List<Pessoa> PesquisarTodos();
        Pessoa Atualizar(Pessoa pessoa);
        void Exluir(long id);
    }
}
