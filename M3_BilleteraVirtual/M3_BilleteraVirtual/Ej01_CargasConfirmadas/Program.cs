namespace Ej01_CargasConfirmadas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Constantes
            const decimal limiteCargaOperacion = 5000m;
            const decimal montoCargaElevada = 1000m;

            //Variables ejercicio
            string titular = "Ana Gómez Rivera";
            decimal saldo = 1500m;
            int cantidadCargas = 0;
            decimal totalCargado = 0;

            //Variables propias
            bool valido = false;
            decimal monto = 0;
            char continuar = 'n';

            //Print fijo
            Console.WriteLine("=== CARGAS DE DINERO ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine("Saldo: $" + saldo.ToString("N2"));
            Console.WriteLine();


            do
            {
                //Primero evalua la validez del monto
                do
                {
                    Console.Write("Monto a cargar: $");
                    monto = decimal.TryParse(Console.ReadLine(), out decimal lectura) ? lectura : 0m;

                    if (monto <= 0 || monto > limiteCargaOperacion)
                    {
                        Console.WriteLine("Monto invalido. Ingrese un numero mayor que cero y hasta $ 5.000,00");
                        Console.WriteLine();
                        valido = false;
                    }
                    else {
                        valido = true;
                    }

                } while (!valido);

                //Una vez el monto es valido, se suma 
                saldo += monto;
                totalCargado += monto;
                cantidadCargas++;

                Console.WriteLine("Carga acreditada: $" + monto.ToString("N2"));
                Console.WriteLine("Saldo actual: $" + saldo.ToString("N2"));

                //Si excede el monto de carga elevada genera una alerta
                if (monto >= montoCargaElevada)
                {
                    Console.WriteLine("Aviso: carga de monto elevado. Será informada al área de control.");
                }

                Console.WriteLine();
                Console.Write("¿Desea realizar otra carga? (S/N): ");
                continuar = char.TryParse(Console.ReadLine(), out char lecturaChar) ? lecturaChar : 'n';

            } while (continuar == 's' || continuar == 'S');

            //Resumen de la sesion
            Console.WriteLine();
            Console.WriteLine("--- Resumen de la sesión ---");
            Console.WriteLine("Cargas realizadas: " + cantidadCargas);
            Console.WriteLine("Total cargado: $" + totalCargado.ToString("N2"));
            Console.WriteLine("Saldo final: $" + saldo.ToString("N2"));
        }
    }
}