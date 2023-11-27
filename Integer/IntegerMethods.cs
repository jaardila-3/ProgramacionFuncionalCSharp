namespace ProgramacionFuncionalCSharp.Integer
{
    public class IntegerMethods
    {
        public static void TryParse()
        {
            //se utiliza para convertir una cadena en un número entero. Si la conversión es exitosa, el método devuelve true y 
            //el número entero se almacena en una variable de salida. Si la conversión falla, el método devuelve false y 
            //la variable de salida se establece en cero.
            string str = "1234";
            int number;
            bool conversion = int.TryParse(str, out number);
            if (conversion)
                Console.WriteLine(number);
            else
                Console.WriteLine("No se pudo convertir " + number);
        }

        public static void Parse()
        {
            //Parse es un método de extensión que se utiliza para convertir una cadena en un número entero. 
            //Si la conversión es exitosa, el método devuelve el número entero. Si la conversión falla, el método lanza una excepción.
            string str = "1234";
            int number = int.Parse(str);
            Console.WriteLine(number); // Output: 1234
        }

        public static void CompareTo()
        {
            //CompareTo es un método de extensión que se utiliza para comparar dos números enteros.
            //Si el primer número es menor que el segundo, el método devuelve un número negativo -1.
            //Si el primer número es mayor que el segundo, el método devuelve un número positivo 1.
            //Si los números son iguales, el método devuelve cero.
            int numberOne = 10, numberTwo = 20;
            Console.WriteLine(numberOne.CompareTo(numberTwo)); // Output: -1
        }

    }
}