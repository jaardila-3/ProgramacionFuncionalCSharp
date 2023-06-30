
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace ProgramacionFuncionalCSharp.Lambdas
{
    public class Lambda
    {
        //FUNC: siempre devuelve un valor

        //lambda con un parámetro
        //Crear una función anónima que nos permita conocer si un número es par o no
        public static readonly Func<int, bool> isPar = num => num % 2 == 0;

        //lambda con un parámetro
        //Crear una función anónima que nos permita validar si es un correo válido
        public static readonly Func<string, bool> IsValidEmail = email => Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        //lambda con dos parámetro
        //Crear una función anónima que nos permita conocer la suma de dos numeros
        public static readonly Func<int, int, int> sum = (num1, num2) => num1 + num2;

        //lambda con multiple sentencias
        //Crear una función anónima que nos permita validar de que empresa es el correo
        public static readonly Func<string, string> CompanyEmail = email =>
        {
            if (email.EndsWith("@gmail.com", StringComparison.CurrentCultureIgnoreCase))
                return "> Correo de Google";
            if (new[] { "@microsoft.com", "@outlook.com", "@hotmail.com" }.Any(domain => email.EndsWith(domain, StringComparison.CurrentCultureIgnoreCase)))
                return "> Correo de Microsoft";
            return ">>>> Correo inválido, intente de nuevo >>>>";
        };

        //ACTION: no devuelve valor

        //lambda con un parámetro
        //Crear una función anónima que salude
        public static readonly Action<string> greet = msg => Console.WriteLine(msg);

        //lambda con dos parámetro
        //Crear una función anónima que salude varias veces
        public static readonly Action<string, int> greetMultipleTimes = (msg, num) =>
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine(msg);
            }
        };

    }
}