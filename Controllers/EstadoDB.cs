using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_api_dotnet.Models;

namespace web_api_dotnet.Controllers
{
  public class EstadoDB
  {
    public static List<Estado> GetEstados()
    {
      List<Estado> lista = new List<Estado>();
      try
      {

        NpgsqlConnection conexao = Conexao.GetConexao();

        string sql = "SELECT * FROM estado ORDER BY est_sigla";
        NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
        NpgsqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
          string sigla = (string)dr["est_sigla"];
          string nome = dr["nome"].ToString();

          Estado estado = new Estado()
          {
            Sigla = sigla,
            Nome = nome,
          };

          lista.Add(estado);

        }

      }
      catch (Exception e)
      {
        Console.WriteLine("Erro de SQL: " + e.Message);
      }
      return lista;
    }

  }
}