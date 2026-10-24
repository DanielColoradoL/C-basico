namespace Ej07_RegistroDeMovimientos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Constantes
            const decimal saldoInicial = 1500m;
            const decimal montoRelevante = 1000m;

            //Variables
            string[] conceptos =
                {
                "Carga inicial",
                "Extracción cajero",
                "Transferencia a Luis",
                "Carga desde banco",
                "Extracción cajero",
                "Transferencia a María",
                "Carga desde banco",
                "Comisión mensual"
                };

            decimal[] montos = { 2000m, -500m, -800m, 1200m, -300m, -450m, 600m, -50m };
            decimal total = 0m;
            decimal ingresos = 0m;
            decimal egresos = 0m;

            //Print inicial
            Console.WriteLine("=== REGISTRO DE MOVIMIENTOS ===");
            Console.WriteLine($"Cantidad de movimientos: {conceptos.Length}");
            Console.WriteLine();
            Console.WriteLine("--- Detalle de movimientos ---");
            Console.WriteLine($"Saldo inicial: ${saldoInicial.ToString("N2")}");

            //RF2
            for (int i = 0; i < conceptos.Length; i++)
            {
                //condicion para agregar ingresos o egresos
                if (montos[i] < 0) { egresos += montos[i]; }
                else { ingresos += montos[i]; }
                total = saldoInicial + ingresos + egresos;
                Console.WriteLine($"{i + 1}. {conceptos[i],-22} $ {montos[i].ToString("N2"),10} | Saldo: ${total.ToString("N2")}");
            }

            //Reset a 0 para RF3
            total = 0m;
            ingresos = 0m;
            egresos = 0m;
            foreach (decimal monto in montos)
            {
                //condicion para agregar ingresos o egresos
                if (monto < 0) { egresos += monto; }
                else { ingresos += monto; }
            }
            total = saldoInicial + ingresos + egresos;

            Console.WriteLine();
            Console.WriteLine("--- Totales ---");
            Console.WriteLine($"Ingresos: ${ingresos.ToString("N2")}");
            Console.WriteLine($"Egresos: ${egresos.ToString("N2")}");
            Console.WriteLine($"Saldo final: ${total.ToString("N2")}");
            Console.WriteLine();

            //RF4
            int indiceMayor = 0;
            int indiceMenor = 0;
            decimal valorMax = 0;
            decimal valorMin = 0;

            for (int i = 0; i < montos.Length; i++)
            {
                if (montos[i] >= valorMax)
                {
                    indiceMayor = i;
                    valorMax = montos[i];
                }
                else if (montos[i] <= valorMin)
                {
                    indiceMenor = i;
                    valorMin = montos[i];
                }
            }

            Console.WriteLine("--- Extremos ---");
            Console.WriteLine($"Mayor ingreso: ${montos[indiceMayor]} ({conceptos[indiceMayor]})");
            Console.WriteLine($"Mayor egreso: ${montos[indiceMenor]} ({conceptos[indiceMenor]})");
            Console.WriteLine();

            //RF5
            int contadorRelevantes = 0;
            Console.WriteLine("--- Movimientos relevantes (>= $ 1.000,00) ---");
            for (int i = 0; i < montos.Length; i++)
            {
                if (montos[i] >= 1000m)
                {
                    Console.WriteLine($"- {conceptos[i]}: ${montos[i].ToString("N2")}");
                    contadorRelevantes++;
                }
                else if (montos[i] <= -1000m)
                {
                    Console.WriteLine($"- {conceptos[i]}: ${montos[i].ToString("N2")}");
                    contadorRelevantes++;
                }
            }
            Console.WriteLine("Total de movimientos relevantes: " + contadorRelevantes);
            Console.WriteLine();

            //RF6
            string textoBuscar = "";

            Console.Write("Concepto a buscar: ");
            textoBuscar = Console.ReadLine() ?? "";
            bool busquedaExitosa = false;
            int indiceBusqueda = 0;

            for (int i = 0; i < conceptos.Length; i++)
            {
                if (conceptos[i] == textoBuscar)
                {
                    indiceBusqueda = i;
                    busquedaExitosa |= true;
                    break;
                }
            }

            if (busquedaExitosa)
            {
                Console.WriteLine($"Primera aparicion en la posicion {indiceBusqueda + 1}: $ {montos[indiceBusqueda].ToString("N2")}");
            }
            else 
            {
                Console.WriteLine("No se encontró ningún movimiento con ese concepto.");
            }
            Console.WriteLine();

            //RF7
            Console.Write("Número de movimiento a corregir (1 a 8):");
            int indiceModificar = int.TryParse(Console.ReadLine(), out int lectura) ? lectura : -1;
            indiceModificar--;
            if (indiceModificar >= 0 && indiceModificar < montos.Length)
            {
                Console.Write("Nuevo monto: $");
                decimal nuevoMonto = decimal.TryParse(Console.ReadLine(), out decimal montoLeido) ? montoLeido : 0;
                Console.WriteLine($"Movimiento corregido: de ${montos[indiceModificar].ToString("N2")} a ${nuevoMonto.ToString("N2")}");
                montos[indiceModificar] = nuevoMonto;

                //Reuse RF3 para calcular el total
                total = 0m;
                ingresos = 0m;
                egresos = 0m;
                foreach (decimal monto in montos)
                {
                    //condicion para agregar ingresos o egresos
                    if (monto < 0) { egresos += monto; }
                    else { ingresos += monto; }
                }
                total = saldoInicial + ingresos + egresos;
                Console.WriteLine($"Nuevo saldo final: ${total.ToString("N2")}");
            }
            else 
            {
                Console.WriteLine($"El movimiento {indiceModificar + 1} está fuera de rango: no se modifica nada.");
            }
        }
    }
}

