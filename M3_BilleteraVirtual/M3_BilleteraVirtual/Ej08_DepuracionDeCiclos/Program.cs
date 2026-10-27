namespace Ej08_DepuracionDeCiclos
{
    internal class Program
    {
        static void Main()
        {
            string titular = "Luis Morales";
            decimal saldo = 1200.00m;
            decimal[] cargas = { 200.00m, 350.00m, -50.00m, 500.00m, 0m, 150.00m };
            string[] clavesIngresadas = { "1111", "2222", "2468" };
            const string claveCorrecta = "2468";
            const int maximoIntentos = 3;
            const decimal tasaMensual = 2.0m;

            Console.WriteLine("Titular: " + titular);

            // Bloque 1: total y promedio de las cargas válidas (mayores que cero).
            decimal totalCargas = 0m;
            int cantidadValidas = 0;
            for (int i = 0; i < cargas.Length; i++)
            {
                if (cargas[i] <= 0)
                {
                    continue;
                }
                totalCargas += cargas[i];
                cantidadValidas++;
            }
            decimal promedio = totalCargas / cantidadValidas;
            Console.WriteLine("Cargas válidas: " + cantidadValidas + " | Total: $ " + totalCargas.ToString("N2") + " | Promedio: $ " + promedio.ToString("N2"));

            // Bloque 2: bonificación de $ 10,00 por cada carga, mostrada con foreach.
            foreach (decimal carga in cargas)
            {
                Console.WriteLine("Carga $ " + carga.ToString("N2") + " -> con bonificación: $ " + (carga + 10).ToString("N2"));
            }

            // Bloque 3: validación de clave con intentos limitados.
            int intentos = 0;
            bool accesoOtorgado = false;
            do
            {
                string claveIngresada = clavesIngresadas[intentos];
                if (claveIngresada == claveCorrecta)
                {
                    accesoOtorgado = true;
                }
                intentos++;
            } while (intentos < maximoIntentos && !accesoOtorgado);
            Console.WriteLine("Acceso: " + (accesoOtorgado ? "concedido" : "denegado") + " tras " + intentos + " intento(s).");

            // Bloque 4: conteo de cargas descartadas con while y continue.
            int posicion = 0;
            int descartadas = 0;
            while (posicion < cargas.Length)
            {
                if (cargas[posicion] <= 0)
                {
                    descartadas++;
                    posicion++;
                    continue;
                }
                posicion++;
            }
            Console.WriteLine("Cargas descartadas: " + descartadas);

            // Bloque 5: recordatorios de vencimiento.
            for (int cuota = 1; cuota <= 3; cuota++)
            {
                Console.WriteLine("Recordatorio de vencimiento: cuota " + cuota);
            }

            // Bloque 6: proyección del saldo a 3 meses con interés compuesto.
            decimal saldoProyectado = saldo;
            for (int mes = 1; mes <= 3; mes++)
            {
                saldoProyectado += saldoProyectado * tasaMensual / 100m;
            }
            Console.WriteLine("Saldo proyectado a 3 meses: $ " + saldoProyectado.ToString("N2"));
            }
        }      
    }
