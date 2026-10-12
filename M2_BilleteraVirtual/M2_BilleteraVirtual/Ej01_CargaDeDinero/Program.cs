namespace Ej01_CargaDeDinero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Definicion de variables
            const decimal montoCargaElevada = 1000.00m;
            string titular = "Ana Gómez Rivera";
            decimal saldo = 1500m;
            int cantidadMovimientos = 0;

            Console.WriteLine("=== CARGA DE DINERO ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine("Saldo: $ " + saldo.ToString("N2"));
            Console.WriteLine();

            Console.Write("Monto a cargar: ");
            //Lectura de terminal y filtrado de si es o no un decimal.
            bool esNumero = decimal.TryParse(Console.ReadLine(), out decimal monto);

            //Si no es numero
            if (!esNumero) 
            {
                Console.WriteLine("El monto ingresado no es un número válido. No se realizó la carga.");
            }
            // Si es numero pero menor que 0
            if (esNumero && monto <= 0) 
            {
                Console.WriteLine("El monto debe ser mayor que cero. No se realizó la carga.");
            }
            // Si es numero pero mayor que monto de carga elevada
            if (esNumero && monto >= montoCargaElevada)
            {
                Console.WriteLine("Aviso: carga de monto elevado. Será informada al área de control.");
            }
            // Si es numero valido para cargar
            if (esNumero && monto > 0 && monto < montoCargaElevada) 
            {
                saldo += monto;
                cantidadMovimientos++;
                Console.WriteLine("Carga acreditada: $" + monto.ToString("N2"));
                Console.WriteLine("Saldo actual: $" + saldo.ToString("N2"));
            }
            // Si el saldo completo excede los 2000
            if (esNumero && saldo > 2000m)
            {
                Console.WriteLine();
                Console.WriteLine("Aviso: el saldo supera $ 2.000,00");
            }

            Console.WriteLine();
            Console.WriteLine("Movimientos registrados: " + cantidadMovimientos);
            Console.WriteLine("Fin de la operación.");
        }
    }
}
