namespace Ej02_FichaDeCuenta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaracion de constantes
            const string nombreBanco = "Banco NetSur";
            const decimal porcentajeComisionTransferencia = 1.5m;
            const decimal limiteDiarioTransferencias = 2000.00m;

            //Declaracion de variables
            string titular = "Ana Gómez Rivera";
            string cvu = "0000003100012345678901";
            string aliasBilletera = "ana.gomez.billetera";
            decimal saldo = 1500.00m;
            decimal carga = 0;
            int cantidadMovimientos = 0;

            //Formato del encabezado
            Console.WriteLine("=== FICHA DE LA BILLETERA ===");
            Console.WriteLine($"Entidad: {nombreBanco}");
            Console.WriteLine($"Titular: {titular}");
            Console.WriteLine($"CVU: {cvu}");
            Console.WriteLine($"Alias: {aliasBilletera}");
            Console.WriteLine("Saldo inicial: $" + saldo.ToString("N2"));
            Console.WriteLine($"Comisión por transferencia (%): {porcentajeComisionTransferencia}");
            Console.WriteLine("Límite diario de transferencias: $" + limiteDiarioTransferencias.ToString("N2"));
            Console.WriteLine();

            //Formato despues de la carga
            Console.WriteLine("=== DESPUÉS DE LA CARGA DE DINERO ===");

            //Agregar la carga de dinero de manera manual
            carga = 300;
            Console.WriteLine("Carga realizada: $" + carga.ToString("N2"));
            
            //Adicionar la carga al saldo total
            Console.WriteLine("Saldo actual: $" + (saldo + carga).ToString("N2"));

            //Agregar una transaccion
            cantidadMovimientos++;
            Console.WriteLine($"Movimientos registrados: {cantidadMovimientos}");

            //RF6 - El error ocurre por quere asignar un valor a una constante
            //limiteDiarioTransferencias = 200.00m;
        }
    }
}
