using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AWSServerlessWebAPI.Models;
using AWSServerlessWebAPI.Services;

namespace AWSServerlessWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;

        //DECLARA O SERVIÇO QUE VAI UTILIZAR

        private IPessoaService _pessoaService;

        //NO CONSTRUTOR ACRESCENTAR O SERVIÇO TAMBÉM
        public PessoaController(ILogger<PessoaController> logger, IPessoaService pessoaService)
        {
            _logger = logger;
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pessoaService.PesquisarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var pessoa = _pessoaService.PesquisarPorID(id);
            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        [HttpPost]
        //FROM BOBY COPIA O JSON QUE VEM NO CORPO DA REQUEST E CONVERTE EM OBJETO PERSON
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoaService.Criar(pessoa));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Pessoa pessoa)
        {
            if (pessoa == null) return BadRequest();
            return Ok(_pessoaService.Atualizar(pessoa));
        }

        [HttpDelete("id")]
        public IActionResult Delete(long id)
        {
            _pessoaService.Exluir(id);
            return NoContent();
        }

        private bool eUmNumero(string numeroInformado)
        {
            double numero;
            bool eNumero = double.TryParse(numeroInformado,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out numero);
            return eNumero;
        }
        //[HttpGet("soma/{primeiroNumero}/{segundoNumero}")]
        //public IActionResult Soma(string primeiroNumero, string segundoNumero)
        //{
        //    if(eUmNumero(primeiroNumero) && eUmNumero(segundoNumero))
        //    {
        //        var resultadoCalculo = Convert.ToDecimal(primeiroNumero) + Convert.ToDecimal(segundoNumero);
        //        return Ok(resultadoCalculo.ToString());
        //    }
        //    return BadRequest("Digite um número como entrada por favor");
        //}

        //[HttpGet("subtracao/{primeiroNumero}/{segundoNumero}")]
        //public IActionResult Subtracao(string primeiroNumero, string segundoNumero)
        //{
        //    if (eUmNumero(primeiroNumero) && eUmNumero(segundoNumero))
        //    {
        //        var resultadoCalculo = Convert.ToDecimal(primeiroNumero) - Convert.ToDecimal(segundoNumero);
        //        return Ok(resultadoCalculo.ToString());
        //    }
        //    return BadRequest("Digite um número como entrada por favor");
        //}

        //[HttpGet("multiplicacao/{primeiroNumero}/{segundoNumero}")]
        //public IActionResult Multiplicacao(string primeiroNumero, string segundoNumero)
        //{
        //    if (eUmNumero(primeiroNumero) && eUmNumero(segundoNumero))
        //    {
        //        var resultadoCalculo = Convert.ToDecimal(primeiroNumero) * Convert.ToDecimal(segundoNumero);
        //        return Ok(resultadoCalculo.ToString());
        //    }
        //    return BadRequest("Digite um número como entrada por favor");
        //}

        //[HttpGet("divisao/{primeiroNumero}/{segundoNumero}")]
        //public IActionResult Divisao(string primeiroNumero, string segundoNumero)
        //{
        //    if (eUmNumero(primeiroNumero) && eUmNumero(segundoNumero))
        //    {
        //        var resultadoCalculo = Convert.ToDecimal(primeiroNumero) / Convert.ToDecimal(segundoNumero);
        //        return Ok(resultadoCalculo.ToString());
        //    }
        //    return BadRequest("Digite um número como entrada por favor");
        //}

        //[HttpGet("media/{primeiroNumero}/{segundoNumero}")]
        //public IActionResult Media(string primeiroNumero, string segundoNumero)
        //{
        //    if (eUmNumero(primeiroNumero) && eUmNumero(segundoNumero))
        //    {
        //        var resultadoCalculo = (Convert.ToDecimal(primeiroNumero) + Convert.ToDecimal(segundoNumero))/2;
        //        return Ok(resultadoCalculo.ToString());
        //    }
        //    return BadRequest("Digite um número como entrada por favor");
        //}

        //[HttpGet("raizquadrada/{primeiroNumero}")]
        //public IActionResult RaizQuadrada(string primeiroNumero)
        //{
        //    if (eUmNumero(primeiroNumero))
        //    {
        //        var resultadoCalculo = Math.Sqrt((double)Convert.ToDecimal(primeiroNumero));
        //        return Ok(resultadoCalculo.ToString());
        //    }
        //    return BadRequest("Digite um número como entrada por favor");
        //}


    }
}
