namespace Ej04_AuditoriaDeMovimientos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Constantes
            const int cantidadRevisiones = 8;
            const decimal montoMinimoAuditable = 100m;
            const decimal montoSospechoso = 5000m;

            //Variables definidas
            decimal totalCargas = 0;
            decimal totalExtracciones = 0;
            decimal totalTransferencias = 0;
            int cantidadAuditados = 0;
            int cantidadDescartadosInvalidos = 0;
            int cantidadOmitidosPorMonto = 0;
            int cantidadSospechosos = 0;

            //Variables propias
            string? tipoCuenta = "";
            decimal? monto = 0;
            decimal flujoNeto = 0;
            bool sospechoso = false;

            //Print fijo
            Console.WriteLine("=== AUDITORÍA DE MOVIMIENTOS ===");
            Console.WriteLine("Se revisarán 8 movimientos.");
            Console.WriteLine("Tipos válidos: C (carga), E (extracción), T (transferencia).");
            Console.WriteLine();


            for (int i = 0; i < cantidadRevisiones; i++)
            {
                Console.WriteLine($"Movimiento {i + 1} de 8");
                Console.Write("Tipo (C/E/T): ");
                tipoCuenta = Console.ReadLine()?.Trim().ToUpper() ?? "";
                Console.Write("Monto: $");
                monto = decimal.TryParse(Console.ReadLine(), out decimal lectura) ? lectura : null;
                sospechoso = false;

                if (!(tipoCuenta == "C" || tipoCuenta == "E" || tipoCuenta == "T")) 
                {
                    Console.WriteLine("-> Descartado: tipo de movimiento inválido.");
                    cantidadDescartadosInvalidos++;
                    Console.WriteLine();
                    continue;
                }

                if (!monto.HasValue | monto <= 0) 
                {
                    Console.WriteLine("-> Descartado: monto inválido.");
                    cantidadDescartadosInvalidos++;
                    Console.WriteLine();
                    continue;
                }

                if (monto < montoMinimoAuditable)
                {
                    Console.WriteLine("-> Omitido: monto menor al mínimo auditable de $ 100,00.");
                    cantidadOmitidosPorMonto++;
                    Console.WriteLine();
                    continue;
                }

                if (monto >= montoSospechoso)
                {
                    Console.WriteLine("-> Auditado. ALERTA: monto sospechoso, derivar a revisión manual.");
                    cantidadSospechosos++;
                    sospechoso = true;
                    Console.WriteLine();
                }

                //Incrementa valor de auditados, y agrega el valor a su respectivo contador
                if (tipoCuenta == "C")
                {
                    cantidadAuditados++;
                    totalCargas += monto ?? 0m;
                }
                else if (tipoCuenta == "E")
                {
                    cantidadAuditados++;
                    totalExtracciones += monto ?? 0m;
                }
                else 
                {
                    cantidadAuditados++;
                    totalTransferencias += monto ?? 0m;
                }

                //Bandera para no imprimir el auditado correctamente cuando es sospechoso
                if (!sospechoso) 
                {
                    Console.WriteLine("-> Auditado correctamente.");
                    Console.WriteLine();
                }
            }

            flujoNeto = totalCargas - totalExtracciones - totalTransferencias;

            //Resumen
            Console.WriteLine("---Resultado de la auditoría---");
            Console.WriteLine($"Movimientos auditado: {cantidadAuditados}");
            Console.WriteLine($"Descartados por datos inválidos: {cantidadDescartadosInvalidos}");
            Console.WriteLine($"Descartados por monto bajo: {cantidadOmitidosPorMonto}");
            Console.WriteLine($"Movimientos sopechosos: {cantidadSospechosos}");
            Console.WriteLine($"Total cargas: ${totalCargas.ToString("N2")}");
            Console.WriteLine($"Total extracciones: ${totalExtracciones.ToString("N2")}");
            Console.WriteLine($"Total transferencias: ${totalTransferencias.ToString("N2")}");
            Console.WriteLine($"Flujo neto: ${flujoNeto.ToString("N2")}");
        }
    }
}
