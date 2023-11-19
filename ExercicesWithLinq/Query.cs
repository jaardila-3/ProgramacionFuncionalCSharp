
namespace ProgramacionFuncionalCSharp.ExercicesWithLinq
{
    public class Query
    {
        private readonly static List<User> users = User.Users();
        private readonly static List<Task> tasks = Task.Tasks();

        public static void MethodOrdenamiento()
        {
            Console.WriteLine("obtener el nombre de los users mayores de 50, femenino y ordenar nombre descendentemente");

            Console.WriteLine("\n>>>>> Linq: sintaxis métodos de extensión");
            users.Where(u => u.Age > 50 && u.Gender == "Female")
            .OrderByDescending(u => u.Username).Select(u => u.Username)
            .ToList().ForEach(username => Console.WriteLine(username));
        }

        public static void Method_IN_SQL()
        {
            Console.WriteLine("\n>>>>> Linq: sintaxis métodos de extensión");
            //IN
            Console.WriteLine("obtener los usuarios 5, 6 y 7");
            users.Where(user => new int[] { 5, 6, 7 }.Contains(user.Id))
                .ToList().ForEach(user => Console.WriteLine(user.Username));

            //NO INT
            Console.WriteLine("Obtener los usuarios, menos 5, 6 y 7:");
            users.Where(user => !(new int[] { 5, 6, 7 }.Contains(user.Id)))
                .ToList().ForEach(user => Console.WriteLine(user.Username));
        }

        public static void MethodLetVariableInLinq()
        {
            Console.WriteLine("Dado una lista de numeros, mostrar el cuadrado de cada uno de los elementos, si y solo si, dicho cuadrado es mayor a 50");
            var numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            Console.WriteLine("\n>>>>> Linq: sintaxis expresiones de consulta");
            (
                from num in numeros
                let cuadrado = num * num
                //se utiliza generalmente para los filtros
                where cuadrado > 50
                select cuadrado
            ).ToList()
            .ForEach(cuadrado => Console.WriteLine(cuadrado));
        }

        public static void MethodStartsWith()
        {
            Console.WriteLine("Obtener los nombres de las tareas que empiezan con las letras 're'");
            //sensitive case, reconoce mayusculas y minusculas
            tasks.Where(task => task.Title.StartsWith("Re"))
            .ToList()
            .ForEach(task => Console.WriteLine(task.Title));
        }

        public static void Method_MaxBy_MinBy()
        {
            //MaxBy y MinBy me devuleve el objeto completo mientras que Max solo devuelve el valor primitivo consultado
            Console.WriteLine("Obtener la tarea con el mayor y el menor userId");
            var taskWithMaxUserId = tasks.MaxBy(task => task.UserId);
            var taskWithMinUserId = tasks.MinBy(task => task.UserId);
            //el signo ! me indica que la propiedad es no nullable, es decir siempre viene con datos
            // y en este caso es porque es un archivo que tengo con datos hardcodeados, lo cual nunca es null
            Console.WriteLine($"tarea con mayor userId es la tarea {taskWithMaxUserId!.Id}: {taskWithMaxUserId!.Title}");
            Console.WriteLine($"tarea con menor userId es la tarea {taskWithMinUserId!.Id}: {taskWithMinUserId!.Title}");
        }

        public static void MethodToLookUp()
        {
            Console.WriteLine("Agrupar los usuarios por género");
            // ToLookup se utiliza para agrupar elementos de una secuencia según una clave específica.
            // La sintaxis básica de ToLookup toma un solo parámetro, que es una expresión lambda 
            // que especifica la clave por la cual se agruparán los elementos.
            users.ToLookup(u => u.Gender)
            .ToList()
            .ForEach(group =>
            {
                Console.WriteLine($"Users with gender '{group.Key}':");
                // Iteramos sobre los usuarios en el grupo
                group.ToList().ForEach(user =>
                {
                    Console.WriteLine($"Id: {user.Id}, Username: {user.Username}, Age: {user.Age}");
                });
            });
            Console.WriteLine();

            //tambien se puede usar como el metodo GroupBy()
            Console.WriteLine("Obtener la cantidad de tareas por cada usuario, ordenar el resultado de mayor a menor");

            users.Join(tasks, user => user.Id, task => task.UserId,
                (user, task) => new { Usuario = user.Username, Tarea = task.Title })
            .ToLookup(userTask => userTask.Usuario)
            .OrderByDescending(groupUser => groupUser.Count())
            .Select(groupUser => new { Usuario = groupUser.Key, Cantidad = groupUser.Count() })
            .ToList()
            .ForEach(userTask => Console.WriteLine($"{userTask.Usuario}: {userTask.Cantidad} tareas"));
            Console.WriteLine();

            //ToLookup puede utilizarse de manera similar a un diccionario si le proporcionas una clave
            // al momento de acceder a los grupos. Puedes aprovechar la capacidad de ILookup para realizar
            // búsquedas basadas en la clave
            Console.WriteLine("Obtener las tareas para un nombre de usuario específico");
            var tasksByUser = from task in tasks
                              join user in users on task.UserId equals user.Id
                              select new { UserName = user.Username, Task = task };

            // Utilizamos ToLookup para agrupar las tareas por nombre de usuario
            var tasksByUserLookup = tasksByUser.ToLookup(t => t.UserName);

            // Buscamos las tareas para un nombre de usuario específico
            string userName = "user5";
            var tasksForUser = tasksByUserLookup[userName];
            Console.WriteLine($"Tasks for {userName}:");
            foreach (var task in tasksForUser)
            {
                Console.WriteLine($"Task Id: {task.Task.Id}, Title: {task.Task.Title}");
            };
            Console.WriteLine();
        }

