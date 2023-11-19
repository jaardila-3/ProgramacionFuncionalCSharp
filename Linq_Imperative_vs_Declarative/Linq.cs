
using System.Linq;

namespace ProgramacionFuncionalCSharp.Linq
{
    public class Linq
    {
        private static readonly List<int> calificaciones = new() { 1, 9, 3, 3, 9, 5, 6, 7, 8, 2, 4, 10 };

        //Filter --> Where
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

        //Map --> Select
        public static void MethodLinqSelect()
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

        //Reduce --> Aggregate
        public static void MethodLinqAggregate()
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

        public static void MethodLinqDistinct()
        {
            Console.WriteLine(">>>obtener las calificaciones que son diferentes<<<");
            Console.WriteLine("Declarativo");
            var result = calificaciones.Distinct().OrderBy(c => c);
            foreach (var item in result)
                Console.WriteLine(item);
        }

        public static void MethodLinqCount()
        {
            Console.WriteLine(">>>obtener cuantas calificaciones hay y cuantas son mayores a 5<<<");
            Console.WriteLine("Declarativo");
            var totalCalificaciones = calificaciones.Count();
            var mayorQueCinco = calificaciones.Count(c => c > 5);
            Console.WriteLine($" Hay {totalCalificaciones} y {mayorQueCinco} son mayor a 5");
        }

        public static void MethodLinqOrderBy()
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

        public static void MethodLinqForEach()
        {
            Console.WriteLine(">>>ordenar calificaciones<<<");
            Console.WriteLine("Declarativo");
            Console.WriteLine("Asc with method ForEach");
            calificaciones.OrderBy(c => c)
            //debe ser una lista, si no lo es, la convertimos.
            .ToList()
            .ForEach(item => Console.WriteLine(item));
        }

        public static void MethodsLinqFindElementsAndReturnBool()
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

        public static void MethodsLinqFindElementsAndReturnElements()
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

        public static void MethodLinqMathematical()
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

        public static void MethodLinqPartitionAndPagination()
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
    }
}