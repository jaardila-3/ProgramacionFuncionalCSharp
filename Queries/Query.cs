
namespace ProgramacionFuncionalCSharp.Queries
{
    public class Query
    {
        private readonly static List<User> users = User.Users();
        private readonly static List<Task> tasks = Task.Tasks();

        public static void MethodOrdenamiento()
        {
            Console.WriteLine("obtener el nombre de los users mayores de 50, femenino y ordenar nombre descendentemente");

            Console.WriteLine("\n>>>>> Linq: sintaxis de método");
            users.Where(u => u.Age > 50 && u.Gender == "Female")
            .OrderByDescending(u => u.Username).Select(u => u.Username)
            .ToList().ForEach(username => Console.WriteLine(username));
        }

        public static void Method_IN_SQL()
        {
            Console.WriteLine("\n>>>>> Linq: sintaxis de método");
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

            Console.WriteLine("\n>>>>> Linq: sintaxis de consulta");
            (
                from num in numeros
                let cuadrado = num * num
                //se utiliza generalmente para los filtros
                where cuadrado > 50
                select cuadrado
            ).ToList()
            .ForEach(cuadrado => Console.WriteLine(cuadrado));
        }

        public static void MethodJoin()
        {
            Console.WriteLine("Obtener el username de los usuarios y las tareas asignadas");

            Console.WriteLine("\n>>>>> Linq: sintaxis de consulta");
            (from user in users
             join task in tasks
             on user.Id equals task.UserId
             select new
             {
                 Usuario = user.Username,
                 Tarea = task.Title
             }).ToList()
            .ForEach(userTask => Console.WriteLine($"{userTask.Usuario}: {userTask.Tarea}"));

            Console.WriteLine("\n>>>>> Linq: sintaxis de método");
            users.Join(tasks, user => user.Id, task => task.UserId,
                (user, task) => new { Usuario = user.Username, Tarea = task.Title })
            .ToList()
            .ForEach(userTask => Console.WriteLine($"{userTask.Usuario}: {userTask.Tarea}"));
        }

        public static void MethodGroupBy()
        {
            Console.WriteLine("Obtener la cantidad de tareas por cada usuario, ordenar el resultado de mayor a menor");

            Console.WriteLine("\n>>>>> Linq: sintaxis de consulta");
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

            Console.WriteLine("\n>>>>> Linq: sintaxis de método");
            users.Join(tasks, user => user.Id, task => task.UserId,
                (user, task) => new { Usuario = user.Username, Tarea = task.Title })
            .GroupBy(userTask => userTask.Usuario)
            .OrderByDescending(groupUser => groupUser.Count())
            .Select(groupUser => new { Usuario = groupUser.Key, Cantidad = groupUser.Count() })
            .ToList()
            .ForEach(userTask => Console.WriteLine($"{userTask.Usuario}: {userTask.Cantidad} tareas"));

        }

        public static void MethodLeftJoin()
        {
            Console.WriteLine("Obtener el username de los usuarios que no tengan tareas asignadas");

            Console.WriteLine("\n>>>>> Linq: sintaxis de consulta");
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

            Console.WriteLine("\n>>>>> Linq: sintaxis de método");
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