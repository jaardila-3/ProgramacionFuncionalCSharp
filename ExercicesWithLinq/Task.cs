
namespace ProgramacionFuncionalCSharp.ExercicesWithLinq
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
                new Task(1, "Completar curso C#", 1),
                new Task(2, "Hacer reunión Scrum", 2),
                new Task(3, "Resolver problema de lógica", 2),
                new Task(4, "Diseñar base de datos", 3),
                new Task(5, "Crear interfaz de usuario", 4),
                new Task(6, "Escribir documentación técnica", 4),
                new Task(7, "Realizar pruebas unitarias", 5),
                new Task(8, "Hacer deploy en servidores", 5),
                new Task(9, "Realizar el cronograma", 5)
            };
        }

    }

}