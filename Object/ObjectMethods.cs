namespace ProgramacionFuncionalCSharp.Object
{
    public class ObjectMethods
    {
        readonly static object obj = "Hola";
        readonly static string str = "Hola";
        readonly static int number = 123;
        readonly static DateTime today = DateTime.Today;

        public static void MethodGetHashCode()
        {
            //Devuelve el hash de un objeto.
            Console.WriteLine($"HashCode de obj: {obj.GetHashCode()}");
            Console.WriteLine($"HashCode de str: {str.GetHashCode()}");
            Console.WriteLine($"HashCode de number: {number.GetHashCode()}");
            Console.WriteLine($"HashCode de today: {today.GetHashCode()}");
            Console.WriteLine();
        }

        public static void Equals()
        {
            //Determina si el objeto especificado es igual que el objeto actual.
            Console.WriteLine($"obj es igual a str?: {obj.Equals(str)}");
            Console.WriteLine($"obj es igual a number?: {obj.Equals(number)}");
            Console.WriteLine($"obj es igual a today?: {obj.Equals(today)}");
            Console.WriteLine();

            Console.WriteLine($"obj es igual a str?: {object.Equals(obj, str)}");
            Console.WriteLine($"obj es igual a number?: {object.Equals(obj, number)}");
            Console.WriteLine($"obj es igual a today?: {object.Equals(obj, today)}");
            Console.WriteLine();
        }

        public static void ToString_()
        {
            //Devuelve una cadena que representa el objeto actual.
            Console.WriteLine("cadena de obj: " + obj.ToString());
            Console.WriteLine("cadena de str: " + str.ToString());
            Console.WriteLine("cadena de number: " + number.ToString());
            Console.WriteLine("cadena de today: " + today.ToString());
            Console.WriteLine();
        }

        public static void GetType_()
        {
            //Obtiene el Type de la instancia actual.
            Console.WriteLine("Tipo de obj: " + obj.GetType());
            Console.WriteLine("Tipo de number: " + number.GetType());
            Console.WriteLine("Tipo de str: " + str.GetType());
            Console.WriteLine("Tipo de today: " + today.GetType());
            Console.WriteLine();
        }

        public static void ReferenceEquals()
        {
            //Determina si las instancias de Object especificadas son la misma instancia.
            //No pase argumentos con el tipo de valor "int" o "DateTime" a "ReferenceEquals", en su lugar use Equals()
            Console.WriteLine($"obj referencia igual a str?: {object.ReferenceEquals(obj, str)}");
            Console.WriteLine();
        }
    }
}