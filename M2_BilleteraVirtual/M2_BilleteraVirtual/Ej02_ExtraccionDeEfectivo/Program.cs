namespace Ej02_ExtraccionDeEfectivo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const decimal comisionFijaExtraccion = 50m;
            const decimal limiteExtraccionOperacion = 1000m;
            const decimal saldoMinimoAviso = 1000m;
            const decimal montoMinimoExtraccion = 100m;

            string titular = "Ana Gómez Rivera";
            decimal saldo = 1800m;
            int cantidadMovimientos = 0;

            Console.WriteLine("=== EXTRACCIÓN DE EFECTIVO ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine("Saldo disponible: $ " + saldo.ToString("N2"));
            Console.WriteLine();

            Console.Write("Monto a extraer: ");
            //Evalua si tryparse funciona, si si, asigna el valor leido, si no, asigna un 0
            decimal extraer = decimal.TryParse(Console.ReadLine(), out decimal leido) ? leido : 0m;
            decimal totalExtraer = extraer + comisionFijaExtraccion;

            bool montoValido = extraer > 0m;
            bool fondosSuficientes = saldo >= totalExtraer;
            bool dentroDelLimite = extraer <= limiteExtraccionOperacion;
            bool limiteMinimo = extraer >= montoMinimoExtraccion;
            // Las tres condiciones a la vez
            bool aprobada = montoValido && fondosSuficientes && dentroDelLimite && limiteMinimo;

            Console.WriteLine("Monto solicitado: $ " + extraer.ToString("N2"));
            Console.WriteLine("Comision fija: $ " + comisionFijaExtraccion.ToString("N2"));
            Console.WriteLine("Total a descontar: $ " + totalExtraer.ToString("N2"));
            Console.WriteLine($"Monto válido: {(montoValido ? "Si" : "No")}");
            Console.WriteLine($"Fondos suficientes: {(fondosSuficientes ? "Si" : "No")}");
            Console.WriteLine($"Dentro del limite válido: {(dentroDelLimite ? "Si" : "No")}");
            Console.WriteLine($"Monto mínimo cumplido: {(limiteMinimo ? "Si" : "No")}");
            Console.WriteLine($"Estado: {(aprobada ? "APROBADA" : "RECHAZADA")}");

            //Bien podria usar if y else, pero usando el ternario no hay necesidad de usar el else
            if (aprobada)
            {
                saldo -= totalExtraer;
                Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));
                //Chequea si el saldo es menor de 1000
                if (saldo < 1000m)
                {
                    Console.WriteLine("Aviso: su saldo quedó por debajo de $ " + saldoMinimoAviso.ToString("N2"));
                }
                cantidadMovimientos++;
                Console.WriteLine("Movimientos registrados: " + cantidadMovimientos);
            }
        }
    }
}
