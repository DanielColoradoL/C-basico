namespace Ej05_ValidacionTransferencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Constantes propuestas por el ejercicio
            const decimal limiteDiario = 2000m;
            const decimal porcentajeComision = 1.5m;

            //Elegi una funcion para no repetir codigo aunque aun no se explica
            static void validacion(decimal saldo, decimal monto, bool cuentaBloqueada)
            {
                //Valor de la transaccion
                decimal comision = monto * porcentajeComision / 100;
                //Se agrega el valor de la transaccion al monto.
                monto += comision;
                //Se chequea que hayan fondos suficientes
                bool fondosSuficientes = monto <= saldo ? true : false;
                //Se chequea que el monto sea menor que el limite diario
                bool dentroDelLimite = monto <= limiteDiario ? true : false;
                //Se aprueba si hay saldo, si esta dentro del limite y la cuenta no esta bloqueada
                bool aprobado = fondosSuficientes && dentroDelLimite && !cuentaBloqueada;
                //Texto auxiliar para imprimir en pantalla aprobado o rechazado
                string aprobadoTexto = aprobado ? "APROBADA" : "RECHAZADA";
                Console.WriteLine($"(saldo {saldo}, monto {monto}): {aprobadoTexto}");
                //Validacion de si es mas de 1000 requiere MFA
                string sms = monto >= 1000m ? "Si" : "No";
                Console.WriteLine("¿Requiere validación adicional por SMS? " + sms);

            }

            //Escenarios propuestos
            Console.Write("Escenario 1 ");
            validacion(1500m, 500m, false);
            Console.Write("Escenario 2 ");
            validacion(300m, 500m, false);
            Console.Write("Escenario 3 ");
            validacion(5000m, 2500m, false);
            Console.Write("Escenario 4 ");
            validacion(1500m, 500m, true);
            Console.Write("Escenario 5 ");
            validacion(507.50m, 500m, false);
            Console.Write("Escenario 6 ");
            validacion(2000m, 1200m, false);
        }
    }
}
