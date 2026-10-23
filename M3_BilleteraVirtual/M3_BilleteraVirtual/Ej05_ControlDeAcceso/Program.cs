namespace Ej05_ControlDeAcceso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Constantes
            const string claveCorrecta = "2468";
            const int maximoIntentosClave = 3;
            const int horaApertura = 6;
            const int horaCierre = 22;
            const decimal limiteExtraccionOperacion = 1000m;
            const decimal limiteExtraccionDiario = 1500;
            const decimal comisionFija = 50m;

            //Variables definidas
            decimal saldo = 400m;
            decimal totalExtraidoHoy = 900m;

            //Variables propias
            bool accesoOtorgado = false;
            int hora = 0;
            string clave = "";
            decimal extraer = 0m;


            //Print inicial
            Console.WriteLine("=== ACCESO A LA BILLETERA VIRTUAL ===");
            Console.Write("Hora actual(0 a 23): ");
            hora = int.TryParse(Console.ReadLine(), out int horaLeida) ? horaLeida : -1;
            Console.WriteLine();

            //Si la hora no esta en el rango finaliza
            if (!(hora >= 0 && hora <= 23))
            {
                Console.WriteLine("Hora inválida. Fin del programa.");
                return;
            }

            if (hora < horaApertura || hora >= horaCierre) 
            {
                Console.WriteLine("Servicio disponible de 6:00 a 22:00. Fin del programa.");
                return;
            }

            //Itera 3 veces y sale si encuentra la clave correcta
            for (int i = 0; i < maximoIntentosClave; i++) 
            {
                Console.Write($"Ingrese su clave (intento {i + 1} de 3): ");
                clave = Console.ReadLine() ?? "";

                if (clave == claveCorrecta)
                { 
                    accesoOtorgado = true;
                    Console.WriteLine();
                    break;
                }

                Console.WriteLine("Clave incorrecta.");
                Console.WriteLine();
            }

            //Cancela el programa si no tiene access.
            if (!accesoOtorgado)
            { 
                Console.WriteLine("Cuenta bloqueada por intentos fallidos. Fin del programa.");
                return;
            }

            //Print de extraer efectivo
            Console.WriteLine("--- Extraer efectivo ---");
            Console.Write($"Saldo: ${saldo.ToString("N2")} | ");
            Console.WriteLine($"Extraido hoy: ${totalExtraidoHoy.ToString("N2")} | ");

            Console.Write("Monto a extraer: $");
            extraer = decimal.TryParse(Console.ReadLine(), out decimal leido) ? leido : 0;

            if (extraer <= 0 ||
                extraer > limiteExtraccionOperacion ||
                extraer > limiteExtraccionDiario ||
                extraer > saldo + comisionFija)
            {
                Console.WriteLine("Estado: RECHAZADO.");
                return;
            }

            //Resumen si la transferencia es aprobada
            Console.WriteLine();
            saldo -= extraer + comisionFija;
            totalExtraidoHoy += extraer + comisionFija;
            Console.WriteLine("Estado: APROBADO.");
            Console.WriteLine($"Saldo actualizado: ${saldo.ToString("N2")}");
            Console.WriteLine($"Fin de la sesión. Extraído hoy: ${totalExtraidoHoy.ToString("N2")}");
        }
    }
}