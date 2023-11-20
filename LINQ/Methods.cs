
namespace ProgramacionFuncionalCSharp.LINQ
{
    public class LinqMethods
    {
        #region variables
        private static readonly List<int> calificaciones = new() { 1, 9, 3, 3, 9, 5, 6, 7, 8, 2, 4, 10 };
        private static readonly List<object> calificacionesMixted = new() { "1", "3", "6", 7, 8, 2, 4, 10 };
        private readonly static List<User> users = User.Users();
        private readonly static List<Task> tasks = Task.Tasks();
        #endregion

        #region Filtrado
        //Filter --> Where
        public static void Where()
        {
            Console.WriteLine(">>>obtener calificaciones mayores a 8<<<");

            Console.WriteLine("Imperativo");
            foreach (var item in calificaciones)
                if (item > 8) Console.WriteLine(item);

            Console.WriteLine("Declarativo");
            var result1 = calificaciones.Where(c => c > 8);
            foreach (var item in result1)
                Console.WriteLine(item);

            ///////////////////////////////////
            Console.WriteLine(">>>obtener la cantidad de calificaciones mayores a 8<<<");

            Console.WriteLine("Imperativo");
            int contador = 0;
            foreach (var item in calificaciones)
                if (item > 8) contador++;
            Console.WriteLine(contador);

            Console.WriteLine("Declarativo");
            var result2 = calificaciones.Where(c => c > 8);
            Console.WriteLine(result2.Count());
        }

        public static void WhereWithLet()
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

        //TODO: implement OfType method with calificacionesMixted
        public static void OfType()
        {
            Console.WriteLine(">>>obtener calificaciones de tipo string <<<");

        }

        public static void Find_Single_First_ReturnElements()
        {
            Console.WriteLine(">>>Encontrar elementos<<<");

            Console.WriteLine("Declarativo");

            //si no existe el elemento retorna el valor por defecto del tipo de dato esperado
            int result = calificaciones.Find(c => c == 3);
            Console.WriteLine($"retorna el: {result}");

            //si no existe el elemento o hay mas de una coincidencia retorna una excepción
            int result2 = calificaciones.Single(c => c == 4);
            Console.WriteLine($"retorna el: {result2}");

            //devuelve el primer elemento que coincida o exepción si no hay coincidencias
            int result3 = calificaciones.First(c => c == 3);
            Console.WriteLine($"retorna el: {result3}");
        }
        
        //TODO: implement
        public static void Last()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        //TODO: implement
        public static void ElementAt()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        //TODO: implement
        public static void DefaultIfEmpty()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        #endregion

        #region Proyección
        //Map --> Select
        public static void Select()
        {
            Console.WriteLine(">>>obtener el cuadrado de las calificaciones<<<");

            Console.WriteLine("Imperativo");
            foreach (var item in calificaciones)
                Console.WriteLine(item * item);

            Console.WriteLine("Declarativo");
            var result = calificaciones.Select(c => c * c);
            foreach (var item in result)
                Console.WriteLine(item);

        }

        //TODO: implement
        public static void SelectMany()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        #endregion

        #region Ordenamiento
        public static void OrderBy()
        {
            Console.WriteLine(">>>ordenar calificaciones<<<");
            Console.WriteLine("Declarativo");
            Console.WriteLine("Asc");
            var result = calificaciones.OrderBy(c => c);
            foreach (var item in result)
                Console.WriteLine(item);

            Console.WriteLine("Des with -");
            var result2 = calificaciones.OrderBy(c => -c);
            foreach (var item in result2)
                Console.WriteLine(item);

            Console.WriteLine("Des with OrderByDescending");
            var result3 = calificaciones.OrderByDescending(c => c);
            foreach (var item in result3)
                Console.WriteLine(item);
        }

        public static void OrderByDescending()
        {
            Console.WriteLine("obtener el nombre de los users mayores de 50, femenino y ordenar nombre descendentemente");

            Console.WriteLine("\n>>>>> Linq: sintaxis métodos de extensión");
            users.Where(u => u.Age > 50 && u.Gender == "Female")
            .OrderByDescending(u => u.Username).Select(u => u.Username)
            .ToList()
            .ForEach(username => Console.WriteLine(username));
        }

        //TODO: implement
        public static void ThenBy()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        //TODO: implement
        public static void ThenByDescending()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        //TODO: implement
        public static void Reverse()
        {
            Console.WriteLine(">>>obtener<<<");

        }
        #endregion

        #region Agrupación
        public static void GroupBy()
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

        //TODO: implement
        public static void GroupJoin()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        #endregion

        #region Unión y Conjuntos
        public static void Join()
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

        public static void LeftJoin()
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

