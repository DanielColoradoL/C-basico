namespace Ej07_BilleteraIntegrador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RF1
            const decimal porcentajeComisionTransferencia = 1.5m; 
            const decimal comisionFijaExtraccion = 50.00m;
            const decimal limiteExtraccionDiario = 1000.00m;
            const decimal limiteTransferenciaDiario = 2000.00m;
            //RF2
            string titular = "Ana Gómez Rivera";
            decimal saldo = 1500.00m;
            decimal saldoInicial = 1500.00m;
            int cantidadMovimientos = 0;
            DateTime? ultimoMovimiento = null;
            DateTime fechaSesion = new DateTime(2026, 10, 3);

            //RF3, encabezado y titular
            Console.WriteLine("=== BILLETERA VIRTUAL - Sesión de demostración ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine();

            //RF4, mostrar el saldo en consola con formato
            {
                Console.WriteLine("--- 1. Consultar saldo ---");
                Console.WriteLine("Saldo disponible: $ " + saldo.ToString("N2"));
                Console.WriteLine();
            }

            //RF5, Cargar dinero
            {
                saldo += 300m;
                cantidadMovimientos++;
                ultimoMovimiento = DateTime.Now;
                Console.WriteLine("--- 2. Cargar dinero ---");
                Console.WriteLine("Carga: $ 300,00");
                Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));
                Console.WriteLine();
            }

            //RF6, Extraer efectivo
            {
                decimal extraer = 200m;
                decimal totalExtraer = extraer + comisionFijaExtraccion;
                bool aprobado = totalExtraer < limiteExtraccionDiario && totalExtraer < saldo;
                string stringAprobado = aprobado ? "APROBADO" : "RECHAZADO";
                //Agrega +1 si la transaccion fue aprobada
                cantidadMovimientos = aprobado ? cantidadMovimientos += 1 : cantidadMovimientos;
                //Actualiza la fecha del ultimo movimiento si la transaccion fue aprobada
                ultimoMovimiento = aprobado ? DateTime.Now : ultimoMovimiento;  
                //El saldo solo se actualiza si fue aprobado
                saldo = aprobado ? saldo -= totalExtraer : saldo;

                Console.WriteLine("--- 3. Extraer efectivo ---");
                Console.WriteLine("Monto solicitado: $" + extraer.ToString("N2") + " (comisión fija: $ 50,00)");
                Console.WriteLine("Total a descontar: $" + totalExtraer.ToString("N2"));
                Console.WriteLine("Estado: " + stringAprobado);
                Console.WriteLine("Saldo actualizado: $" + saldo.ToString("N2"));
                Console.WriteLine();
            }

            //RF7, Transferir a CVU
            {
                decimal transferir = 500m;
                decimal comisionTransferencia = transferir * porcentajeComisionTransferencia / 100;
                decimal totalTransferir = transferir + comisionTransferencia;
                bool aprobado = transferir < limiteTransferenciaDiario && transferir < saldo;
                string stringAprobado = aprobado ? "APROBADO" : "RECHAZADO";
                //Agrega +1 si la transaccion fue aprobada
                cantidadMovimientos = aprobado ? cantidadMovimientos += 1 : cantidadMovimientos;
                //Actualiza la fecha del ultimo movimiento si la transaccion fue aprobada
                ultimoMovimiento = aprobado ? DateTime.Now : ultimoMovimiento;
                //El saldo solo se actualiza si fue aprobado
                saldo = aprobado ? saldo -= totalTransferir : saldo;
                
                Console.WriteLine("--- 4. Transferir a CVU ---");
                Console.WriteLine("Monto : $" + transferir.ToString("N2") + " | Comisión fija: $ " + comisionTransferencia.ToString("N2"));
                Console.WriteLine("Total a descontar: $" + totalTransferir.ToString("N2"));
                Console.WriteLine("Estado: " + stringAprobado);
                Console.WriteLine("Saldo actualizado: $" + saldo.ToString("N2"));
                Console.WriteLine();
            }

            //RF8, Extraer efectivo
            {
                decimal extraer = 2000m;
                decimal totalExtraer = extraer + comisionFijaExtraccion;
                bool aprobado = totalExtraer < limiteExtraccionDiario && totalExtraer < saldo;
                string stringAprobado = aprobado ? "APROBADO" : "RECHAZADO";
                //Agrega +1 si la transaccion fue aprobada
                cantidadMovimientos = aprobado ? cantidadMovimientos += 1 : cantidadMovimientos;
                //Actualiza la fecha del ultimo movimiento si la transaccion fue aprobada
                ultimoMovimiento = aprobado ? DateTime.Now : ultimoMovimiento;
                //El saldo solo se actualiza si fue aprobado
                saldo = aprobado ? saldo -= totalExtraer : saldo;

                Console.WriteLine("--- 3. Extraer efectivo (segundo intento) ---");
                Console.WriteLine("Monto solicitado: $" + extraer.ToString("N2") + " (comisión fija: $ 50,00)");
                Console.WriteLine("Estado: " + stringAprobado);
                Console.WriteLine("Saldo actualizado: $" + saldo.ToString("N2"));
                Console.WriteLine();
            }

            //RF9, resumen movimientos
            {
                string ultimoMovimientoTexto = ultimoMovimiento.HasValue ? ultimoMovimiento.Value.ToString("dd/MM/yyyy") : "Sin movimientos";

                Console.WriteLine("--- 5. Ver resumen de movimientos ---");
                Console.WriteLine("Titular: " + titular);
                Console.WriteLine("Saldo: $" + saldo.ToString("N2"));
                Console.WriteLine("Movimientos realizados: " + cantidadMovimientos.ToString());
                Console.WriteLine("Último movimiento: " + ultimoMovimientoTexto);
                Console.WriteLine();
            }

            Console.WriteLine("Fin de la sesión. Saldo final: $ " + saldo.ToString("N2"));

            //Desafio opcional
            decimal variacion = saldo - saldoInicial;
            Console.WriteLine("Variación neta de la sesión: $" + variacion.ToString("N2"));
        }
    }
}
