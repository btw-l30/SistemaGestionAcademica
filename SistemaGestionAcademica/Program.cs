using SistemaGestionAcademica.Models;
using SistemaGestionAcademica.Services;

namespace SistemaGestionAcademica;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var sistema = new SistemaAcademico();
        sistema.Semilla(); // carga 2 profesores, 3 cursos, 4 estudiantes, y asignaciones básicas
        sistema.Menu();
    }
}
