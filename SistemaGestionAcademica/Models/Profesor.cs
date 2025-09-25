namespace SistemaGestionAcademica.Models;

public class Profesor : Persona
{
    public string Especialidad { get; set; }
    public List<string> CursosAsignados { get; } = new();

    public Profesor(string nombre, string dpi, string correo, string especialidad)
        : base(nombre, dpi, correo)
    {
        Especialidad = especialidad;
    }

    public void RegistrarCurso(string codigoCurso)
    {
        if (!CursosAsignados.Contains(codigoCurso))
            CursosAsignados.Add(codigoCurso);
    }

    public override string MostrarInformacion()
        => base.MostrarInformacion() + $" | Especialidad: {Especialidad} | Cursos asignados: {string.Join(", ", CursosAsignados)}";

    public override string ToString() => $"{Nombre} (Esp.: {Especialidad})";
}
