namespace ConsoleApp_HolaMundo
{
    internal class Desafio
    {
        static void Main(string[] args)
        {
            static void e1()
            {
                int n1 = 5;
                int n2 = 10;

                Console.WriteLine($"n1 es igual a {n1}, n2 es igual a {n2} y n1 mas n2 es igual a {n1 + n2}");
            }

            static void e2()
            {
                bool n1 = true;
                bool n2 = false;
                bool n3 = true;

                Console.WriteLine(n1 ^ n2);
                Console.WriteLine((n1 & n2) | n3);
                Console.WriteLine((n1 | n2) & !n3);
            }

            static void e3()
            {
                const decimal IVA = 21;
                decimal ivaReal = IVA / 100.0m;
                decimal remera = 59.90m;
                decimal pantalon = 99.90m;
                decimal campera = 149.90m;

                Console.WriteLine("Ejercicio 3 - Uso de constantes");
                Console.WriteLine();
                Console.WriteLine($"Precio final remera: {remera + (ivaReal * remera):F3}");
                Console.WriteLine($"Precio final pantalon: {pantalon + (ivaReal * pantalon):F3}");
                Console.WriteLine($"Precio final campera: {campera + (ivaReal * campera):F15}");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();

            }

            e1();
            e2();
            e3();

        }
    }
}
