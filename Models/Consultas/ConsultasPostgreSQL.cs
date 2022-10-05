using Npgsql;
using pruebaConexionPostgreSQLV.Models.DTOs;

namespace pruebaConexionPostgreSQLV.Models.Consultas
{
    public class ConsultasPostgreSQL
    {
        public static List<AlumnoDTO> ConsultaSelectPostgreSQL(NpgsqlConnection conexionGenerada)
        {
            List<AlumnoDTO> listAlumnos = new List<AlumnoDTO>();
            try
            {

                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"proyectoEclipse\".\"alumnos\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();
                while (resultadoConsulta.Read())
                {

                    Console.Write("{0}\t{1}\t{2}\t{3} \n",
                        resultadoConsulta[0], resultadoConsulta[1], resultadoConsulta[2], resultadoConsulta[3]);

                }

                System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Cierre conexión y conjunto de datos");
                conexionGenerada.Close();
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Error al ejecutar consulta: " + e);
                conexionGenerada.Close();

            }
            return listAlumnos;
        }
    }
}