        public static void MethodGroupBy()
        {
            Console.WriteLine("Obtener la cantidad de tareas por cada usuario, ordenar el resultado de mayor a menor");

            Console.WriteLine("\n>>>>> Linq: sintaxis expresiones de consulta");
            (from user in users
             join task in tasks
             on user.Id equals task.UserId
             //indicamos el campo a agrupar y guardamos la relacion en una nueva variable
             group user by user.Username into groupUser
             //ordenamos según la cantidad de elementos que tiene cada item agrupado
             orderby groupUser.Count() descending
             select new
             {
                 Usuario = groupUser.Key,
                 Cantidad = groupUser.Count()
             }).ToList()
            .ForEach(userTask => Console.WriteLine($"{userTask.Usuario}: {userTask.Cantidad} tareas"));
            Console.WriteLine();

            Console.WriteLine("\n>>>>> Linq: sintaxis métodos de extensión");
            users.Join(tasks, user => user.Id, task => task.UserId,
                (user, task) => new { Usuario = user.Username, Tarea = task.Title })
            .GroupBy(userTask => userTask.Usuario)
            .OrderByDescending(groupUser => groupUser.Count())
            .Select(groupUser => new { Usuario = groupUser.Key, Cantidad = groupUser.Count() })
            .ToList()
            .ForEach(userTask => Console.WriteLine($"{userTask.Usuario}: {userTask.Cantidad} tareas"));
        }

        public static void MethodJoin()
        {
            Console.WriteLine("Obtener el username de los usuarios y las tareas asignadas");

            Console.WriteLine("\n>>>>> Linq: sintaxis expresiones de consulta");
            (from user in users
             join task in tasks
             on user.Id equals task.UserId
             select new
             {
                 Usuario = user.Username,
                 Tarea = task.Title
             }).ToList()
            .ForEach(userTask => Console.WriteLine($"{userTask.Usuario}: {userTask.Tarea}"));

            Console.WriteLine("\n>>>>> Linq: sintaxis métodos de extensión");
            users.Join(tasks, user => user.Id, task => task.UserId,
                (user, task) => new { Usuario = user.Username, Tarea = task.Title })
            .ToList()
            .ForEach(userTask => Console.WriteLine($"{userTask.Usuario}: {userTask.Tarea}"));
        }

        public static void MethodLeftJoin()
        {
            Console.WriteLine("Obtener el username de los usuarios que no tengan tareas asignadas");

            Console.WriteLine("\n>>>>> Linq: sintaxis expresiones de consulta");
            (
                from user in users
                join task in tasks
                on user.Id equals task.UserId
                //se agrega la relación del join en una nueva variable
                into relacionJoin
                //DefaultIfEmpty() se utiliza para traer la parte izquierda y la intersección de la relación
                from leftData in relacionJoin.DefaultIfEmpty()
                    //Ahora obtenemos los valores que no estan en la intersección, es decir los null
                where leftData == null
                select user.Username
            ).ToList()
            .ForEach(username => Console.WriteLine(username));

            Console.WriteLine("\n>>>>> Linq: sintaxis métodos de extensión");
            users.GroupJoin(tasks, user => user.Id, task => task.UserId,
                (user, tasks) => new { Usuario = user.Username, Tareas = tasks })
            .SelectMany(userTasks => userTasks.Tareas.DefaultIfEmpty(),
                (userTasks, task) => new { userTasks.Usuario, Tarea = task })
            .Where(userTask => userTask.Tarea == null)
            .Select(userTask => userTask.Usuario)
            .ToList()
            .ForEach(username => Console.WriteLine(username));
        }
    }
}