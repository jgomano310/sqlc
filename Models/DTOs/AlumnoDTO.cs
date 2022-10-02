namespace pruebaConexionPostgreSQLV.Models.DTOs
{
    /* AlumnoDTO - DTO de la tabla alumno
     * @autor garfe
     * 02/10/2022
     */

    public class AlumnoDTO
    { 
        public int id_alumno { get; set; }
        //Al añadir al tipo el símbolo ? se admite null en el campo al salir del constructor.
        public string? nombre { get; set; }
        public string? apellidos { get; set; }
        public string? email { get; set; }
    }
}
