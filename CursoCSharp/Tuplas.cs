
namespace ProgramacionFuncionalCSharp.CursoCSharp
{
    public class Tuplas
    {
        public static void MethodTuplas()
        {
            //declarar tupla
            (double, int) t1 = (4.5, 3);
            Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}.");

            //declarar tupla con var y asignar nombres a sus items
            var t = (Sum: 4.5, Count: 3);
            Console.WriteLine($"Sum of {t.Count} elements is {t.Sum}.");

            //declarar tupla y nombre de sus items
            (int id, string name) product = (1, "cerveza stout");
            Console.WriteLine($"{product.id} {product.name}");
            product.name = "cerveza porter";
            Console.WriteLine($"{product.id} {product.name}");

            //declarar tupla con var
            var person = (1, "Héctor");
            Console.WriteLine($"persna {person.Item1} {person.Item2}");

            //declarar tupla dentro de array con var
            var people = new[] { (1, "Héctor"), (2, "Pedro"), (3, "Juan") };
            foreach (var p in people)
                Console.WriteLine($"{p.Item1} {p.Item2}");

            //declarar tupla dentro de array con nombre de sus items
            (int id, string name)[] people2 = new[] { (1, "Héctor"), (2, "Pedro"), (3, "Juan") };
            foreach (var p in people2)
                Console.WriteLine($"{p.id} {p.name}");

            //asignar valores a una tupla
            var sum = 4.5;
            var count = 3;
            var tup = (sum, count);
            Console.WriteLine($"Sum of {tup.count} elements is {tup.sum}.");

            //declarar tuplas en funciones, se usa funcion local pero puede ser cualquier funcion: public (float lat, float lng, string name) GetLocationCDMX(){...}
            static (float lat, float lng, string name) GetLocationCDMX()
            {
                float lat = 19.12121f;
                float lng = -99.19212f;
                string name = "CDMX";
                return (lat, lng, name);
            }

            var cityInfo = GetLocationCDMX();
            Console.WriteLine($"lat: {cityInfo.lat} long: {cityInfo.lng} nombre: {cityInfo.name}");

            var (_, lng, _) = GetLocationCDMX();
            Console.WriteLine(lng);

        }
    }
}