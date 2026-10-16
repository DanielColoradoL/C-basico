namespace Ej07_DepuracionFlujo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string titular = "Luis Morales";
            decimal saldo = 1200.00m;
            decimal montoExtraccion = 1000.00m;
            decimal montoTransferencia = 300.00m;
            const decimal comisionFija = 50.00m;
            const decimal limiteExtraccion = 1000.00m;
            int opcion = 3;
            int intentosClave = 0;
            int intentosRestantes = 0;

            Console.WriteLine("Titular: " + titular);

            // Bloque 1: aprobación de la extracción.
            if (montoExtraccion <= limiteExtraccion && saldo >= montoExtraccion + comisionFija)
            {
                saldo = saldo - montoExtraccion - comisionFija;
                Console.WriteLine("Extracción aprobada. Saldo: $ " + saldo.ToString("N2"));
            }
            else
            {
                Console.WriteLine("Extracción rechazada.");
            }

            // Bloque 2: nombre de la operación elegida.
            string nombreOperacion = "";
            switch (opcion)
            {
                case 1:
                    nombreOperacion = "Consultar saldo";
                    break;
                case 2:
                    nombreOperacion = "Cargar dinero";
                    break;
                case 3:
                    nombreOperacion = "Extraer efectivo";
                    break;
            }
            Console.WriteLine("Operación: " + nombreOperacion);

            // Bloque 3: validación de la opción elegida.
            if (opcion == 3)
            {
                Console.WriteLine("La opción 3 requiere validar el límite diario.");
            }
            else
            {
                Console.WriteLine("La opción elegida no requiere validación.");
            }

            // Bloque 4: comisión de la transferencia según el monto.
            decimal porcentajeComision;
            if (montoTransferencia <= 500m)
            {
                porcentajeComision = 1.5m;
            }
            else if (montoTransferencia <= 1000m)
            {
                porcentajeComision = 1.2m;
            }
            else
            {
                porcentajeComision = 1.0m;
            }
            decimal comision = montoTransferencia * porcentajeComision / 100m;
            Console.WriteLine("Comisión de transferencia: " + porcentajeComision.ToString("N1") + " % ($ " + comision.ToString("N2") + ")");

            // Bloque 5: reintentos de clave.
            while (intentosClave < 3)
            {
                Console.WriteLine("Reintento " + (intentosClave + 1) + " de 3");
                intentosClave++;
            }
            Console.WriteLine("Se agotaron los reintentos.");

            Console.WriteLine();
            // Bloque opcional
            while (intentosRestantes < 3)
            {
                Console.WriteLine("Intentos restantes: " + (3 - intentosRestantes));
                intentosRestantes++;
            }
            Console.WriteLine("Se agotaron los reintentos.");
        }
    }
}
