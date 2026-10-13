namespace Ej03_TransferenciaValidada
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaracion de constantes
            const decimal porcentajeComision = 1.5m;
            const decimal limiteTransferenciaOperacion = 2000m;
            const decimal umbralValidacionSms = 1000m;
            const string codigoSmsCorrecto = "482915";

            //Declaracion de variables
            string titular = "Ana Gómez Rivera";
            decimal saldo = 1800m;
            int cantidadMovimientos = 0;
            bool cuentaActiva = true;
            bool aprobada = false;
            string motivoRechazo = "";

            //Print inicial
            Console.WriteLine("=== TRANSFERENCIA A CVU ===");
            Console.WriteLine("Titular: " + titular);
            Console.WriteLine("Saldo disponible: $ " + saldo.ToString("N2"));
            Console.WriteLine();

            Console.Write("Monto a transferir: ");
            //Evalua si tryparse funciona, si si, asigna el valor leido, si no, asigna un 0
            decimal transferir = decimal.TryParse(Console.ReadLine(), out decimal leido) ? leido : 0m;
            decimal comision = transferir * porcentajeComision / 100;
            decimal totalTransferir = transferir + comision;

            if (cuentaActiva)
            {
                if (transferir > 0)
                {
                    if (transferir <= limiteTransferenciaOperacion)
                    {
                        if (totalTransferir <= saldo)
                        {
                            if (transferir > umbralValidacionSms)
                            {
                                Console.WriteLine("Esta operación requiere validación por SMS.");
                                Console.Write("Código recibido: ");
                                string codigoIngresado = Console.ReadLine();
                                if (codigoIngresado == codigoSmsCorrecto)
                                {
                                    aprobada = true;
                                }
                                else
                                {
                                    motivoRechazo = "El código SMS es incorrecto.";
                                    Console.WriteLine("Codigo incorrecto, vuelva a intentarlo");
                                    Console.Write("Código recibido: ");
                                    codigoIngresado = Console.ReadLine();
                                    if (codigoIngresado == codigoSmsCorrecto)
                                    {
                                        aprobada = true;
                                    }
                                    else
                                    {
                                        motivoRechazo = "El código SMS es incorrecto.";
                                    } 
                                }
                            }
                            else 
                            {
                                aprobada = true;
                            }
                        }
                        else 
                        {
                            motivoRechazo = "Saldo insuficiente para cubrir el monto y la comisión.";
                        }
                    }
                    else 
                    {
                        motivoRechazo = "El monto supera el límite por operación de $ 2.000,00.";
                    }
                }
                else
                {
                    motivoRechazo = "El monto debe ser un número mayor que cero.";
                }
            }
            else 
            {
                motivoRechazo = "La cuenta está bloqueada.";
            }

            Console.WriteLine();
            //condicion final para o bien realizar la transaccion o para denegarla
            if (aprobada)
            {
                Console.Write("Monto: $" + transferir.ToString("N2"));
                Console.WriteLine(" | Comisión: $" + comision.ToString("N2"));
                Console.WriteLine("Total descontado: $" + totalTransferir.ToString("N2"));
                Console.WriteLine($"Estado: {(aprobada ? "APROBADA" : "RECHAZADA")}");
                saldo -= totalTransferir;
                cantidadMovimientos++;
                Console.WriteLine("Saldo actualizado: $" + saldo.ToString("N2"));
                Console.WriteLine("Movimientos registrados: " + cantidadMovimientos);
            }
            else
            {
                Console.WriteLine($"Estado: {(aprobada ? "APROBADA" : "RECHAZADA")}");
                Console.WriteLine("Saldo : $" + saldo.ToString("N2"));
                Console.WriteLine($"Motivo: " + motivoRechazo);
            }
        }
    }
}
