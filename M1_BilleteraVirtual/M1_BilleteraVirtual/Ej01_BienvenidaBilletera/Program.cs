namespace Ej01_BienvenidaBilletera
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Definicion de variables
            string decoration = new string('=', 46);
            string appName = "BILLETERA VIRTUAL", bankName = "Banco NetSur";

            // Formato de la primer parte del print
            Console.WriteLine(decoration);
            Console.WriteLine("\t" + appName);
            Console.WriteLine("\t" + bankName);
            Console.WriteLine(decoration);
            Console.WriteLine();

            // Formato de las opciones del usuario
            Console.WriteLine("Bienvenido/a. Seleccione una opción:");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Cargar dinero");
            Console.WriteLine("3. Extraer efectivo");
            Console.WriteLine("4. Transferir (CBU / CVU / alias)");
            Console.WriteLine("5. Ver resumen de movimientos");
            Console.WriteLine("6. Salir");
            Console.WriteLine("7. Ver CVU y alias");
            Console.WriteLine();
            Console.WriteLine("Fin de la presentación.");
        }
    }
}
