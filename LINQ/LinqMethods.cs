using System.Collections;
using System.Data;

namespace ProgramacionFuncionalCSharp.LINQ
{
    public class LinqMethods
    {
        #region variables
        private static readonly List<int> calificaciones = new() { 1, 9, 3, 3, 9, 5, 6, 7, 8, 2, 4, 10 };
        private readonly static List<User> users = User.Users();
        private readonly static List<Task> tasks = Task.Tasks();
        #endregion

        #region Filtrado y busqueda de elementos
        //Filter --> Where
        public static void Where()
        {
            Console.WriteLine(">>>obtener calificaciones mayores a 8<<<");

            Console.WriteLine("Imperativo");
            foreach (var item in calificaciones)
                if (item > 8) Console.WriteLine(item);

            Console.WriteLine("Declarativo");
            calificaciones.Where(c => c > 8).ToList()
            .ForEach(item => Console.WriteLine(item));

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

        public static void OfType()
        {
            //OfType: Filtra los elementos de IEnumerable en función de un tipo especificado.

            //La capacidad inicial de 4 elementos solo afecta el rendimiento y la eficiencia de la lista
            // en términos de asignación de memoria. No impone una restricción estricta en la cantidad 
            // de elementos que puedes agregar a la lista.
            System.Collections.ArrayList fruits = new(4)
            {
                "Mango",
                "Orange",
                "Apple",
                3.0,
                "Banana"
            };

            // Apply OfType() to the ArrayList.
            IEnumerable<string> query1 = fruits.OfType<string>();

            Console.WriteLine("Elements of type 'string' are:");
            foreach (string fruit in query1)
            {
                Console.WriteLine(fruit);
            }
            // Elements of type 'string' are:
            // Mango
            // Orange
            // Apple
            // Banana

            // Where() can be applied to the ArrayList type after calling OfType().
            IEnumerable<string> query2 = fruits.OfType<string>()
            .Where(fruit => fruit.ToLower().Contains('n'));

            Console.WriteLine("\nThe following strings contain 'n':");
            foreach (string fruit in query2)
            {
                Console.WriteLine(fruit);
            }

            // The following strings contain 'n':
            // Mango
            // Orange
            // Banana
        }

        public static void Find()
        {
            Console.WriteLine(">>>Encontrar elementos<<<");

            //si no existe el elemento retorna el valor por defecto del tipo de dato esperado
            int result = calificaciones.Find(c => c == 3);
            Console.WriteLine($"retorna el: {result}");
        }

        public static void Single()
        {
            Console.WriteLine(">>>Encontrar elementos<<<");
            //si no existe el elemento o hay mas de una coincidencia retorna una excepción
            int result = calificaciones.Single(c => c == 4);
            Console.WriteLine($"retorna result: {result}");
        }

        public static void SingleOrDefault()
        {
            Console.WriteLine(">>>Encontrar elementos<<<");
            //si no existe el elemento o hay mas de una coincidencia retorna  el valor predeterminado
            int result = calificaciones.SingleOrDefault(c => c == 5);
            Console.WriteLine($"retorna result: {result}");
        }

        public static void First()
        {
            Console.WriteLine(">>>obtener el primer elemento<<<");
            //devuelve el primer elemento que coincida o exepción si no hay coincidencias
            int result = calificaciones.First(c => c == 1);
            Console.WriteLine($"retorna result: {result}");
        }

        public static void FirstOrDefault()
        {
            Console.WriteLine(">>>obtener el primer elemento<<<");
            //devuelve el primer elemento que coincida o  el valor predeterminado si no hay coincidencias
            int result = calificaciones.FirstOrDefault(c => c == 1);
            Console.WriteLine($"retorna result: {result}");
        }

        public static void Last()
        {
            Console.WriteLine(">>>obtener el último elemento<<<");
            //devuelve el último elemento que coincida o exepción si no hay coincidencias
            int result = calificaciones.Last(c => c == 10);
            Console.WriteLine($"retorna result: {result}");
        }

        public static void LastOrDefault()
        {
            Console.WriteLine(">>>obtener el último elemento<<<");
            //devuelve el último elemento que coincida o  el valor predeterminado si no hay coincidencias
            int result = calificaciones.LastOrDefault(c => c == 10);
            Console.WriteLine($"retorna result: {result}");
        }

        public static void ElementAt()
        {
            Console.WriteLine(">>>obtener el elemento en una posicion<<<");
            //devuelve el elemento en la posicion indicada
            int result1 = calificaciones.ElementAt(3);           
            Console.WriteLine($"retorna result1: {result1}");
        }

        public static void ElementAtOrDefault()
        {
            Console.WriteLine(">>>obtener el elemento en una posicion<<<");            
            //devuelve el elemento en la posicion indicada o  el valor predeterminado si no hay coincidencias
            int result = calificaciones.ElementAtOrDefault(3);
            Console.WriteLine($"retorna result1: {result}");
        }

        public static void DefaultIfEmpty()
        {
            Console.WriteLine(">>>obtener el valor por defecto si no hay coincidencias<<<");
            List<int> numbers = new List<int>();
            //muestra los elementos de la lista y si la lista esta vacia muestra el valor por defecto
            foreach (int number in numbers.DefaultIfEmpty())
            {
                Console.WriteLine(number);
            }
            /*
             This code produces the following output:
             0
            */
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

        public static void SelectMany()
        {
            //SelectMany en LINQ se utiliza para realizar una proyección y aplanar secuencias anidadas.
            //Es útil cuando tienes una colección de colecciones y deseas combinar esas colecciones.
            var AllRols = users.SelectMany(u => u.Rols);
            foreach (var rol in AllRols)
            {
                Console.WriteLine(rol);
            }
            //AllRols tiene todos los roles, incluso los repetidos.

            //Tambien sirve para hacer filtros de esas colecciones
            Console.WriteLine("Encontrar los usuarios con roles de Developer");
            var developers = users
            .SelectMany(user => user.Rols, (usuario, rol) => new { usuario, rol })
            .Where(user => user.rol.StartsWith("Developer"))
            .Select(user =>
                new
                {
                    Name = user.usuario.Username,
                    Rol = user.rol
                }
            );
            // Print the results.
            foreach (var obj in developers)
            {
                Console.WriteLine(obj);
            }

        }

        #endregion

        #region Ordenamiento
        public static void OrderBy()
        {
            Console.WriteLine(">>>ordenar calificaciones<<<");
            Console.WriteLine("Ascendenete con OrderBy");
            var result = calificaciones.OrderBy(c => c);
            foreach (var item in result)
                Console.WriteLine(item);

            Console.WriteLine("Descendente con OrderBy utilizabdo (-)");
            var result2 = calificaciones.OrderBy(c => -c);
            foreach (var item in result2)
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
            Console.WriteLine();

            Console.WriteLine("calificaciones with OrderByDescending");
            var result3 = calificaciones.OrderByDescending(c => c);
            foreach (var item in result3)
                Console.WriteLine(item);
        }

        public static void ThenBy()
        {
            //Realiza una clasificación posterior de los elementos de una secuencia 
            //en orden ascendentes con arreglo a una clave.
            //despues de OrderBy se usa ThenBy para realizar la clasificación posterior.
            Console.WriteLine(">>>ordenar usuarios por edad y despues por nombre caundo la edad es igual<<<");
            var usersByAge = users
            .OrderBy(u => u.Age)
            .ThenBy(u => u.Username);

            foreach (var user in usersByAge)
            {
                Console.WriteLine($"Id: {user.Id}, Username: {user.Username}, Age: {user.Age}");
            }

        }

        public static void ThenByDescending()
        {
            //Realiza una clasificación posterior de los elementos de una secuencia en orden descendente.
            Console.WriteLine(">>>ordenar usuarios por edad y despues por nombre descendentemente caundo la edad es igual<<<");
            var usersByAge = users
            .OrderBy(u => u.Age)
            .ThenByDescending(u => u.Username);
            foreach (var user in usersByAge)
            {
                Console.WriteLine($"Id: {user.Id}, Username: {user.Username}, Age: {user.Age}");
            }
        }

        public static void Reverse()
        {
            //Invierte el orden de los elementos de una secuencia.
            Console.WriteLine(">>>Invierte el orden de la secuencia<<<");
            char[] apple = { 'a', 'p', 'p', 'l', 'e' };
            char[] reversed = apple.Reverse().ToArray();

            foreach (char chr in reversed)
            {
                Console.Write(chr + " ");
            }
            Console.WriteLine();

            /*
             This code produces the following output:

             e l p p a
            */

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

        #endregion

        #region Conjuntos
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

        public static void GroupJoin()
        {
            // a diferencia de Join, GroupJoin agrupa los resultados en una secuencia anidada. 
            // Cada elemento de la secuencia original tiene una colección de elementos de la segunda secuencia 
            //que cumplen con la condición de igualdad.
            Console.WriteLine("Obtener el username de los usuarios y las tareas asignadas");

            var query = users.GroupJoin(tasks,
                                       user => user.Id,
                                       task => task.UserId,
                                       (user, taskCollection) =>
                                           new
                                           {
                                               // guarda el username
                                               UserName = user.Username,
                                               // guarda la lista de tareas asociadas al usuario
                                               Tasks = taskCollection.Select(task => task.Title)
                                           });

            foreach (var userTaskGroup in query)
            {
                Console.WriteLine($"{userTaskGroup.UserName}:");
                foreach (var task in userTaskGroup.Tasks)
                {
                    Console.WriteLine($"  {task}");
                }
            }
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
            //Retorna siempre un boolean, valida que alguno contenga
            Console.WriteLine(">>>Encontrar calificación<<<");
            bool existSeven = calificaciones.Contains(7);
            Console.WriteLine($"¿existe el 7?: {existSeven}");

            //IN SQL: sepuede usar para encontrar elementos especificos
            Console.WriteLine("obtener los usuarios 5, 6 y 7");
            users.Where(user => new int[] { 5, 6, 7 }.Contains(user.Id))
                .ToList().ForEach(user => Console.WriteLine(user.Username));

            //NOT IN SQL: se puede usar para excluir elementos especificos
            Console.WriteLine("Obtener los usuarios, menos 5, 6 y 7:");
            users.Where(user => !(new int[] { 5, 6, 7 }.Contains(user.Id)))
                .ToList().ForEach(user => Console.WriteLine(user.Username));
        }

        public static void Distinct()
        {
            Console.WriteLine(">>>obtener las calificaciones que son diferentes<<<");
            var result = calificaciones.Distinct().OrderBy(c => c);

            foreach (var item in result)
                Console.WriteLine(item);
        }

        public static void DistinctBy()
        {
            //Devuelve elementos distintos de una secuencia según una función de selector de claves especificada.
            //el selector debe ser una propiedad del objeto y devuelve los primeros registros de la secuencia
            //que son diferentes y los demas registros los omite 
            Console.WriteLine(">>>obtener los primeros usuarios que son diferentes en genero<<<");
            var result = users.DistinctBy(u => u.Gender);

            foreach (var item in result)
                Console.WriteLine($"ID: {item.Id}, {item.Username} {item.Gender}");
            /* Resultado
            ID: 1, user1 Male
            ID: 2, user2 Female
            */
        }

        public static void Any()
        {
            //Retorna siempre un boolean, valida que alguno cumpla
            Console.WriteLine(">>>Encontrar calificación<<<");

            bool existEleven = calificaciones.Any(c => c == 11);
            Console.WriteLine($"¿existe el 11?: {existEleven}");
        }

        public static void All()
        {
            //Retorna simepre un boolean, valida que todos cumplan
            Console.WriteLine(">>>Encontrar calificación<<<");

            bool todosSonMayorQueSeis = calificaciones.All(c => c > 6);
            Console.WriteLine($"¿todos son mayor que seis?: {todosSonMayorQueSeis}");
        }

        public static void Union()
        {
            //Proporciona la unión de conjuntos de dos secuencias, sin repetir elementos
            Console.WriteLine(">>>unir las secuencias<<<");
            int[] ints = { 8, 3, 6, 4, 4, 9, 1, 0 };
            var result = calificaciones.Union(ints);
            foreach (var item in result)
                Console.WriteLine(item);
        }

        public static void UnionBy()
        {
            //Genera la unión de conjunto de dos secuencias según una función de selector de claves especificada.
            //el selector debe ser una propiedad del objeto
            Console.WriteLine(">>>unir los dos diccionarios sin repetir la clave<<<");
            Dictionary<int, string> diccionario1 = new Dictionary<int, string>();
            diccionario1.Add(1, "Juan");
            diccionario1.Add(2, "Pedro");
            diccionario1.Add(3, "Juan");
            diccionario1.Add(4, "María");

            Dictionary<int, string> diccionario2 = new Dictionary<int, string>();
            diccionario2.Add(3, "Juan");
            diccionario2.Add(4, "Pedro");
            diccionario2.Add(5, "María");

            // Usa UnionBy para unir los dos diccionarios, eliminando los duplicados por la clave
            var diccionariosUnidos = diccionario1.UnionBy(diccionario2, p => p.Key);

            // Imprime el diccionario unido
            foreach (KeyValuePair<int, string> par in diccionariosUnidos)
                Console.WriteLine("{0}: {1}", par.Key, par.Value);

            // Salida:
            // 1: Juan
            // 2: Pedro
            // 3: Juan
            // 4: María
            // 5: María
        }

        public static void Concat()
        {
            //Concatena dos secuencias.
            Console.WriteLine(">>>concatenar las secuencias<<<");
            var result = users.Select(u => u.Username).Concat(new string[] { "a", "b", "c" });
            foreach (var item in result)
                Console.WriteLine(item);
        }

        public static void Except()
        {
            //proporciona los miembros del primer conjunto que no aparecen en el segundo conjunto.
            Console.WriteLine(">>>obtener las calificaciones que no estan en el segundo conjunto<<<");
            int[] ints = { 8, 3, 6, 4, 4, 9, 1, 0 };
            var result = calificaciones.Except(ints);
            foreach (var item in result)
                Console.WriteLine(item);
        }

        public static void Intersect()
        {
            //se usa para devolver los elementos comunes de dos estructuras de datos
            Console.WriteLine(">>>obtener los elementos comunes o duplicados<<<");

            int[] id1 = { 26, 92, 30, 71 };
            int[] id2 = { 47, 26, 4, 30 };

            IEnumerable<int> both = id1.Intersect(id2);

            foreach (int id in both)
                Console.WriteLine(id);

            /*
             This code produces the following output:
             26
             30
            */
        }

        public static void IntersectBy()
        {
            //se usa para devolver los elementos comunes de dos estructuras de datos
            Console.WriteLine(">>>obtener los usuarios comunes o duplicados<<<");
            var firstsUsers = users.Take(8);
            var lastsUsers = users.TakeLast(5);
            //IntersectBy tiene dos argumentos de tipo genéricos: TSource y TKey
            //IntersectBy es un método de extensión que se utiliza para encontrar la intersección de dos colecciones. 
            //En este caso, firstsUsers y lastsUsers son las dos colecciones que se están comparando. 
            //El tercer parámetro, u => u, es una expresión lambda que se utiliza para especificar la propiedad que se utilizará para comparar los elementos
            //de las dos colecciones. Por lo tanto, el método IntersectBy devuelve una colección de elementos que son comunes a ambas colecciones.
            var interesestUsers = firstsUsers.IntersectBy<User, User>(lastsUsers, u => u);
            Console.WriteLine("los usuarios duplicados son:");
            foreach (var user in interesestUsers)
                Console.WriteLine($"{user.Id} - {user.Username}");

            /*Resultado
            los usuarios duplicados son:
            7 - user7
            8 - user8
            */
        }

        public static void SequenceEqual()
        {
            //El método SequenceEqualByReference devuelve un booleano que verifica si dos secuencias son iguales.
            //En el caso de objetos y clases, el método determina si las secuencias comparadas contienen referencias a
            //los mismos objetos. Si son dos listas con el mismo objeto instanciado, retorna true. Sin embargo,
            //si es una lista con dos objetos instanciados, aunque sean instancias de la misma clase, se consideran
            //referencias distintas, y el método retorna false.
            Console.WriteLine(">>>verificar si dos secuencias son iguales<<<");

            int[] sequence1 = { 1, 2, 3, 4, 5 };
            int[] sequence2 = { 1, 2, 3, 4, 5 };
            bool areEqual = sequence1.SequenceEqual(sequence2);
            Console.WriteLine($"Las dos secuencias son iguales: {areEqual}");
            /*
             This code produces the following output:
             Las dos secuencias son iguales: True
            */
        }

        public static void Zip()
        {
            //Combina dos secuencias utilizando la función de predicado especificada.
            Console.WriteLine(">>> sumar dos secuencias <<<");

            int[] numbers1 = { 1, 2, 3 };
            int[] numbers2 = { 10, 20, 30 };
            var combined = numbers1.Zip(numbers2, (n1, n2) => n1 + n2);
            foreach (var result in combined)
                Console.WriteLine(result);
            /*
             This code produces the following output:
             11
             22
             33
            */
            Console.WriteLine();
            Console.WriteLine(">>> combinar dos secuencias <<<");
            int[] numbers = { 1, 2, 3, 4 };
            string[] words = { "one", "two", "three" };

            var numbersAndWords = numbers.Zip(words, (first, second) => first + ": " + second);

            foreach (var item in numbersAndWords)
                Console.WriteLine(item);
            // This code produces the following output:
            // 1: one
            // 2: two
            // 3: three
        }
        #endregion

        #region Paginación
        public static void Take()
        {
            Console.WriteLine("Retorna las primeras 3 calificaciones");
            var primerosTres = calificaciones.Take(3);
            Console.WriteLine("Los primeros tres elementos de la lista son:");
            foreach (var calificacion in primerosTres)
                Console.WriteLine(calificacion);
        }

        public static void Skip()
        {
            Console.WriteLine("Retorna sin las primeras 3 calificaciones");
            var sinPrimerosTres = calificaciones.Skip(3);
            Console.WriteLine("La lista sin los primeros tres elementos es:");
            foreach (var calificacion in sinPrimerosTres)
                Console.WriteLine(calificacion);
        }

        public static void TakeWhile()
        {
            //Devuelve los elementos de una secuencia siempre que el valor de una condición especificada
            // sea true y luego omite los elementos restantes.

            Console.WriteLine(">>>obtener grados mayores o iguales a 80<<<");
            int[] grades = { 59, 82, 70, 56, 92, 98, 85, 80 };

            IEnumerable<int> highterGrades =
                grades
                .OrderByDescending(grade => grade)
                .TakeWhile(grade => grade >= 80);

            Console.WriteLine("All grades above or equals to 80:");
            foreach (int grade in highterGrades)
            {
                Console.WriteLine(grade);
            }
            Console.WriteLine();

            //tambien se puede usar con indice
            Console.WriteLine(">>>obtener las cantidades mayores que el indice multiplicado por mil<<<");
            int[] amounts = { 5000, 2500, 9000, 8000,
                    6500, 4000, 1500, 5500 };

            IEnumerable<int> query =
                amounts.TakeWhile((amount, index) => amount > index * 1000);

            foreach (int amount in query)
                Console.WriteLine(amount);
            /*
             This code produces the following output:
             5000
             2500
             9000
             8000
             6500
            */
        }

        public static void SkipWhile()
        {
            //Omite los elementos de una secuencia en tanto que el valor de una condición especificada
            // sea true y luego devuelve los elementos restantes.
            Console.WriteLine(">>>omitir grados mayores o iguales a 80<<<");
            int[] grades = { 59, 82, 70, 56, 92, 98, 85, 80 };

            IEnumerable<int> lowerGrades =
                grades
                .OrderByDescending(grade => grade)
                .SkipWhile(grade => grade >= 80);

            Console.WriteLine("All grades below 80:");
            foreach (int grade in lowerGrades)
            {
                Console.WriteLine(grade);
            }
            /*
             This code produces the following output:
             All grades below 80:
             70
             59
             56
            */
            Console.WriteLine();
            //tambien se puede usar con indice
            Console.WriteLine(">>>omitir las cantidades mayores que el indice multiplicado por mil<<<");
            int[] amounts = { 5000, 2500, 9000, 8000,
                    6500, 4000, 1500, 5500 };

            IEnumerable<int> query =
                amounts.SkipWhile((amount, index) => amount > index * 1000);

            foreach (int amount in query)
                Console.WriteLine(amount);
            /*
             This code produces the following output:
             4000
             1500
             5500
            */
        }

        public static void TakeLast()
        {
            //devuelve los últimos elementos de una secuencia. Este método es útil cuando se desea obtener los últimos elementos de una secuencia.
            Console.WriteLine(">>>obtener los últimos 3 elementos de la lista<<<");
            var ultimosTres = calificaciones.OrderBy(key => key).TakeLast(3);
            Console.WriteLine("Los últimos tres elementos de la lista son:");
            foreach (var calificacion in ultimosTres)
                Console.WriteLine(calificacion);

        }

        public static void SkipLast()
        {
            //omite los último elementos de una secuencia. Este método es útil cuando se desea omitir los último elementos de una secuencia.
            Console.WriteLine(">>>omitir los último elementos de la lista<<<");
            var sinUltimosTres = calificaciones.OrderBy(key => key).SkipLast(3);
            Console.WriteLine("La lista sin los últimos tres elementos es:");
            foreach (var calificacion in sinUltimosTres)
                Console.WriteLine(calificacion);
        }

        public static void Range()
        {
            //Genera una secuencia de números enteros en un intervalo especificado
            // Generate a sequence of integers from 1 to 10
            // and then select their squares.
            IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x * x);

            foreach (int num in squares)
                Console.WriteLine(num);

            /*
             This code produces the following output:
             1
             4
             9
             16
             25
             36
             49
             64
             81
             100
            */
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

        public static void Average()
        {
            Console.WriteLine(">>>Obtener el promedio<<<");
            double average = calificaciones.Average();
            Console.WriteLine($"Promedio: {average}");
        }

        public static void Max()
        {
            Console.WriteLine(">>>Obtener el máximo<<<");
            int max = calificaciones.Max();
            Console.WriteLine($"Máximo: {max}");
        }

        public static void Min()
        {
            Console.WriteLine(">>>Obtener el mínimo<<<");
            int min = calificaciones.Min();
            Console.WriteLine($"Mínimo: {min}");
        }

        public static void Sum()
        {
            Console.WriteLine(">>>Obtener la suma<<<");
            int sum = calificaciones.Sum();
            Console.WriteLine($"Suma: {sum}");
        }

        public static void MaxBy()
        {
            //MaxBy devuleve el objeto completo mientras que Max solo devuelve el valor primitivo consultado
            Console.WriteLine("Obtener la tarea con el mayor userId");
            var taskWithMaxUserId = tasks.MaxBy(task => task.UserId);
            //el signo ! me indica que la propiedad es no nullable, es decir siempre viene con datos
            // y en este caso es porque es un archivo que tengo con datos hardcodeados, lo cual nunca es null
            Console.WriteLine($"tarea con mayor userId es la tarea {taskWithMaxUserId!.Id}: {taskWithMaxUserId!.Title}");
        }

        public static void MinBy()
        {
            //MinBy devuleve el objeto completo mientras que Min solo devuelve el valor primitivo consultado
            Console.WriteLine("Obtener la tarea con el mayor y el menor userId");
            var taskWithMinUserId = tasks.MinBy(task => task.UserId);
            //el signo ! me indica que la propiedad es no nullable, es decir siempre viene con datos
            // y en este caso es porque es un archivo que tengo con datos hardcodeados, lo cual nunca es null
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

        public static void ToArray()
        {
            //Crea una matriz a partir de un IEnumerable<T>.
            Console.WriteLine(">>>obtener un array con los nombres<<<");
            string[] usernames = users.Select(user => user.Username).ToArray();

            foreach (string user in usernames)
            {
                Console.WriteLine(user);
            }

        }

        public static void ToDictionary()
        {
            //Crea un Dictionary<TKey,TValue> a partir de un IEnumerable<T>.
            Console.WriteLine(">>>obtener los usuarios por id<<<");
            // Create a Dictionary of User class,
            // using Id as the key.
            Dictionary<int, User> dictionary =
                users.ToDictionary(u => u.Id);

            foreach (KeyValuePair<int, User> user in dictionary)
            {
                Console.WriteLine(
                    "Key {0}: {1}, {2} years",
                    user.Key,
                    user.Value.Username,
                    user.Value.Age);
            }
        }

        public static void ToHashSet()
        {
            //Crea un HashSet<T> a partir de un IEnumerable<T>.
            Console.WriteLine(">>>obtener los numeros unicos<<<");
            List<int> numbers = new List<int> { 1, 2, 3, 3, 4, 5, 5, 6 };

            // Usando ToHashSet para obtener un conjunto único de números
            HashSet<int> uniqueNumbers = numbers.ToHashSet();

            Console.WriteLine("Lista original:");
            Console.WriteLine(string.Join(", ", numbers));

            Console.WriteLine("\nConjunto único de números usando ToHashSet:");
            Console.WriteLine(string.Join(", ", uniqueNumbers));

            /*resultado:
            Lista original:
            1, 2, 3, 3, 4, 5, 5, 6
            Conjunto único de números usando ToHashSet:
            1, 2, 3, 4, 5, 6
            */
        }

        public static void Cast()
        {
            //Castea una secuencia de objetos de un tipo a otro, pero todos los elementos de la secuencia deben ser del mismo tipo sino produce una excepción.
            Console.WriteLine(">>>castear una secuencia de object a string<<<");
            object[] objs = new object[] { "12345", "12" };
            var strings1 = objs.Cast<string>().ToArray();
            foreach (string s in strings1)
                Console.WriteLine(s);

            try
            {
                var integers1 = objs.Cast<int>().ToArray(); //throws InvalidCastException
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine(">>>castear y obtener solo los usuarios del ArrayList<<<");
            //Cast sirve para implementar la interfaz IEnumerable<T> en los objetos que no la implementan
            //por ejemplo ArrayList no implementa IEnumerable<T>, por lo tanto no puede usar metodos LINQ
            var result = new ArrayList() { "user1", "user2", "rol1" };
            // Utilizar Cast<T> para convertir ArrayList a IEnumerable<string> y poder usar LINQ
            var enumerable = result.Cast<string>().Where(s => s.StartsWith("u"));
            // Mostrar los resultados
            foreach (var item in enumerable)
                Console.WriteLine(item);
        }

        public static void AsEnumerable()
        {
            //Crea un IEnumerable<T> a partir de un IEnumerable.
            //AsEnumerable es un método de extensión que se utiliza para convertir un objeto DataTable
            // en un objeto IEnumerable. Esto permite que el objeto DataTable se utilice en una consulta LINQ.
            Console.WriteLine(">>>seleccionar los nombres de las personas mayores de 30 años<<<");
            // Create a new DataTable.
            DataTable table = new();
            // Add columns to the DataTable.
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Age", typeof(int));
            // Add rows to the DataTable.
            table.Rows.Add(1, "John", 25);
            table.Rows.Add(2, "Jane", 30);
            table.Rows.Add(3, "Bob", 35);
            // Convert the DataTable to an IEnumerable.
            var names = table.AsEnumerable()
                             .Where(row => row.Field<int>("Age") > 30)
                             //con esta instruccion ?? nos aseguramos que no sea null
                             .Select(row => row.Field<string>("Name") ?? "");

            // Display the results.
            foreach (string name in names)
                Console.WriteLine(name);
        }
        #endregion

    }
}