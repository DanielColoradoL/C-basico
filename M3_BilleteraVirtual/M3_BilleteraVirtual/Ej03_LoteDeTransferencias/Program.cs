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
            decimal monto = 0;

            for (int i = 0; i < maximoTransferenciasLote; i++)
            {
                Console.WriteLine($"Transferencia {i + 1} - Monto: $");
                monto = decimal.TryParse(Console.ReadLine(), out decimal lectura) ? lectura : 0;
                //TBC
            }
        }
    }
}
