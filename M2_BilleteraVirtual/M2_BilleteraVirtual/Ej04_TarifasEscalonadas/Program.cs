namespace Ej04_TarifasEscalonadas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Definicion de constantes
            const decimal limiteTransferenciaOperacion = 2000m;
            //Definicion de variables
            decimal porcentajeComision = 0m;
            decimal tasaRendimiento = 0m;
            string tramo, tramoCaja;
            bool operacionPermitida = false;

            //Lectura del valor a transferir, luego se valida que parse funcione, si no, regresa 0
            Console.WriteLine("=== COMISIÓN POR TRANSFERENCIA ===");
            Console.Write("Monto a transferir: ");
            decimal transferir = decimal.TryParse(Console.ReadLine(), out decimal transferirLeido) ? transferirLeido : 0m;

            //Condiciones para procesar el porcentaje de comision y si es o no permitida la operacion
            if (transferir <= 0)
            {
                tramo = "Monto no válido";
            }
            else if (transferir <= 500)
            {
                tramo = "Tramo 1 (hasta $ 500,00)";
                operacionPermitida = true;
                porcentajeComision = 1.5m;
            }
            else if (transferir <= 1000)
            {
                tramo = "Tramo 2 (hasta $ 1000,00)";
                operacionPermitida = true;
                porcentajeComision = 1.2m;
            }
            else if (transferir <= limiteTransferenciaOperacion)
            {
                tramo = "Tramo 3 (hasta $ 2000,00)";
                operacionPermitida = true;
                porcentajeComision = 1m;
            }
            else
            {
                tramo = "Supera el límite por operación";
            }

            //Imprime en consola dependiendo si es o no aprobado
            if (operacionPermitida)
            {
                Console.WriteLine("Clasificación: " + tramo);
                Console.WriteLine("Porcentaje de comisión: " + porcentajeComision.ToString("N1") + " %");
                decimal comision = transferir * porcentajeComision / 100;
                Console.WriteLine("Comisión: $" + comision.ToString("N2"));
                decimal totalTransferir = transferir + comision;
                Console.WriteLine("Total a descontar: $" + totalTransferir.ToString("N2"));
            }
            else
            {
                Console.WriteLine(tramo);
                Console.WriteLine("La transferencia no puede calcularse");
            }

            Console.WriteLine();

            //Lectura del valor de la caja de ahorro, luego se valida que parse funcione, si no, regresa 0
            Console.WriteLine("=== RENDIMIENTO MENSUAL ===");
            Console.Write("Saldo de la caja de ahorro: ");
            decimal saldo = decimal.TryParse(Console.ReadLine(), out decimal cajaLeido) ? cajaLeido : 0m;

            //Condiciones para procesar el el calculo de la caja de ahorro
            if (saldo <= 0)
            {
                tramoCaja = "Sin saldo para rendimiento";
                tasaRendimiento = 0m;
            }
            else if (saldo < 1000)
            {
                tramoCaja = "Saldo inicial";
                tasaRendimiento = 0.2m;
            }
            else if (saldo < 5000)
            {
                tramoCaja = "Saldo intermedio";
                tasaRendimiento = 0.4m;
            }
            else
            {
                tramoCaja = "Saldo alto";
                tasaRendimiento = 0.6m;
            }

            //Imprime en consola dependiendo si es o no aprobado
            if (saldo > 0)
            {
                Console.WriteLine("Categoria: " + tramoCaja);
                Console.WriteLine("Tasa mensual: " + tasaRendimiento.ToString("N1") + " %");
                decimal rendimiento = saldo * tasaRendimiento / 100;
                Console.WriteLine("Rendimiento del mes: $" + rendimiento.ToString("N2"));
                decimal totalSaldo = saldo + rendimiento;
                Console.WriteLine("Total a descontar: $" + totalSaldo.ToString("N2"));
            }
            else
            {
                Console.WriteLine("Sin saldo para rendimiento");
            }

            //Parte opcional
            string tipoCliente = "";
            decimal diferenciaSiguiente = 0m;

            Console.WriteLine();
            if (saldo <= 0) { }
            else if (saldo > 0 && saldo < 1000)
            {
                tipoCliente = "Clásico";
                diferenciaSiguiente = 1000 - saldo;
            }
            else if (saldo < 5000)
            {
                tipoCliente = "Plus";
                diferenciaSiguiente = 5000 - saldo;
            }
            else if (saldo > 5000)
            {
                tipoCliente = "Premium";
            }

            Console.WriteLine("Tipo de cliente: " + tipoCliente);
            Console.WriteLine("Pesos para el proximo nivel: $" + diferenciaSiguiente.ToString("N2"));
        }
    }
}