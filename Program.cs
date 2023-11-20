// See https://aka.ms/new-console-template for more information
using ProgramacionFuncionalCSharp.Lambdas;
using ProgramacionFuncionalCSharp.DelegateOrCallBacks;
using ProgramacionFuncionalCSharp.CursoCSharp;
using ProgramacionFuncionalCSharp.LINQ;
using ProgramacionFuncionalCSharp.Strings;

// const int numberOne = 10, numberTwo = 20;

// Console.WriteLine("\nstart lambdas!");
// Console.WriteLine($"¿el número es par?: {Lambda.isPar(numberOne)}");
// Console.WriteLine($"¿el correo es válido?: {Lambda.IsValidEmail("alexanderardilagmail.com")}");
// Console.WriteLine($"el resultado de la suma es: {Lambda.sum(numberOne, numberTwo)}");
// Console.WriteLine($"validador: {Lambda.CompanyEmail("alexanderardila@HOTMAIL.com")}");
// Console.WriteLine("saludar: ");
// Lambda.greet("Hola como estas");
// Lambda.greetMultipleTimes("Hola varias veces", 4);
// Console.WriteLine("end lambdas! \n");

// Console.WriteLine("\nstart delegados!");
// Delegado.CallbackDelegate retiro = Delegado.Retiro;
// Delegado.CallbackDelegate deposito = Delegado.Deposito;
// Delegado.EjecutarOperacion(retiro, 20, 200);
// Delegado.EjecutarOperacion(deposito, 40, 260);
// //creamos un lambda para un deposito con intereses del 2% si cantidad es mayor a 200
// Delegado.CallbackDelegate depositoInteres = (cantidad, monto) => cantidad > 200 ? cantidad + monto + (cantidad * 0.02f) : cantidad + monto;
// Delegado.EjecutarOperacion(depositoInteres, 202, 500);
// Console.WriteLine("end delegados! \n");

// Console.WriteLine("\nstart LINQ!");
// LinqMethods.Where();
// LinqMethods.OfType();
// LinqMethods.Select();
// LinqMethods.Aggregate();
// LinqMethods.Distinct();
// LinqMethods.Count();
// LinqMethods.Average_Max_Min_Sum();
// LinqMethods.OrderBy();
// LinqMethods.ToList();
// LinqMethods.Contains_Any_All_ReturnBool();
// LinqMethods.Find();
// LinqMethods.Single();
// LinqMethods.First();
// LinqMethods.Last();
// LinqMethods.ElementAt();
// LinqMethods.DefaultIfEmpty();
LinqMethods.SelectMany();
// LinqMethods.Take_Skip();
// LinqMethods.OrderByDescending();
// LinqMethods.Contains();
// LinqMethods.WhereWithLet();
// LinqMethods.MaxBy_MinBy();
// LinqMethods.ToLookUp();
// LinqMethods.GroupBy();
// LinqMethods.Join();
// LinqMethods.LeftJoin();
// Console.WriteLine("end LINQ! \n");

// Console.WriteLine("\nstart Tuplas!");
// Tuplas.MethodTuplas();
// Console.WriteLine("end Tuplas! \n");

Console.WriteLine("\nstart string methods!");
StringMethods.StartsWith();
Console.WriteLine("end Queries! \n");