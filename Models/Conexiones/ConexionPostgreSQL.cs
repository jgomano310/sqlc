using Npgsql;
using pruebaConexionPostgreSQLV.Util;

namespace pruebaConexionPostgreSQLV.Models.Conexiones
{
    /* ConexionPostgreSQL - Clase que realiza la conexión a PostgreSQL de forma parametrizada; basándose en la información 
    * de conexión recogida en el fichero util.VariablesConexionPostgreSQL.cs
    * @author garfe
    * 02/10/2022
    */
    public class ConexionPostgreSQL
    {
        //CONSTANTES
        string HOST = VariablesConexionPostgreSQL.HOST;
        string PORT = VariablesConexionPostgreSQL.PORT;
        string USER = VariablesConexionPostgreSQL.USER;
        string PASS = VariablesConexionPostgreSQL.PASS;
        string DB = VariablesConexionPostgreSQL.DB;

        //MÉTODOS
        public NpgsqlConnection GeneraConexion(string host,
            string port, string db, string user, string pass)
        {
            System.Console.WriteLine("[INFORMACIÓN-GeneraPostgreSQL-GeneraConexion] Entra en GeneraConexion");
            
            //Se crea una nueva conexión y la cadena con los datos de conexión.
            NpgsqlConnection conexion = new NpgsqlConnection();
            var datosConexion = "Server=?;Port=?;User Id=?;Password=?;Database=?";
            var estado = "";
            if (!string.IsNullOrWhiteSpace(datosConexion))
            {
                try
                {
                    conexion = new NpgsqlConnection(datosConexion);
                    conexion.Open();
                    //Se obtiene el estado de conexión para informarlo por consola
                    estado = conexion.State.ToString();
                    System.Console.WriteLine("[INFORMACIÓN-GeneraPostgreSQL-GeneraConexion] Estado conexión: "+estado);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("[ERROR-conexionPostgresql-generaConexion] Error al crear conexión:" + e);
                    conexion.Close();
                }
            }

            return conexion;

        }
    }
}
