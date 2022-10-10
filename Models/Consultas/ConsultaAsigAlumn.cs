using Npgsql;
using pruebaConexionPostgreSQLV.Models.DTOs;

namespace pruebaConexionPostgreSQLV.Models.Consultas
{
    public class ConsultaAsigAlumn
    {
        public static List<AsignaturasDto> ConsultaASignaturas(NpgsqlConnection conexionGenerada)
        {
            List<AsignaturasDto> listaAsignaturas = new List<AsignaturasDto>();
            try                                                                                                                            
            {
                //Se define y ejecuta la consulta Select-
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT al.\"Nombre\", al.\"Apellidos\",asi.\"nombre\" \r\nFROM \"proyectoEclipse\".\"Alumnos\" al\r\n    INNER JOIN \"proyectoEclipse\".rel_asign_alumn r ON al.id_alumno = r.id_alumno\r\n    INNER JOIN \"proyectoEclipse\".\"Asignaturas\" asi ON r.id_asignaturas = asi.id_asignatura", conexionGenerada); 
                                                                   //SELECT al.Nombre, al.Apellidos, asi.nombre FROM \"proyectoEclipse\".\"Alumnos\" al INNER JOIN \"proyectoEclipse\".\"rel_asign_alumn\" r ON al.id_alumno = r.id_alumno\r\n  INNER JOIN \"proyectoEclipse\".\"Asignaturas\" asi ON r.id_asignaturas = asi.id_asignatura"                
                                                                   // "SELECT * FROM \"proyectoEclipse\".\"Alumnos\""
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listaAsignaturas = DTOs.ADTO.ListaAsignaturas.leeAsignaturas(resultadoConsulta);
                int cont = listaAsignaturas.Count();
                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Lista compuesta por: " + cont + " asignaturas");

                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Cierre conexión y conjunto de datos");
               // conexionGenerada.Close();
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                System.Console.WriteLine("[ERROR-HomeController-Index] Error al ejecutar consulta: " + e);
                conexionGenerada.Close();

            }
            return listaAsignaturas;
        }
        }
}
