# SistemaGestionAcademica
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![CLI App](https://img.shields.io/badge/App-Console-blue)
![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen)
 
Sistema de GestiÃ³n AcadÃ©mica (POO en C#). Incluye herencia (`Persona` â†’ `Estudiante`/`Profesor`), y agregaciÃ³n en `Curso` (profesor + lista de estudiantes).  
Consola interactiva con menÃº para crear y listar entidades, asignarlas a cursos, registrar notas y calcular promedios.

## Requisitos de ejecuciÃ³n
- .NET 8 SDK o Visual Studio 2022/2022+ con soporte para .NET 8.

## CÃ³mo abrir
- **OpciÃ³n A (Visual Studio)**: abre el archivo `SistemaGestionAcademica.sln` y ejecuta.
- **OpciÃ³n B (CLI)**:
  ```bash
  dotnet run --project SistemaGestionAcademica/SistemaGestionAcademica.csproj
  ```

## Funcionalidades principales
- Crear profesores, estudiantes y cursos.
- Asignar profesor a curso.
- Agregar estudiantes a curso.
- Registrar notas por curso y estudiante.
- Mostrar resumen de curso y promedio.
- Datos de ejemplo precargados: 2 profesores, 3 cursos, 4 estudiantes.

## Estructura
```
SistemaGestionAcademica/
 â”œâ”€ SistemaGestionAcademica.sln
 â””â”€ SistemaGestionAcademica/
    â”œâ”€ SistemaGestionAcademica.csproj
    â”œâ”€ Program.cs
    â”œâ”€ Models/
    â”‚  â”œâ”€ Persona.cs
    â”‚  â”œâ”€ Estudiante.cs
    â”‚  â”œâ”€ Profesor.cs
    â”‚  â””â”€ Curso.cs
    â”œâ”€ Services/
    â”‚  â””â”€ SistemaAcademico.cs
    â”œâ”€ screenshots/
    â”‚  â””â”€ resultado_programacion2.png
    â””â”€ README.md
```

## Git y GitHub (sugerido)
```bash
cd SistemaGestionAcademica
git init
git add .
git commit -m "chore: inicializa soluciÃ³n y estructura del proyecto"

git branch -M main
# Crea un repo vacÃ­o en GitHub y reemplaza la URL de ejemplo:
git remote add origin https://github.com/USUARIO/SistemaGestionAcademica.git
git push -u origin main

# Commits sugeridos conforme avances
git commit -am "feat: clases Persona/Estudiante/Profesor/Curso"
git commit -am "feat(menu): menÃº interactivo y datos precargados"
git commit -am "feat: registrar nota y promedio por curso"
git commit -am "docs: agrega screenshots y README"
git push
```

## Evidencias
![Resumen Programación 2](SistemaGestionAcademica/screenshots/resultado_programacion2.png)
