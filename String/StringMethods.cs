namespace ProgramacionFuncionalCSharp.String
{
    public class StringMethods
    {
        private readonly static List<ProgramacionFuncionalCSharp.LINQ.Task> tasks = ProgramacionFuncionalCSharp.LINQ.Task.Tasks();

        public static void StartsWith()
        {
            Console.WriteLine("Obtener los nombres de las tareas que empiezan con las letras 're'");
            //sensitive case, reconoce mayusculas y minusculas
            tasks.Where(task => task.Title.StartsWith("Re"))
            .ToList()
            .ForEach(task => Console.WriteLine(task.Title));
        }

        //TODO: implement
        public static void IsNullOrEmpty()
        {
            Console.WriteLine(">>>obtener<<<");

        }

        public static void Compare()
        {
            
        }
    }
}