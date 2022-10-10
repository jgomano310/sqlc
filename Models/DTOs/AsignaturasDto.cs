namespace pruebaConexionPostgreSQLV.Models.DTOs
{
    public class AsignaturasDto
    {
        public AsignaturasDto(string Id_asignatura, string Nombre,string Apellidos)
        {
            id_asignatura = Id_asignatura;
            nombre = Nombre;
            apellidos = Apellidos;
        }

        public string id_asignatura { get; private set; }
        public string nombre { get; private set; }
        public string apellidos { get; private set; }
    }
}
