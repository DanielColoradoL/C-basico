namespace Ej06_DepuracionBilletera
{
    internal class Program
    {
        static void Main()
        {
            string titular = "Luis Morales";
            Console.WriteLine("Titular: " + titular);

            decimal saldo = 900.00m;
            decimal montoExtraccion = 250.00m;

            int cuotas = 12;

            decimal tasaComision = 1.5m;
            tasaComision = 2.0m;

            decimal comision = 5.00m;
            Console.WriteLine("Comisión: " + comision);

            decimal saldoFinal = saldo - montoExtraccion - comision;
            Console.WriteLine("Saldo final: " + saldoFinal);

            decimal tercio = 1 / 3m;
            Console.WriteLine("Tercio de la cuota: " + tercio);
            Console.WriteLine("Cuotas: " + cuotas);
        }
    }
}
