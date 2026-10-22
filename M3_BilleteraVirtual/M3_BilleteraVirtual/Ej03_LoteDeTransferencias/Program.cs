namespace Ej03_LoteDeTransferencias
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Constantes
            const int maximoTransferenciasLote = 10;
            const decimal limiteTransferenciaOperacion = 2000m;
            const decimal limiteTransferenciaDiario = 3000m;

            //Variables definidas
            decimal saldo = 2500m;
            decimal totalTransferido = 0;
            decimal totalComisiones = 0;
            int aprobadas = 0;
            int rechazadas = 0;
            string motivoCierre = "Se alcanzó el máximo de transferencias del lote.";

            //Variables personales
            decimal? monto = 0;
            decimal porcComision = 0;
            decimal comision = 0;
            decimal montoTotal = 0;

            //Print inicial
            Console.WriteLine("=== LOTE DE TRANSFERENCIAS ===");
            Console.WriteLine("Saldo inicial: $" + saldo.ToString("N2"));
            Console.WriteLine("Ingrese cada monto. Ingrese 0 para finalizar el lote.");
            Console.WriteLine();

            for (int i = 0; i < maximoTransferenciasLote; i++)
            {
                Console.Write($"Transferencia {i + 1} - Monto: $");
                monto = decimal.TryParse(Console.ReadLine(), out decimal lectura) ? lectura : null;

                if (monto == 0)
                {
                    motivoCierre = "El usuario finalizó el lote.";
                    break;
                }
                else if (!monto.HasValue || monto < 0)
                {
                    Console.WriteLine("Estado: RECHAZADA. Monto inválido.");
                    Console.WriteLine();
                    rechazadas++;
                }
                else if (monto > limiteTransferenciaOperacion)
                {
                    Console.WriteLine("Estado: RECHAZADA. Supera el límite por operación de $2.000,00.");
                    Console.WriteLine();
                    rechazadas++;
                }
                else if (monto + totalTransferido > limiteTransferenciaDiario)
                {
                    motivoCierre = "Se alcanzó el límite diario de transferencias.";
                    break;
                }
                else
                {
                    porcComision = monto switch
                    {
                        <= 500 => 1.5m,
                        <= 1000 => 1.2m,
                        _ => 1m
                    };

                    comision = monto * porcComision / 100 ?? 0m;
                    montoTotal = monto + comision ?? 0m;

                    //Si el saldo no alcanza a cubrir el monto cancelar
                    if (saldo - montoTotal < 0)
                    {
                        motivoCierre = $"Saldo insuficiente para la transferencia {i + 1}.";
                        rechazadas++;
                        break;
                    }

                    saldo -= montoTotal;
                    totalTransferido += montoTotal;
                    totalComisiones += comision;
                    aprobadas++;

                    //Informacion de cada transferencia
                    Console.Write("Estado: APROBADA. ");
                    Console.Write($"Comisión ({porcComision.ToString("N1")} %): ${comision.ToString("N2")} ");
                    Console.WriteLine($"| Saldo: ${saldo.ToString("N2")}");
                    Console.WriteLine();
                }
            }
            //Resumen del lote
            Console.WriteLine();
            Console.WriteLine("--- Resumen del lote ---");
            Console.WriteLine("Motivo de cierre: " + motivoCierre);
            Console.WriteLine("Transferencias aprobados: " + aprobadas);
            Console.WriteLine("Transferencias rechazadas: " + rechazadas);
            Console.WriteLine("Total transferido: $" + totalTransferido.ToString("N2"));
            Console.WriteLine("Comisiones pagadas: $" + totalComisiones.ToString("N2"));
            Console.WriteLine("Saldo final: $" + saldo.ToString("N2"));
        }
    }
}