namespace Ej04_CalculoTransferencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal porcentajeComision = 1.5m;
            decimal tasaRendimientoMensual = 0.4m;
            decimal saldo = 1800.00m;
            decimal montoTransferencia = 500.00m;
            int cantidadTransferencias = 0;

            //Primer interaccion con multiplicacion y division
            decimal comision = montoTransferencia * porcentajeComision / 100;
            decimal valDescontado = montoTransferencia + comision;
            decimal rendimiento;

            //Suma 1 a cantidad de transferencias
            cantidadTransferencias++;
            //Resta valDesconatado del saldo total
            saldo -= valDescontado;

            //Print en consola antes de los cambios
            Console.WriteLine("=== TRANSFERENCIA A CVU ===");
            Console.WriteLine("Monto a transferir: $ " + montoTransferencia.ToString("N2"));
            Console.WriteLine("Comisión: $ " + comision.ToString("N2"));
            Console.WriteLine($"Transferencias realizadas: {cantidadTransferencias}");
            Console.WriteLine("Saldo después de la transferencia: $ " + saldo.ToString("N2"));
            Console.WriteLine();

            //Luego se calcula el rendimiento y se le adiciona al saldo
            rendimiento = saldo * tasaRendimientoMensual / 100;
            saldo += rendimiento;

            // Segunda parte del print en consola con los cambios
            Console.WriteLine("=== RENDIMIENTO MENSUAL ===");
            Console.WriteLine("Rendimiento generado: $ " + rendimiento.ToString("N2"));
            Console.WriteLine("Saldo con rendimiento: $ " + saldo.ToString("N2"));
            Console.WriteLine();

            //RF8
            //Ejercicios de division con int y decimal
            Console.WriteLine("=== DIVISIÓN ===");
            Console.WriteLine("1000 / 3 con int: " + (1000 / 3).ToString());
            Console.WriteLine("1000 $ 3 con int (resto): " + (1000 % 3).ToString());
            Console.WriteLine("1000m / 3m con decimal: " + (1000m / 3m).ToString());
        }
    }
}
