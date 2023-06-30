
using System.Linq;

namespace ProgramacionFuncionalCSharp.Linq
{
    public class Linq
    {
        private static readonly List<int> calificaciones = new() { 1, 2, 3, 3, 4, 5, 6, 7, 8, 9, 9, 10 };
        public static void MethodLinqWhere()
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
    }
}