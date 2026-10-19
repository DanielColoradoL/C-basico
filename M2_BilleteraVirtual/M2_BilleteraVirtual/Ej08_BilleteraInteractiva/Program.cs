namespace Ej08_BilleteraInteractiva
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Definicion de constantes
            const string claveCorrecta = "2468";
            const string codigoSmsCorrecto = "482915";
            const int maximoIntentosClave = 3;
            const decimal comisionFijaExtraccion = 50m;
            const decimal limiteExtraccionOperacion = 1000m;
            const decimal limiteExtraccionDiario = 1500m;
            const decimal limiteTransferenciaOperacion = 2000m;
            const decimal limiteCargaOperacion = 5000m;
            const decimal umbralValidacionSms = 1000m;


            //Definicion de variables
            string titular = "Ana Gómez Rivera";
            decimal saldo = 1500m;
            int cantidadMovimientos = 0;
            int cantidadRechazos = 0;
            decimal totalExtraidoHoy = 0;
            decimal totalComisiones = 0;
            DateTime fechaSesion = new DateTime(2026, 10, 03);
            DateTime? ultimoMovimiento;
            int intentos = 0;
            bool aprobado = false;
            int selectorMenu = 0;
            string descripcionDestino = "";

            Console.WriteLine("=== BILLETERA VIRTUAL - Banco NetSur ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine();

            while (intentos < maximoIntentosClave && !aprobado)
            {
                Console.Write("Ingrese su clave: ");
                string lecturaClave = Console.ReadLine();
                if (lecturaClave == claveCorrecta)
                {
                    aprobado = true;
                    Console.WriteLine("Acceso condecido.\n");
                }
                else
                {
                    Console.WriteLine("Clave incorrecta. Intentos restantes: " + (maximoIntentosClave - 1 - intentos));
                }
                intentos++;
            }
            if (aprobado) 
            {

                //While para permanecer en el menu
                while (selectorMenu != 6)
                {
                    //Menu de seleccion
                    Console.WriteLine("=== MENÚ DE LA BILLETERA ===");
                    Console.WriteLine("1. Consultar saldo");
                    Console.WriteLine("2. Cargar dinero");
                    Console.WriteLine("3. Extraer efectivo");
                    Console.WriteLine("4. Transferir (CBU / CVU / alias)");
                    Console.WriteLine("5. Ver resumen de movimientos");
                    Console.WriteLine("6. Salir");
                    Console.WriteLine();

                    Console.Write("Seleccione una opción: ");
                    //Lectura de la opcion a seleccionar si el parse funciona regresa el valor ingresado, si no, regresa 0
                    selectorMenu = int.TryParse(Console.ReadLine(), out int menuLeido) ? menuLeido : 0;

                    //Switch para seleccionar la opcion del menu
                    switch (selectorMenu)
                    {
                        case 1:
                            Console.WriteLine("--- 1. Consultar saldo ---");
                            Console.WriteLine("Saldo disponible: $" + saldo.ToString("N2") + "\n");

                            break;
                        case 2:
                            Console.WriteLine("--- 2.Cargar dinero ---");
                            Console.Write("Monto a cargar: ");
                            //Lectura de terminal y filtrado de si es o no un decimal.
                            decimal monto = decimal.TryParse(Console.ReadLine(), out decimal montoLeido) ? montoLeido : 0m;

                            if (monto <= 0)
                            {
                                Console.WriteLine("Estado: RECHAZADO");
                                Console.WriteLine("El monto debe ser mayor que cero. No se realizó la carga.");
                            }
                            // Si es numero pero mayor que monto de carga elevada
                            else if (monto >= limiteCargaOperacion)
                            {
                                Console.WriteLine("Estado: RECHAZADO");
                                Console.WriteLine("Carga de monto elevado. Será informada al área de control.");
                            }
                            // Si es numero valido para cargar
                            else
                            {
                                saldo += monto;
                                cantidadMovimientos++;
                                ultimoMovimiento = DateTime.Now;
                                Console.WriteLine("Estado: APROBADO");
                                Console.WriteLine("Saldo actual: $" + saldo.ToString("N2"));
                            }
                            Console.WriteLine();

                            break;
                        case 3:
                            Console.WriteLine("--- 3. Extraer efectivo ---");

                            Console.Write("Monto a extraer: ");
                            //Evalua si tryparse funciona, si si, asigna el valor leido, si no, asigna un 0
                            decimal extraer = decimal.TryParse(Console.ReadLine(), out decimal leido) ? leido : 0m;
                            decimal totalExtraer = extraer + comisionFijaExtraccion;

                            bool montoValido = extraer > 0m;
                            bool fondosSuficientes = saldo >= totalExtraer;
                            bool limiteOperacion = extraer <= limiteExtraccionOperacion;
                            bool limiteDiario = totalExtraidoHoy <= limiteExtraccionDiario;
                            // Las CUATRO condiciones a la vez
                            bool aprobada = montoValido && fondosSuficientes && limiteOperacion && limiteDiario;

                            if (aprobada)
                            {
                                Console.WriteLine("Total a descontar: $ " + totalExtraer.ToString("N2") + " (comisión: $ " + comisionFijaExtraccion.ToString("N2") + ")");
                                Console.WriteLine($"Estado: APROBADA");

                                saldo -= totalExtraer;
                                totalExtraidoHoy += totalExtraer;
                                totalComisiones += comisionFijaExtraccion;

                                Console.WriteLine("Saldo actualizado: $ " + saldo.ToString("N2"));
                                Console.WriteLine("Saldo disponible para retirar por hoy: $ " + (limiteExtraccionDiario - totalExtraidoHoy).ToString("N2"));
                                cantidadMovimientos++;
                                ultimoMovimiento = DateTime.Now;
                            }
                            else 
                            {
                                Console.WriteLine($"Estado: RECHAZADO");
                            }
                            Console.WriteLine();

                            break;
                        case 4:
                            bool identificadorAprobado = false;
                            bool operacionPermitida = false;
                            decimal porcentajeComision = 0;

                            Console.WriteLine("--- 4. Transferir ---");
                            Console.Write("Tipo de identificador (CBU / CVU / ALIAS): ");
                            //Lectura del identificador y conversion a mayusculas
                            string selectorIdentificador = Console.ReadLine();

                            //Switch para seleccionar el tipo de identificador
                            switch (selectorIdentificador)
                            {
                                case "cbu":
                                case "CBU":
                                    descripcionDestino = "Cuenta bancaria";
                                    identificadorAprobado = true;
                                    break;
                                case "cvu":
                                case "CVU":
                                    descripcionDestino = "Billetera virtual";
                                    identificadorAprobado = true;
                                    break;
                                case "alias":
                                case "ALIAS":
                                    descripcionDestino = "Alias asociado a un CBU o CVU";
                                    identificadorAprobado = true;
                                    break;
                                default:
                                    descripcionDestino = "Tipo de identificador no reconocido"; 
                                    break;
                            }

                            //if (identificadorAprobado)
                            //{
                            //    Console.WriteLine("Destino: " + descripcionDestino);
                            //    Console.Write("Monto a transferir: ");
                            //    decimal transferir = decimal.TryParse(Console.ReadLine(), out decimal transferirLeido) ? transferirLeido : 0m;

                            //    //Condiciones para procesar el porcentaje de comision y si es o no permitida la operacion
                            //    if (transferir <= 0)
                            //    {
                            //        operacionPermitida = false;
                            //    }
                            //    else if (transferir <= 500)
                            //    {
                            //        operacionPermitida = true;
                            //        porcentajeComision = 1.5m;
                            //    }
                            //    else if (transferir <= 1000)
                            //    {

                            //        operacionPermitida = true;
                            //        porcentajeComision = 1.2m;
                            //    }
                            //    else if (transferir <= limiteTransferenciaOperacion)
                            //    {

                            //        operacionPermitida = true;
                            //        porcentajeComision = 1m;
                            //    }
                            //    else
                            //    {
                            //        tramo = "Supera el límite por operación";
                            //    }

                            //    //Imprime en consola dependiendo si es o no aprobado
                            //    if (operacionPermitida)
                            //    {

                            //        Console.WriteLine("Porcentaje de comisión: " + porcentajeComision.ToString("N1") + " %");
                            //        decimal comision = transferir * porcentajeComision / 100;
                            //        Console.WriteLine("Comisión: $" + comision.ToString("N2"));
                            //        decimal totalTransferir = transferir + comision;
                            //        Console.WriteLine("Total a descontar: $" + totalTransferir.ToString("N2"));
                            //    }
                            //    else
                            //    {

                            //        Console.WriteLine("La transferencia no puede calcularse");
                            //    }

                            //    Console.WriteLine();




                            //}
                            //else 
                            //{
                            //    Console.WriteLine($"Estado: RECHAZADO");
                            //}




                            Console.WriteLine("4");
                            break;
                        case 5:
                            Console.WriteLine("5");
                            break;
                        case 6:
                            Console.WriteLine("6");
                            break;
                        default:
                            Console.WriteLine("Salir?");
                            break;
                    }
                }
            }
        }
    }
}
