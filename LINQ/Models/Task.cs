
namespace ProgramacionFuncionalCSharp.LINQ
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }

        public Task(int id, string title, int userId)
        {
            Id = id;
            Title = title;
            UserId = userId;
        }

        public static List<Task> Tasks()
        {
            return new List<Task>
            {
                new(1, "Completar curso C#", 1),
                new(2, "Hacer reunión Scrum", 2),
                new(3, "Resolver problema de lógica", 2),
                new(4, "Diseñar base de datos", 3),
                new(5, "Crear interfaz de usuario", 4),
                new(6, "Escribir documentación técnica", 4),
                new(7, "Realizar pruebas unitarias", 5),
                new(8, "Hacer deploy en servidores", 5),
                new(9, "Realizar el cronograma", 5)
            };
        }

    }

}