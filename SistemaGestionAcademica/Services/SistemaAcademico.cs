using SistemaGestionAcademica.Models;

namespace SistemaGestionAcademica.Services;

public class SistemaAcademico
{
    public List<Profesor> Profesores { get; } = new();
    public List<Estudiante> Estudiantes { get; } = new();
    public List<Curso> Cursos { get; } = new();

    public void Semilla()
    {
        // Profesores (2)
        var p1 = new Profesor("Ing. Ana López", "10000001", "ana.lopez@uni.edu", "Ingeniería de Software");
        var p2 = new Profesor("MSc. Carlos Ruiz", "10000002", "carlos.ruiz@uni.edu", "Bases de Datos");
        Profesores.AddRange(new[] { p1, p2 });

        // Estudiantes (4)
        var e1 = new Estudiante("Juan Pérez", "30100001", "juan.perez@correo.com", "20210001");
        var e2 = new Estudiante("María Gómez", "30100002", "maria.gomez@correo.com", "20210002");
        var e3 = new Estudiante("Luis Ramírez", "30100003", "luis.ramirez@correo.com", "20210003");
        var e4 = new Estudiante("Andrea Díaz", "30100004", "andrea.diaz@correo.com", "20210004");
        Estudiantes.AddRange(new[] { e1, e2, e3, e4 });

        // Cursos (3)
        var c1 = new Curso("PROG2", "Programación 2");
        var c2 = new Curso("BD1", "Base de Datos I");
        var c3 = new Curso("MAT2", "Matemática II");
        Cursos.AddRange(new[] { c1, c2, c3 });

        // Asignaciones mínimas
        c1.AsignarProfesor(p1);
        c2.AsignarProfesor(p2);

        c1.AgregarEstudiante(e1);
        c1.AgregarEstudiante(e2);
        c1.AgregarEstudiante(e3);

        c2.AgregarEstudiante(e2);
        c2.AgregarEstudiante(e4);

        // Notas de ejemplo
        c1.RegistrarNota(e1, 85);
        c1.RegistrarNota(e2, 90);
        c1.RegistrarNota(e3, 78);
    }

