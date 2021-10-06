using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web_api_dotnet.Models;

namespace web_api_dotnet.Controllers
{

  // Call name route -> Estado
  [Route("api/[controller]")]
  [ApiController]

  public class EstadoController : ControllerBase
  {

    public static List<Estado> lista = new List<Estado>();

    // Method Get
    [HttpGet]
    public List<Estado> GetEstados()
    {
      return lista;
    }

    // Method Post
    [HttpPost]
    public string PostEstado(Estado estado)
    {
      lista.Add(estado);
      return "Estado cadastrado com sucesso!";
    }

    // Method Put
    [HttpPut]
    public string PutEstado(Estado estado)
    {
      Estado estadoAux = lista.Where(x => x.Sigla == estado.Sigla).FirstOrDefault();
      estadoAux.Nome = estado.Nome;
      return "Estado alterado com sucesso!";
    }

    // Method Delete
    [HttpDelete]
    public string DeleteEstado(Estado estado)
    {
      Estado estadoAux = lista.Where(x => x.Sigla == estado.Sigla).FirstOrDefault();
      lista.Remove(estadoAux);
      return "Estado removido com sucesso!";
    }

  }
}