
namespace ProgramacionFuncionalCSharp.Queries
{
    public class Query
    {
        private readonly static List<User> users = User.Users();
        private readonly static List<Task> tasks = Task.Tasks();
        public static void MethodOrdenamiento()
        {
            Console.WriteLine("obtener el nombre de los usuarios mayores de 50, femenino y ordenar nombre descendentemente");
            users.Where(u => u.Age > 50 && u.Gender == "Female")
            .OrderByDescending(u => u.Username).Select(u => u.Username)
            .ToList().ForEach(username => Console.WriteLine(username));
        }

        public static void Method_IN_SQL()
        {
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
            (
                from num in numeros
                let cuadrado = num * num
                //se utiliza generalmente para los filtros
                where cuadrado > 50
                select cuadrado
            ).ToList()
            .ForEach(cuadrado => Console.WriteLine(cuadrado));
        }

        public static void MethodLeftJoin()
        {
            Console.WriteLine("Obtener el username de los usuarios que no tengan tareas asignadas");
            (
                from usuario in users
                join tarea in tasks
                on usuario.Id equals tarea.UserId
                //se agrega la relación del join en una nueva variable
                into relacionJoin
                //DefaultIfEmpty() se utiliza para traer la parte izquierda y la intersección de la relación
                from leftData in relacionJoin.DefaultIfEmpty()
                //Ahora obtenemos los valores que no estan en la intersección, es decir los null
                where leftData == null
                select usuario.Username
            ).ToList()
            .ForEach(username => Console.WriteLine(username));
        }
    }
}