namespace SistemaGestionAcademica.Models;

public abstract class Persona
{
    public string Nombre { get; set; }
    public string Dpi { get; set; }
    public string Correo { get; set; }

    protected Persona(string nombre, string dpi, string correo)
    {
        Nombre = nombre;
        Dpi = dpi;
        Correo = correo;
    }

    public virtual string MostrarInformacion()
        => $"Nombre: {Nombre} | DPI: {Dpi} | Correo: {Correo}";
}
