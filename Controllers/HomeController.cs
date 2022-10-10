using Microsoft.AspNetCore.Mvc;
using Npgsql;
using pruebaConexionPostgreSQLV.Models.Conexiones;
using pruebaConexionPostgreSQLV.Models;
using pruebaConexionPostgreSQLV.Util;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using pruebaConexionPostgreSQLV.Models.DTOs;
using pruebaConexionPostgreSQLV.Models.Consultas;

namespace pruebaConexionPostgreSQLV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(ConexionPostgreSQL conexionPostgreSQL)
        {
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Entra en Index");
            
            //CONSTANTES
            const string HOST = VariablesConexionPostgreSQL.HOST;
            const string PORT = VariablesConexionPostgreSQL.PORT;
            const string USER = VariablesConexionPostgreSQL.USER;
            const string PASS = VariablesConexionPostgreSQL.PASS;
            const string DB = VariablesConexionPostgreSQL.DB;
            
            //Se genera una conexión a PostgreSQL y validamos que esté abierta fuera del método
            var estadoGenerada = "";
            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            List<AlumnoDTO> listaAlumnos= new List<AlumnoDTO>();
            List<AsignaturasDto> listaAsignaturas = new List<AsignaturasDto>();

            //NpgsqlCommand consulta = new NpgsqlCommand();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(HOST, PORT, DB, USER, PASS);
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada);

            //Se realiza la consulta y se guarda una lista de alumnosDTO
            listaAlumnos = ConsultasPostgreSQL.ConsultaSelectPostgreSQL(conexionGenerada);
            listaAsignaturas = ConsultaAsigAlumn.ConsultaASignaturas(conexionGenerada);
           foreach(AsignaturasDto asign in listaAsignaturas)
            {
                Console.WriteLine(asign.nombre + " " + asign.apellidos + " "+ asign.id_asignatura) ;
                
            }
            int cont = listaAlumnos.Count();
            

            return View();
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}