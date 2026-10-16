namespace Ej06_ReintentosYProyeccion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Definicion de constantes
            const string claveCorrecta = "2468";
            const int maximoIntentosClave = 3;
            const decimal limiteCargaOperacion = 5000m;
            const decimal tasaRendimientoMensual = 0.4m;
            const decimal metaAhorro = 5000m;
            //Definicion de variables
            string titular = "Ana Gómez Rivera";
            decimal saldo = 1800m;
            int intentos = 0;
            bool aprobado = false;
            decimal monto = 0m;
            decimal rentabilidad = 0m;
            int mes = 0;
            decimal totalRendimientos = 0;


            Console.WriteLine("=== ACCESO A LA BILLETERA ===");
            Console.WriteLine("titular: " + titular);

            //Se repite tres veces o hasta que se aprueba la clave
            while (intentos < maximoIntentosClave && !aprobado)
            {
                Console.Write("Ingrese su clave: ");
                string lecturaClave = Console.ReadLine();
                if (lecturaClave == claveCorrecta)
                {
                    aprobado = true;
                    Console.WriteLine("Acceso condecido.");
                }
                else
                {
                    Console.WriteLine("Clave incorrecta. Intentos restantes: " + (maximoIntentosClave - 1 - intentos));
                }
                intentos++;
            }

            //condicional para ejecutar bloque 2 y 3
            if (!aprobado)
            {
                Console.WriteLine("Cuenta bloqueada por intentos fallidos. Comuníquese con el banco.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("=== CARGA DE DINERO ===");

                //Ciclo para validar que el monto sea valido
                while (!(monto > 0m && monto <= limiteCargaOperacion))
                {
                    monto = decimal.TryParse(Console.ReadLine(), out decimal leido) ? leido : 0m;
                    if (monto <= 0 || monto > limiteCargaOperacion)
                    {
                        Console.WriteLine("Monto no válido. Intente nuevamente.");
                    }
                }
                //Suma el monto al valor total
                saldo += monto;
                //Imprimer carga acreditada y saldo actual
                Console.WriteLine("Carga acreditada: $" + monto.ToString("N2"));
                Console.WriteLine("Saldo actual: $" + saldo.ToString("N2"));

                Console.WriteLine();
                Console.WriteLine("=== PROYECCIÓN DE AHORRO ===");
                //Ciclo para calcular la proyeccion de ahorro
                while (saldo < metaAhorro)
                {
                    rentabilidad = saldo * tasaRendimientoMensual / 100;
                    saldo = saldo + 300 + rentabilidad;
                    mes++;
                    //Desafio opcional
                    totalRendimientos += rentabilidad;
                    Console.WriteLine("Mes " + mes + ": saldo $" + saldo.ToString("N2"));
                }
                Console.WriteLine("La meta se alcanza en " + mes + " meses");
                Console.WriteLine("Rendimientos acumulados: $ " + totalRendimientos.ToString("N2"));
            }
        }
    }
}