        public static void Contains()
        {
            Console.WriteLine("\n>>>>> Linq: sintaxis métodos de extensión");
            //IN SQL
            Console.WriteLine("obtener los usuarios 5, 6 y 7");
            users.Where(user => new int[] { 5, 6, 7 }.Contains(user.Id))
                .ToList().ForEach(user => Console.WriteLine(user.Username));

            //NO INT SQL
            Console.WriteLine("Obtener los usuarios, menos 5, 6 y 7:");
            users.Where(user => !(new int[] { 5, 6, 7 }.Contains(user.Id)))
                .ToList().ForEach(user => Console.WriteLine(user.Username));
        }

        public static void Distinct()
        {
            Console.WriteLine(">>>obtener las calificaciones que son diferentes<<<");
            Console.WriteLine("Declarativo");
            var result = calificaciones.Distinct().OrderBy(c => c);

            foreach (var item in result)
                Console.WriteLine(item);
        }

        public static void Contains_Any_All_ReturnBool()
        {
            Console.WriteLine(">>>Encontrar calificación<<<");

            Console.WriteLine("Declarativo");

            bool existSeven = calificaciones.Contains(7);
            Console.WriteLine($"¿existe el 7?: {existSeven}");

            bool existEleven = calificaciones.Any(c => c == 11);
            Console.WriteLine($"¿existe el 11?: {existEleven}");

            bool todosSonMayorQueSeis = calificaciones.All(c => c > 6);
            Console.WriteLine($"¿todos son mayor que seis?: {todosSonMayorQueSeis}");
        }

        //TODO: implement
        public static void Union()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        //TODO: implement
        public static void Concat()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        //TODO: implement
        public static void Except()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        //TODO: implement
        public static void Intersect()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        #endregion

        #region Paginación
        public static void Take_Skip()
        {
            Console.WriteLine("Declarativo");

            // Ejemplo con Take
            Console.WriteLine("Retorna las primeras 3 calificaciones");
            var primerosTres = calificaciones.Take(3);
            Console.WriteLine("Los primeros tres elementos de la lista son:");
            foreach (var calificacion in primerosTres)
                Console.WriteLine(calificacion);

            // Ejemplo con Skip
            Console.WriteLine("Retorna sin las primeras 3 calificaciones");
            var sinPrimerosTres = calificaciones.Skip(3);
            Console.WriteLine("La lista sin los primeros tres elementos es:");
            foreach (var calificacion in sinPrimerosTres)
                Console.WriteLine(calificacion);
        }

        //TODO: implement
        public static void TakeWhile()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        //TODO: implement
        public static void SkipWhile()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        #endregion

        #region Agregación y reducción
        //Reduce --> Aggregate
        public static void Aggregate()
        {
            Console.WriteLine(">>>obtener la suma de las calificaciones<<<");

            Console.WriteLine("Imperativo");
            int suma = 0;
            foreach (var item in calificaciones)
                suma += item;
            Console.WriteLine(suma);

            Console.WriteLine("Declarativo");
            var result = calificaciones.Aggregate((acc, item) => acc + item);
            Console.WriteLine(result);
        }

        public static void Count()
        {
            Console.WriteLine(">>>obtener cuantas calificaciones hay y cuantas son mayores a 5<<<");
            Console.WriteLine("Declarativo");
            //LongCount() se usa cuando el resultado es un número demasiado grande.
            var totalCalificaciones = calificaciones.LongCount();
            var mayorQueCinco = calificaciones.Count(c => c > 5);
            Console.WriteLine($" Hay {totalCalificaciones} y {mayorQueCinco} son mayor a 5");
        }

        public static void Average_Max_Min_Sum()
        {
            Console.WriteLine(">>>Realizar algunas operaciones matemáticas con las calificaciones<<<");
            Console.WriteLine("Declarativo");
            List<int> calificaciones = new() { 1, 9, 3, 3, 9, 5, 6, 7, 8, 2, 4, 10 };

            double average = calificaciones.Average();
            int max = calificaciones.Max();
            int min = calificaciones.Min();
            int sum = calificaciones.Sum();

            Console.WriteLine($"Promedio: {average}");
            Console.WriteLine($"Máximo: {max}");
            Console.WriteLine($"Mínimo: {min}");
            Console.WriteLine($"Suma: {sum}");
        }

        public static void MaxBy_MinBy()
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
        #endregion

        #region Conversión
        public static void ToList()
        {
            Console.WriteLine(">>>ordenar calificaciones<<<");
            Console.WriteLine("Declarativo");
            Console.WriteLine("Asc with method ForEach");
            calificaciones.OrderBy(c => c)
            //debe ser una lista, si no lo es, la convertimos.
            .ToList()
            .ForEach(item => Console.WriteLine(item));
        }

        public static void ToLookUp()
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
        
        //TODO: implement
        public static void ToArray()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        //TODO: implement
        public static void ToDictionary()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        #endregion

    }
}