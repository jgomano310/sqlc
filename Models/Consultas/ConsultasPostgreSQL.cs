using Npgsql;
using pruebaConexionPostgreSQLV.Models.DTOs;
using System.Data;

namespace pruebaConexionPostgreSQLV.Models.Consultas
{
    /* ConsultasPostgreSQL - Clase que contiene los métodos que definen las diferentes consultas a BD
    * PostgreSQL que se pueden llevar a cabo.
    * @author garfe
    * 06/10/2022
    */
    public class ConsultasPostgreSQL
    {
        public static List<AlumnoDTO> ConsultaSelectPostgreSQL(NpgsqlConnection conexionGenerada)
        {
            List<AlumnoDTO> listAlumnos = new List<AlumnoDTO>();
            try
            {
                //Se define y ejecuta la consulta Select
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"proyectoEclipse\".\"alumnos\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listAlumnos = DTOs.ADTO.ReaderAListDTO.ReaderAListAlumnoDTO(resultadoConsulta);
                int cont = listAlumnos.Count();
                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Lista compuesta por: " + cont + " alumnos");

                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Cierre conexión y conjunto de datos");
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
