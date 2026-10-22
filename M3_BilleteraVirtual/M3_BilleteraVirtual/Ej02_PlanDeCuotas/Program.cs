namespace Ej02_PlanDeCuotas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Constantes
            const decimal montoMinimo = 1000m;
            const decimal montoMaximo = 50000m;
            const int cuotasMinimas = 3; 
            const int cuotasMaximas = 24;
            //porcentaje de interés simple por mes
            const decimal tasaMensual = 4m;

            //Variables fijas
            DateTime fechaSesion = new DateTime(2026, 10, 03);
            string titular = "Ana Gómez Rivera";

            //Variables propias
            decimal monto = 0m;
            decimal montoAux = 0m;
            decimal montoTotal = 0;
            decimal intereses = 0;
            int meses = 0;
            bool valido = false;
            decimal valorCuota = 0;

            //Print inicial
            Console.WriteLine("=== PRÉSTAMO PERSONAL - Banco NetSur ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine();

            //Chequea el valor del prestamo
            do
            {
                Console.Write("Monto del préstamo: $");
                monto = decimal.TryParse(Console.ReadLine(), out decimal lectura) ? lectura : 0m;

                if (monto < montoMinimo || monto > montoMaximo)
                {
                    Console.WriteLine("Monto inválido. Debe estar entre $ 1.000,00 y $ 50.000,00.");
                    Console.WriteLine();
                    valido = false;
                }
                else
                {
                    valido = true;
                }
            } while (!valido);

            valido = false;
            montoAux = monto;

            //Chequea los meses a diferir el prestamo
            do
            {
                Console.Write("Cantidad de cuotas: ");
                meses = int.TryParse(Console.ReadLine(), out int lectura) ? lectura : 0;

                if (meses < cuotasMinimas || meses > cuotasMaximas)
                {
                    Console.WriteLine("Cantidad inválida. Ingrese un entero entre 3 y 24.");
                    Console.WriteLine();
                    valido = false;
                }
                else
                {
                    valido = true;
                }
            } while (!valido);
            Console.WriteLine();

            //Calculo de los intereses
            intereses = monto * meses * tasaMensual / 100;
            montoTotal = monto + intereses;
            valorCuota = montoTotal / meses;

            //Condiciones del prestamo
            Console.WriteLine("--- Condiciones del préstamo ---");
            Console.WriteLine("Capital: $" + monto.ToString("N2"));
            Console.WriteLine("Tasa mensual: " + tasaMensual.ToString("N1"));
            Console.WriteLine("Interés total: $" + intereses.ToString("N2"));
            Console.WriteLine("Total a pagar: $" + montoTotal.ToString("N2"));
            Console.WriteLine("Valor de cada cuota: $" + valorCuota.ToString("N2"));
            Console.WriteLine();

            //Cronograma de cuotas
            //Use el formato de string(valor, longitud para definir el width del string)
            Console.WriteLine("--- Cronograma de cuotas ---");
            Console.WriteLine($"{"Cuota", -10} | {"Vencimiento", -16} | {"Valor", -10} | {"Saldo pendiente", -16}");
            Console.WriteLine(new string('-', 61));

            for (int i = 0; i < meses; i++) 
            {
                montoTotal -= valorCuota;
                fechaSesion = fechaSesion.AddMonths(1);
                Console.Write($"{(i + 1), -10} | ");
                Console.Write($"{fechaSesion.ToString("dd/MM/yyyy"), -16} | ");
                Console.Write($"{valorCuota.ToString("N2"), -10} | ");
                Console.WriteLine($"{montoTotal.ToString("N2"), -10}");
            }
            Console.WriteLine();

            //Cuotas restantes por pagar
            Console.WriteLine("--- Cuotas pendientes después de cada pago ---");
            for (int i = 1; i <= meses; i++) 
            {
                Console.WriteLine($"Quedan {meses - i} cuota(s) por pagar.");
            }
            Console.WriteLine();

            Console.WriteLine("---Simulador: cuota del mismo capital en otros plazos---");            
            for (int i = 6; i <= 24; i += 6)
            {
                intereses = montoAux * i * tasaMensual / 100;
                montoTotal = montoAux + intereses;
                valorCuota = montoTotal / i;

                Console.WriteLine($"{i} cuotas de $ {valorCuota.ToString("N2")}");
            }
        }
    }
}