namespace SistemaGestionAcademica.Models;

public class Estudiante : Persona
{
    public string Carnet { get; set; }

    public Estudiante(string nombre, string dpi, string correo, string carnet)
        : base(nombre, dpi, correo)
    {
        Carnet = carnet;
    }

    public override string MostrarInformacion()
        => base.MostrarInformacion() + $" | Carnet: {Carnet}";

    public override string ToString() => $"{Nombre} (Carnet: {Carnet})";
}
