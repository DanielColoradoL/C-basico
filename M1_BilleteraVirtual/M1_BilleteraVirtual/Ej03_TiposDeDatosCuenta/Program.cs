namespace Ej03_TiposDeDatosCuenta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Definicion de variables

            string titular = "Ana Gómez Rivera";
            string cvu = "0000003100012345678901";
            string aliasBilletera = "ana.gomez.billetera";
            //(A = Caja de ahorro, C = Cuenta corriente)
            //Dado que no existen muchos tipos de cuentas un Char puede representar bien el dato
            char tipoCuenta = 'A';
            string tipoCuentaLargo;
            decimal saldoDisponible = 1800.00m;
            decimal saldoMinimoMantenimiento = 50.00m;
            //Un int es lo suficientemente grande para representar movimientos de una cuenta
            int cantidadMovimientos = 12;
            //Se usa long por lo que el id es un indicador del banco, conteniendo
            //muchisimas transacciones
            long idUltimaOperacion = 202610030001;
            // Usualmente con poco menos de 10 intentos se bloquea una cuenta, un byte permite 255
            byte intentosClaveFallidos = 1;
            bool cuentaActiva = true;
            bool tieneTarjetaDebito = false;
            DateTime fechaApertura = new System.DateTime(2023, 03, 15);
            //Puede ser null, ya que existe el escenario donde no hay ultimo movimiento
            DateTime? fechaUltimoMovimiento = null;
            string fechaUltimoMovimientoTexto;

            Console.WriteLine("=== FICHA DE LA BILLETERA ===");
            Console.WriteLine($"Titular: {titular}");
            Console.WriteLine($"CVU: {cvu}");
            Console.WriteLine($"Alias: {aliasBilletera}");

            //Uso del operador ternario para seleccionar la opcion adecuada
            tipoCuentaLargo = tipoCuenta == 'A' ? "Caja de ahorro en pesos" : tipoCuenta == 'C' ? "Cuenta corriente" : "Desconocido";
            Console.WriteLine($"Tipo de cuenta: {tipoCuentaLargo}");
            Console.WriteLine("Saldo disponible: $" + saldoDisponible.ToString("N2"));
            Console.WriteLine("Saldo minimo de mantenimiento: $" + saldoMinimoMantenimiento.ToString("N2"));
            Console.WriteLine($"Cantidad de movimientos: {cantidadMovimientos}");
            Console.WriteLine($"Último identificador de operación: {idUltimaOperacion}");
            Console.WriteLine($"Intentos fallidos de clave: {intentosClaveFallidos}");
            Console.WriteLine($"Cuenta activa: {cuentaActiva}");
            Console.WriteLine($"Tarjeta de débito: {tieneTarjetaDebito}");

            //La fecha se cambia a string usando el formato requerido
            Console.WriteLine($"Fecha de alta: {fechaApertura.ToString("dd/MM/yyyy")}");

            //Aca se compara si tiene valor, si si, se convierte ese valor en string con formato
            //si no, se usa un string auxiliar que indica que no han habido movimientos
            fechaUltimoMovimientoTexto = 
                fechaUltimoMovimiento.HasValue ? 
                fechaUltimoMovimiento.Value.ToString("dd/MM/yyyy") : "Sin movimientos registrados";
            Console.WriteLine($"Último movimiento: {fechaUltimoMovimientoTexto}");
            Console.WriteLine();

            //Se actualiza fecha del ultimo movimiento y se compara de nuevo
            fechaUltimoMovimiento = new System.DateTime(2026, 09, 28);
            fechaUltimoMovimientoTexto =
                fechaUltimoMovimiento.HasValue ?
                fechaUltimoMovimiento.Value.ToString("dd/MM/yyyy") : "Sin movimientos registrados";
            Console.WriteLine($"Último movimiento (actualizado): {fechaUltimoMovimientoTexto}");

            //RF5
            //No se puede convertir implicitamente un int a un double, toca hacerlo explicito usanto toFloat
            //int cuotas = 12.5;
            //Habria overflow, el valor maximo de un byte es 255, 300 esta fuera de rango
            //byte intentos = 300;
        }
    }
}
