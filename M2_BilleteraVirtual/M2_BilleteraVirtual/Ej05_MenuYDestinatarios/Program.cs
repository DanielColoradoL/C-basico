namespace Ej05_MenuYDestinatarios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //deficion de constantes
            const decimal comisionFijaExtraccion = 50m;
            //Definicion de variables
            string nombreOperacion = "";
            string costoOperacion = "";
            string descripcionDestino = "";
            string plazoAcreditacion = "";
            char tipoCuenta = '0';
            string cuenta = "";
            decimal descubierto = 0;
            string categoriaOperacion = "";
            decimal saldo = 1800m;
            string tramoCaja = "";
            decimal tasaRendimiento = 0m;

            //Menu de seleccion
            Console.WriteLine("=== MENÚ DE LA BILLETERA ===");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Cargar dinero");
            Console.WriteLine("3. Extraer efectivo");
            Console.WriteLine("4. Transferir (CBU / CVU / alias)");
            Console.WriteLine("5. Ver resumen de movimientos");
            Console.WriteLine("6. Salir");


            Console.Write("Seleccione una opción: ");
            //Lectura de la opcion a seleccionar si el parse funciona regresa el valor ingresado, si no, regresa 0
            int selectorMenu = int.TryParse(Console.ReadLine(), out int menuLeido) ? menuLeido : 0;

            //Switch para seleccionar la opcion del menu
            switch (selectorMenu)
            {
                case 1:
                    nombreOperacion = "Consultar saldo";
                    costoOperacion = "Sin costo";
                    break;
                case 2:
                    nombreOperacion = "Cargar dinero";
                    costoOperacion = "Sin costo";
                    break;
                case 3:
                    nombreOperacion = "Extraer efectivo";
                    costoOperacion = "Comisión fija de $ " + comisionFijaExtraccion.ToString("N1");
                    break;
                case 4:
                    nombreOperacion = "Transferir";
                    costoOperacion = "Comisión escalonada del 1,0 % al 1,5 %)";
                    break;
                case 5:
                    nombreOperacion = "Ver resumen de movimientos";
                    costoOperacion = "Sin costo";
                    break;
                case 6:
                    nombreOperacion = "Salir";
                    costoOperacion = "Sin costo";
                    break;
                default:
                    nombreOperacion = "Opción no válida";
                    costoOperacion = "No corresponde";
                    break;
            }
            //Imprime en consola la opcion seleccionada
            Console.WriteLine("Operación seleccionada: " + nombreOperacion);
            Console.WriteLine("Costo: " + costoOperacion);
            Console.WriteLine();

            Console.WriteLine("=== TIPO DE DESTINATARIO ===");
            Console.Write("Tipo de identificador (CBU / CVU / ALIAS): ");
            //Lectura del identificador y conversion a mayusculas
            string selectorIdentificador = Console.ReadLine().ToUpper();

            //Switch para seleccionar el tipo de identificador
            switch (selectorIdentificador)
            {
                case "cbu":
                case "CBU":
                    descripcionDestino = "Cuenta bancaria";
                    plazoAcreditacion = "Hasta 24 horas hábiles";
                    break;
                case "cvu":
                case "CVU":
                    descripcionDestino = "Billetera virtual";
                    plazoAcreditacion = "Inmediata";
                    break;
                case "alias":
                case "ALIAS":
                    descripcionDestino = "Alias asociado a un CBU o CVU";
                    plazoAcreditacion = "Según la cuenta asociada";
                    break;
                default:
                    descripcionDestino = "Tipo de identificador no reconocido";
                    plazoAcreditacion = "No corresponde";
                    break;
            }
            //Imprime en consola el identificador seleccionada
            Console.WriteLine("Destino: " + descripcionDestino);
            Console.WriteLine("Acreditación: " + plazoAcreditacion);
            Console.WriteLine();

            Console.WriteLine("=== TIPO DE CUENTA ===");
            Console.Write("Tipo de cuenta (A = caja de ahorro, C = cuenta corriente): ");
            tipoCuenta = char.TryParse(Console.ReadLine().ToUpper(), out char charLeido) ? charLeido : '0';

            //Switch para identificar el tipo de cuenta
            switch (tipoCuenta)
            {
                case 'a':
                case 'A':
                    cuenta = "Caja de ahorro en pesos";
                    descubierto = 0m;
                    break;
                case 'c':
                case 'C':
                    cuenta = "Cuenta corriente";
                    descubierto = 500m;
                    break;
                default:
                    cuenta = "Tipo de cuenta no reconocido";
                    descubierto = 0m;
                    break;
            }
            //Imprime en consola los detalles de la cuenta
            Console.WriteLine("Cuenta: " + cuenta);
            Console.WriteLine("Descubierto: $" + descubierto.ToString("N2"));
            Console.WriteLine();

            //switch opcional
            switch (selectorMenu)
            {
                case 1:
                case 5:
                    categoriaOperacion = "Consulta";
                    break;
                case 2:
                case 3:
                    categoriaOperacion = "Movimiento de efectivo";
                    break;
                case 4:
                    categoriaOperacion = "Transferencia";
                    break;
                case 6:
                    categoriaOperacion = "Salida";
                    break;
                default:
                    categoriaOperacion = "Desconocida.";
                    break;
            }
            Console.WriteLine("Categoría de la operación: " + categoriaOperacion);

            //Pendiente revisarlo
            //Desafio opcional
            switch (saldo)
            {
                case <= 0:
                    tramoCaja = "Clasico";
                    tasaRendimiento = 0.2m;
                    break;
                case < 1000:
                    tramoCaja = "Saldo inicial";
                    tasaRendimiento = 0.2m;
                    break;
                case < 5000:
                    tramoCaja = "Saldo intermedio";
                    tasaRendimiento = 0.4m;
                    break;
                default:
                    tramoCaja = "Saldo alto";
                    tasaRendimiento = 0.6m;
                    break;
            }

            //Imprime en consola dependiendo si es o no aprobado
            if (saldo > 0)
            {
                Console.WriteLine("Categoria: " + tramoCaja);
                Console.WriteLine("Tasa mensual: " + tasaRendimiento.ToString("N1") + " %");
                decimal rendimiento = saldo * tasaRendimiento / 100;
                Console.WriteLine("Rendimiento del mes: $" + rendimiento.ToString("N2"));
                decimal totalSaldo = saldo + rendimiento;
                Console.WriteLine("Total a descontar: $" + totalSaldo.ToString("N2"));
            }
            else
            {
                Console.WriteLine("Sin saldo para rendimiento");
            }
        }
    }
}
