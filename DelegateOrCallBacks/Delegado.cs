

namespace ProgramacionFuncionalCSharp.DelegateOrCallBacks
{
    //simularemos un cajero electrónico
    public class Delegado
    {
        //delegado o callback
        public delegate float CallbackDelegate(float valor1, float valor2);

        //funciones
        public static float Deposito(float cantidad, float monto) => cantidad + monto;
        public static float Retiro(float cantidad, float monto)
        {
            if (cantidad > monto)
            {
                Console.WriteLine("No es posible realizar el retiro");
                return 0.0f;
            }
            return monto - cantidad;
        }
        public static float EjecutarOperacion(CallbackDelegate operacion, float cantidad, float monto)
        {
            System.Console.WriteLine("iniciando una operación");
            float result = operacion(cantidad, monto);
            System.Console.WriteLine(result);
            System.Console.WriteLine("finalizada la operación");
            return result;
        }

    }
}