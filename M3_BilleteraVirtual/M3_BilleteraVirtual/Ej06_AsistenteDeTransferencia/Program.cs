namespace Ej06_AsistenteDeTransferencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Constantes
            const int maximoReintentos = 3;
            const decimal limiteTransferenciaOperacion = 2000m;
            const decimal comisionPorcentaje = 1.2m;

            //Variables definidas
            decimal saldo = 3000;
            string descripcionDestino = "";
            bool destinoValido = false;
            bool operacionAprobada = false;
            bool operacionFinalizada = false;
            int reintentosMonto = 0;

            //Variables
            string destino = "";
            decimal? monto = 0m;
            decimal comision = 0m;
            decimal total = 0m;
            string menu ="";

            //Print fijo
            Console.WriteLine("=== ASISTENTE DE TRANSFERENCIA ===");
            Console.WriteLine("Saldo disponible: $" + saldo.ToString("N2"));

            for (int i = 0; i < maximoReintentos; i++) 
            {
                Console.Write("Tipo de destino (CBU / CVU / ALIAS): ");
                destino = Console.ReadLine()?.ToUpper() ?? "";

                switch (destino)
                {
                    case "CBU":
                        descripcionDestino = "Cuenta bancaria";
                        destinoValido = true;
                        break;
                    case "CVU":
                        descripcionDestino = "Billetera virtual";
                        destinoValido = true;
                        break;
                    case "ALIAS":
                        descripcionDestino = "Alias";
                        destinoValido = true;
                        break;
                }
                Console.WriteLine();

                if (destinoValido) { break; }

                Console.WriteLine($"Tipo no reconocido ({i + 1} de 3).");
            }

            if (destinoValido)
            {
                Console.WriteLine("Destino: " + descripcionDestino);
                while (!operacionFinalizada)
                {
                    //Evalua que el monto no haya sido equivocado mas de 3 veces
                    if (reintentosMonto >= 3)
                    {
                        operacionFinalizada = true;
                        continue;
                    }

                    Console.Write("Monto a transferir: $");
                    monto = decimal.TryParse(Console.ReadLine(), out decimal montoLeido) ? montoLeido : -1;

                    if (monto <= 0 || monto > limiteTransferenciaOperacion)
                    {
                        reintentosMonto++;
                        Console.WriteLine($"Monto inválido. Debe estar entre $0,01 y $2.000,00 {reintentosMonto} de 3");
                        continue;
                    }

                    comision = monto * comisionPorcentaje / 100 ?? 0;
                    total = monto + comision ?? 0;

                    if (saldo < total) 
                    {
                        Console.WriteLine($"Saldo insuficiente. Se requieren $ {total.ToString("N2")}.");
                        continue;
                    }
                    Console.WriteLine();

                    //Confirmacion
                    Console.WriteLine("--- Confirmación ---");
                    Console.WriteLine("Destino: " + descripcionDestino);
                    Console.WriteLine("Monto: $" + monto?.ToString("N2"));
                    Console.WriteLine($"Comision ({comisionPorcentaje.ToString("N1")} %): ${comision.ToString("N2")}");
                    Console.WriteLine("Todal a debitar: $" + total.ToString("N2"));

                    Console.Write("1. Confirmar  | 2. Cambiar monto  | 3. Cancelar: ");
                    menu = Console.ReadLine() ?? "";
                    Console.WriteLine();

                    //Menu selector de si aceptar, cambiar monto o cancelar
                    switch (menu) 
                    {
                        case "1":
                            saldo -= total;
                            Console.WriteLine("Estado: APROBADA");
                            Console.WriteLine("Saldo actualizado: $" + saldo.ToString("N2"));
                            operacionAprobada = true;
                            operacionFinalizada = true;
                            break;
                        case "2":
                            reintentosMonto = 0;
                            break;
                        default:
                            operacionFinalizada = true;
                            break;
                    }
                }
                //Si no fue aprobada la operacion indica que fue cancelada
                Console.WriteLine();
                if (!operacionAprobada)
                {
                    Console.WriteLine("Operación cancelada. No se modificó el saldo.");
                }
                Console.WriteLine("Fin del asistente");
            }
        }
    }
}