    public void Menu()
    {
        while (true)
        {
            Console.WriteLine("\n====== Sistema de Gestión Académica ======");
            Console.WriteLine("1) Listar profesores");
            Console.WriteLine("2) Listar estudiantes");
            Console.WriteLine("3) Listar cursos");
            Console.WriteLine("4) Crear profesor");
            Console.WriteLine("5) Crear estudiante");
            Console.WriteLine("6) Crear curso");
            Console.WriteLine("7) Asignar profesor a curso");
            Console.WriteLine("8) Agregar estudiante a curso");
            Console.WriteLine("9) Registrar nota (curso + estudiante)");
            Console.WriteLine("10) Ver resumen de un curso");
            Console.WriteLine("0) Salir");
            Console.Write("Seleccione una opción: ");

            var op = Console.ReadLine();
            switch (op)
            {
                case "1": ListarProfesores(); break;
                case "2": ListarEstudiantes(); break;
                case "3": ListarCursos(); break;
                case "4": CrearProfesor(); break;
                case "5": CrearEstudiante(); break;
                case "6": CrearCurso(); break;
                case "7": AsignarProfesorACurso(); break;
                case "8": AgregarEstudianteACurso(); break;
                case "9": RegistrarNota(); break;
                case "10": VerResumenCurso(); break;
                case "0": return;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }
    }

    private void ListarProfesores()
    {
        Console.WriteLine("\nProfesores:");
        for (int i = 0; i < Profesores.Count; i++)
            Console.WriteLine($"{i + 1}. {Profesores[i].MostrarInformacion()}");
    }

    private void ListarEstudiantes()
    {
        Console.WriteLine("\nEstudiantes:");
        for (int i = 0; i < Estudiantes.Count; i++)
            Console.WriteLine($"{i + 1}. {Estudiantes[i].MostrarInformacion()}");
    }

    private void ListarCursos()
    {
        Console.WriteLine("\nCursos:");
        for (int i = 0; i < Cursos.Count; i++)
        {
            var c = Cursos[i];
            Console.WriteLine($"{i + 1}. {c.Codigo} - {c.Nombre} | Profesor: {(c.Profesor is null ? "Sin asignar" : c.Profesor.Nombre)} | Inscritos: {c.Estudiantes.Count}");
        }
    }

    private void CrearProfesor()
    {
        Console.Write("\nNombre: "); var nombre = Console.ReadLine() ?? "";
        Console.Write("DPI: "); var dpi = Console.ReadLine() ?? "";
        Console.Write("Correo: "); var correo = Console.ReadLine() ?? "";
        Console.Write("Especialidad: "); var esp = Console.ReadLine() ?? "";
        Profesores.Add(new Profesor(nombre, dpi, correo, esp));
        Console.WriteLine("Profesor creado.");
    }

    private void CrearEstudiante()
    {
        Console.Write("\nNombre: "); var nombre = Console.ReadLine() ?? "";
        Console.Write("DPI: "); var dpi = Console.ReadLine() ?? "";
        Console.Write("Correo: "); var correo = Console.ReadLine() ?? "";
        Console.Write("Carnet: "); var carnet = Console.ReadLine() ?? "";
        Estudiantes.Add(new Estudiante(nombre, dpi, correo, carnet));
        Console.WriteLine("Estudiante creado.");
    }

    private void CrearCurso()
    {
        Console.Write("\nCódigo: "); var cod = Console.ReadLine() ?? "";
        Console.Write("Nombre: "); var nom = Console.ReadLine() ?? "";
        Cursos.Add(new Curso(cod, nom));
        Console.WriteLine("Curso creado.");
    }

    private void AsignarProfesorACurso()
    {
        if (!Cursos.Any() || !Profesores.Any()) { Console.WriteLine("Faltan cursos o profesores."); return; }
        ListarCursos();
        Console.Write("Seleccione # de curso: ");
        if (!int.TryParse(Console.ReadLine(), out var ic) || ic < 1 || ic > Cursos.Count) { Console.WriteLine("Entrada inválida."); return; }

        Console.WriteLine();
        ListarProfesores();
        Console.Write("Seleccione # de profesor: ");
        if (!int.TryParse(Console.ReadLine(), out var ip) || ip < 1 || ip > Profesores.Count) { Console.WriteLine("Entrada inválida."); return; }

        Cursos[ic - 1].AsignarProfesor(Profesores[ip - 1]);
        Console.WriteLine("Profesor asignado.");
    }

    private void AgregarEstudianteACurso()
    {
        if (!Cursos.Any() || !Estudiantes.Any()) { Console.WriteLine("Faltan cursos o estudiantes."); return; }
        ListarCursos();
        Console.Write("Seleccione # de curso: ");
        if (!int.TryParse(Console.ReadLine(), out var ic) || ic < 1 || ic > Cursos.Count) { Console.WriteLine("Entrada inválida."); return; }

        Console.WriteLine();
        ListarEstudiantes();
        Console.Write("Seleccione # de estudiante: ");
        if (!int.TryParse(Console.ReadLine(), out var ie) || ie < 1 || ie > Estudiantes.Count) { Console.WriteLine("Entrada inválida."); return; }

        var ok = Cursos[ic - 1].AgregarEstudiante(Estudiantes[ie - 1]);
        Console.WriteLine(ok ? "Estudiante agregado." : "El estudiante ya estaba inscrito.");
    }

    private void RegistrarNota()
    {
        if (!Cursos.Any()) { Console.WriteLine("No hay cursos."); return; }
        ListarCursos();
        Console.Write("Seleccione # de curso: ");
        if (!int.TryParse(Console.ReadLine(), out var ic) || ic < 1 || ic > Cursos.Count) { Console.WriteLine("Entrada inválida."); return; }
        var curso = Cursos[ic - 1];

        if (!curso.Estudiantes.Any()) { Console.WriteLine("El curso no tiene estudiantes."); return; }
        Console.WriteLine("\nEstudiantes inscritos:");
        for (int i = 0; i < curso.Estudiantes.Count; i++)
            Console.WriteLine($"{i + 1}. {curso.Estudiantes[i]}");

        Console.Write("Seleccione # de estudiante: ");
        if (!int.TryParse(Console.ReadLine(), out var ie) || ie < 1 || ie > curso.Estudiantes.Count) { Console.WriteLine("Entrada inválida."); return; }
        var est = curso.Estudiantes[ie - 1];

        Console.Write("Nota (0-100): ");
        if (!float.TryParse(Console.ReadLine(), out var nota) || nota < 0 || nota > 100) { Console.WriteLine("Nota inválida."); return; }

        Console.WriteLine(curso.RegistrarNota(est, nota) ? "Nota registrada." : "No se pudo registrar la nota (verifique inscripción).");
    }

    private void VerResumenCurso()
    {
        if (!Cursos.Any()) { Console.WriteLine("No hay cursos."); return; }
        ListarCursos();
        Console.Write("Seleccione # de curso: ");
        if (!int.TryParse(Console.ReadLine(), out var ic) || ic < 1 || ic > Cursos.Count) { Console.WriteLine("Entrada inválida."); return; }
        Console.WriteLine();
        Console.WriteLine(Cursos[ic - 1].Resumen());
    }
}
