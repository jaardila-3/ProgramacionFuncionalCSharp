namespace ProgramacionFuncionalCSharp.String
{
    public class StringMethods
    {
        private readonly static List<LINQ.Task> tasks = LINQ.Task.Tasks();

        public static void StartsWith()
        {
            //Determina si el principio de la instancia de cadena coincide con la cadena especificada.
            Console.WriteLine("Obtener los nombres de las tareas que empiezan con las letras 're'");
            //sensitive case, reconoce mayusculas y minusculas
            tasks.Where(task => task.Title.StartsWith("Re"))
            .ToList()
            .ForEach(task => Console.WriteLine(task.Title));
            Console.WriteLine();
        }

        public static void EndsWith()
        {
            //Determina si el final de esta instancia de cadena coincide con una cadena especificada.
            string str = "Hello World";
            bool result = str.EndsWith("World");
            Console.WriteLine(result); // Output: True
        }

        public static void IsNullOrEmpty()
        {
            //Indica si el valor de la cadena especificada es null o una cadena vacía ("").
            Console.WriteLine("Obtener los nombres de las tareas que no esten vacías");
            tasks.Where(task => !string.IsNullOrEmpty(task.Title))
            .ToList()
            .ForEach(task => Console.WriteLine(task.Title));
            Console.WriteLine();
        }

        public static void Compare()
        {
            /*
            El método string.Compare devuelve un valor entero que indica la relación lexicográfica entre dos cadenas.
            Resultado igual a 0: Indica que las dos cadenas son iguales.
            Resultado menor que 0: Indica que la primera cadena es lexicográficamente menor que la segunda.
            Resultado mayor que 0: Indica que la primera cadena es lexicográficamente mayor que la segunda.
            */
            string str1 = "abc";
            string str2 = "def";
            int result = string.Compare(str1, str2);
            Console.WriteLine($"Comparación simple: {result}"); //-1
            Console.WriteLine();

            str2 = "ABC";
            result = string.Compare(str1, str2, StringComparison.OrdinalIgnoreCase);
            //tambien se puede usar con un boolean
            int result2 = string.Compare(str1, str2, true);
            Console.WriteLine($"Comparación sin distinción entre mayúsculas y minúsculas: {result}"); // 0
            Console.WriteLine($"Comparación sin distinción entre mayúsculas y minúsculas: {result2}"); // 0
            Console.WriteLine();
        }

        public static void Concat()
        {
            //Concatena una o más instancias de String o las representaciones de tipo String de los valores de una o más instancias de Object
            string str1 = "Hello";
            string str2 = "World";
            string result = string.Concat(str1, str2);
            Console.WriteLine(result); // Output: HelloWorld

            int number = 42;
            string result2 = string.Concat("The answer is ", number);
            Console.WriteLine(result2); // Output: The answer is 42

            object obj1 = "Hello";
            object obj2 = "World";
            string result3 = string.Concat(obj1, obj2);
            Console.WriteLine(result3); // Output: HelloWorld

            object[] objs = new object[] { "The answer is ", number, " and ", obj1 };
            string result4 = string.Concat(objs);
            Console.WriteLine(result4); // Output: The answer is 42 and Hello

        }

        public static void Contains()
        {
            //Devuelve un valor boolean que indica si un carácter especificado aparece dentro de esta cadena.
            string str = "Hello World";
            bool result = str.Contains("World");
            Console.WriteLine(result); // Output: True
        }

        public static void Format()
        {
            //Convierte el valor de los objetos en cadenas en función de los formatos especificados y los inserta en otra cadena.

            // >>>>>>>>>>>> Formateo básico <<<<<<<<<<<<<<
            string nombre = "Juan";
            int edad = 30;
            Console.WriteLine(string.Format("Hola, mi nombre es {0} y tengo {1} años.", nombre, edad));
            // resultado = "Hola, mi nombre es Juan y tengo 30 años."
            Console.WriteLine();

            // >>>>>>>>>> Formateo con especificadores de formato <<<<<<<<<<<<<

            // {0:C}: Formatea un valor numérico como moneda. Por ejemplo, 
            Console.WriteLine(string.Format("{0:C}", 123.45)); //devuelve "$ 123,45".
            Console.WriteLine(string.Format("Precio: {0:C2}.", 19.4567)); //C2 indica que se formatee con dos decimales redondeando. devuelve "Precio: $19,46."
            // {0:D}: Formatea un valor numérico como un número entero con signo. Por ejemplo, 
            Console.WriteLine(string.Format("{0:D}", -123));// devuelve "-123".
            // {0:E}: Formatea un valor numérico en notación científica. Por ejemplo, 
            Console.WriteLine(string.Format("{0:E}", 123.45));// devuelve "1,234500E+002".
            // {0:F}: Formatea un valor numérico como un número de punto flotante con una cantidad fija de decimales. Por ejemplo, 
            Console.WriteLine(string.Format("{0:F2}", 123.456));// devuelve "123,46".
            // {0:N}: Formatea un valor numérico con separadores de miles y decimales. Por ejemplo, 
            Console.WriteLine(string.Format("{0:N}", 123456.789));// devuelve "123.456,79".
            // {0:X}: Convierte un valor numérico en una cadena hexadecimal. Por ejemplo, 
            Console.WriteLine(string.Format("{0:X}", 255));// devuelve "FF".

            Console.WriteLine();

            // >>>>>>>>>>>>> Formateo con alineación de columnas <<<<<<<<<<<<<<
            /*
            cada columna se especifica con {n,-m}, donde n es el índice del argumento y m es la cantidad de caracteres que se deben utilizar para esa columna.
            El signo - indica que el valor debe alinearse a la izquierda. Por lo tanto, {0,-10} indica que el primer argumento debe alinearse a la izquierda y
            utilizar 10 caracteres.
            */
            Console.WriteLine(string.Format("|{0,-10}|{1,-10}|{2,-10}|", "Columna 1", "Columna 2", "Columna 3"));
            Console.WriteLine(string.Format("|{0,-10}|{1,-10}|{2,-10}|", 1, 2, 3));
            // resultado = "|Columna 1 |Columna 2 |Columna 3 |"
            //              |1         |2         |3         |      

        }

        public static void Join()
        {
            //Concatena los elementos de la matriz especificada o los miembros de una colección, usando el separador indicado entre todos los elementos o miembros
            // Ejemplo 1: Unir una matriz de cadenas con un separador
            string[] palabras = { "Hola", "mundo", "!" };
            string resultado1 = string.Join(" ", palabras);
            Console.WriteLine(resultado1); // Output: "Hola mundo !"

            // Ejemplo 2: Unir una lista de cadenas con un separador
            List<string> nombres = new() { "Juan", "María", "Pedro" };
            string resultado2 = string.Join(", ", nombres);
            Console.WriteLine(resultado2); // Output: "Juan, María, Pedro"

            // Ejemplo 3: Unir una matriz de caracteres en una cadena
            char[] letras = { 'H', 'o', 'l', 'a' };
            string resultado3 = string.Join("", letras);
            Console.WriteLine(resultado3); // Output: "Hola"
        }

        public static void Replace()
        {
            //Devuelve una nueva cadena en la que todas las apariciones de un carácter Unicode especificado o String de la cadena actual se reemplazan por otro carácter Unicode especificado o String.
            string str = "1 2 3 4 5 6 7 8 9";
            Console.WriteLine("Original string: \"{0}\"", str);
            Console.WriteLine("CSV string:      \"{0}\"", str.Replace(' ', ','));
            // This example produces the following output:
            // Original string: "1 2 3 4 5 6 7 8 9"
            // CSV string:      "1,2,3,4,5,6,7,8,9"
        }

        public static void Substring()
        {
            //Recupera una subcadena de la instancia

            //La subcadena empieza en una posición de caracteres especificada y continúa hasta el final de la cadena.
            string str = "Hello World";
            string substring = str.Substring(6); // Retrieves the substring starting from index 6 to the end of the string
            Console.WriteLine(substring); // Output: "World"

            //La subcadena comienza en una posición de carácter especificada y tiene una longitud especificada.
            string substring2 = str.Substring(6, 5); // Retrieves the substring starting from index 6 to 5 characters
            Console.WriteLine(substring2); // Output: "World"
        }

        public static void Trim()
        {
            //Trim(): Quita todos los caracteres de espacio en blanco del principio y el final de la cadena actual.
            string texto1 = "   Hola, mundo!   ";
            string resultado1 = texto1.Trim();
            Console.WriteLine(resultado1); // Output: "Hola, mundo!"

            //Trim(Char[]): Quita todas las repeticiones del principio y el final de un conjunto de caracteres especificado en una matriz de la cadena actual.
            string texto2 = ",!Hello, devs!,   ";
            char[] caracteres = { ' ', '!', ',' };
            string resultado2 = texto2.Trim(caracteres);
            Console.WriteLine(resultado2); // Output: "Hello, devs"

            string banner = "*** Much Ado About Nothing ***";
            char[] charsToTrim = { '*', ' ', '\'' };
            string result = banner.Trim(charsToTrim);
            Console.WriteLine("{0}", result); // Output: "Much Ado About Nothing"

            //Trim(Char): Quita todas las instancias iniciales y finales de un carácter de la cadena actual.
            string text = ">>>>instancia completa>>>";
            char character = '>';
            string result1 = text.Trim(character);
            Console.WriteLine(result1); // Output: instancia completa"

        }

        public static void TrimEnd()
        {
            //TrimEnd(): Quita todos los caracteres de espacio en blanco al final de la cadena actual.
            string texto1 = "Hola, mundo!   ";
            string resultado1 = texto1.TrimEnd();
            Console.WriteLine(resultado1); // Output: "Hola, mundo!"

            //TrimEnd(Char[]): Quita todas las repeticiones al final de un conjunto de caracteres especificado en una matriz de la cadena actual.
            string texto2 = "Hello, devs!,, ";
            char[] caracteres = { ' ', '!', ',' };
            string resultado2 = texto2.TrimEnd(caracteres);
            Console.WriteLine(resultado2); // Output: "Hello, devs"

            string banner = "Much Ado About Nothing ***";
            char[] charsToTrimEnd = { '*', ' ', '\'' };
            string result = banner.TrimEnd(charsToTrimEnd);
            Console.WriteLine("{0}", result); // Output: "Much Ado About Nothing"

            //TrimEnd(Char): Quita todas las instancias finales de un carácter de la cadena actual.
            string text = "instancia completa>>>>>>>";
            char character = '>';
            string result1 = text.TrimEnd(character);
            Console.WriteLine(result1); // Output: instancia completa"
        }

        public static void TrimStart()
        {
            //TrimStart(): Quita todos los caracteres de espacio en blanco del principio de la cadena actual.
            string texto1 = "    Hola, mundo";
            string resultado1 = texto1.TrimStart();
            Console.WriteLine(resultado1); // Output: "Hola, mundo!"

            //TrimStart(Char[]): Quita todas las repeticiones del principio de un conjunto de caracteres especificado en una matriz de la cadena actual.
            string texto2 = " ,!Hello, devs";
            char[] caracteres = { ' ', '!', ',' };
            string resultado2 = texto2.TrimStart(caracteres);
            Console.WriteLine(resultado2); // Output: "Hello, devs"

            string banner = "*** Much Ado About Nothing";
            char[] charsToTrimStart = { '*', ' ', '\'' };
            string result = banner.TrimStart(charsToTrimStart);
            Console.WriteLine("{0}", result); // Output: "Much Ado About Nothing"

            //TrimStart(Char): Quita todas las instancias iniciales de un carácter de la cadena actual.
            string text = ">>>>instancia completa";
            char character = '>';
            string result1 = text.TrimStart(character);
            Console.WriteLine(result1); // Output: instancia completa"
        }

        public static void ToLower()
        {
            //Devuelve una copia de esta cadena convertida en minúsculas.
            string[] info = { "Name", "Title", "Age", "Location", "Gender" };
            foreach (string s in info)
                Console.WriteLine(s.ToLower());

            //       name
            //       title
            //       age
            //       location
            //       gender
        }

        public static void ToUpper()
        {
            //
            string[] info = { "Name", "Title", "Age", "Location", "Gender" };
            foreach (string s in info)
                Console.WriteLine(s.ToUpper());

            //       NAME
            //       TITLE
            //       AGE
            //       LOCATION
            //       GENDER
        }

    }
}