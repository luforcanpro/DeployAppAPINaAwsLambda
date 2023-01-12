using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebAPI.Models
{
    public class Pessoa
    {
        public long Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Genero { get; set; }
    }
}
