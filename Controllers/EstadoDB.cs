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


    public static bool IncluiEstado(Estado estado)
    {
      bool result = false;
      try
      {

        NpgsqlConnection conexao = Conexao.GetConexao();

        string sql = " INSERT INTO estado (est_sigla, nome) " +
                     " VAlUES (@sigla, @nome)        ";

        NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

        cmd.Parameters.Add("@sigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = estado.Sigla;
        cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = estado.Nome;

        int valor = cmd.ExecuteNonQuery();
        if (valor > 0) result = true;
      }
      catch (Exception e)
      {
        Console.WriteLine("Erro de SQL: " + e.Message);
      }
      return result;
    }
  }
}