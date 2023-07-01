
namespace ProgramacionFuncionalCSharp.Queries
{
    public class Query
    {
        private readonly static List<User> users = User.Users();
        public static void MethodOrdenamiento()
        {
            Console.WriteLine("obtener el nombre de los usuarios mayores de 50, femenino y ordenar nombre descendentemente");
            users.Where(u => u.age > 50 && u.gender == "Female")
            .OrderByDescending(u => u.username).Select(u => u.username)
            .ToList().ForEach(username => Console.WriteLine(username));
        }

        public static void Method_IN_SQL()
        {
            //IN
            Console.WriteLine("obtener los usuarios 5, 6 y 7");
            users.Where(user => new int[] { 5, 6, 7 }.Contains(user.id))
                .ToList().ForEach(user => Console.WriteLine(user.username));

            //NO INT
            Console.WriteLine("Obtener los usuarios, menos 5, 6 y 7:");
            users.Where(user => !(new int[] { 5, 6, 7 }.Contains(user.id)))
                .ToList().ForEach(user => Console.WriteLine(user.username));
        }
    }
}