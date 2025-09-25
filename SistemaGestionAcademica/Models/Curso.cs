namespace SistemaGestionAcademica.Models;

public class Curso
{
    public string Codigo { get; }
    public string Nombre { get; }
    public Profesor? Profesor { get; private set; }
    private readonly List<Estudiante> _estudiantes = new();
    private readonly Dictionary<string, float> _notas = new(); // carnet -> nota

    public IReadOnlyList<Estudiante> Estudiantes => _estudiantes;

    public Curso(string codigo, string nombre)
    {
        Codigo = codigo;
        Nombre = nombre;
    }

    public bool AsignarProfesor(Profesor p)
    {
        Profesor = p;
        p.RegistrarCurso(Codigo);
        return true;
    }

    public bool AgregarEstudiante(Estudiante e)
    {
        if (_estudiantes.Any(s => s.Carnet == e.Carnet)) return false;
        _estudiantes.Add(e);
        return true;
    }

    public bool RegistrarNota(Estudiante e, float nota)
    {
        if (!_estudiantes.Any(s => s.Carnet == e.Carnet)) return false;
        if (nota < 0 || nota > 100) return false;
        _notas[e.Carnet] = nota;
        return true;
    }

    public float? ObtenerNota(string carnet)
    {
        return _notas.TryGetValue(carnet, out var n) ? n : null;
    }

    public float CalcularPromedio()
    {
        var registradas = _notas.Values.ToList();
        return registradas.Count == 0 ? 0 : registradas.Average();
    }

    public string Resumen()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"Curso: {Nombre} ({Codigo})");
        sb.AppendLine($"Profesor: {(Profesor is null ? "Sin asignar" : Profesor.Nombre + " (Especialidad: " + Profesor.Especialidad + ")")}");
        sb.AppendLine($"Estudiantes inscritos: {_estudiantes.Count}");
        foreach (var e in _estudiantes)
        {
            var nota = ObtenerNota(e.Carnet);
            sb.AppendLine($"- {e.Nombre} (Carnet: {e.Carnet}) - Nota: {(nota is null ? "N/D" : nota.Value.ToString("0.##"))}");
        }
        sb.AppendLine();
        sb.AppendLine($"Promedio del curso: {CalcularPromedio():0.00}");
        return sb.ToString();
    }

    public override string ToString() => $"{Codigo} - {Nombre}";
}
