using Npgsql;

namespace pruebaConexionPostgreSQLV.Models.DTOs.ADTO
{
    public class ListaAsignaturas
    {
        public static List<AsignaturasDto> leeAsignaturas(NpgsqlDataReader resultado)
        {
            List<AsignaturasDto> lista = new List<AsignaturasDto>();
            while (resultado.Read())
            {
                lista.Add(new AsignaturasDto(
                   resultado[0].ToString(),
                   resultado[1].ToString(),
                    resultado[2].ToString()));
            }
            return lista;
        }
    }
}
