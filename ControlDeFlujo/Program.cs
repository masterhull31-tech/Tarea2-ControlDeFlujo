// =============================================================
//  Algoritmos Computacionales
//  Actividad: Control de flujo de una aplicación
//  Programa: Calculadora de áreas y verificador de edad
// =============================================================

using System.Globalization;

namespace ControlDeFlujo
{
    internal class Program
    {
        // Constante para la mayoría de edad en República Dominicana
        const int MAYORIA_DE_EDAD = 18;

        static void Main(string[] args)
        {
            Console.Title = "Calculadora de Áreas y Verificador de Edad";
            bool continuar = true;

            // Ciclo principal: el menú se repite hasta que el usuario elija salir
            while (continuar)
            {
                MostrarMenu();
                int opcion = LeerEntero("  Seleccione una opción (1-5): ", 1, 5);

                switch (opcion)
                {
                    case 1:
                        OpcionTriangulo();
                        break;
                    case 2:
                        OpcionCuadrado();
                        break;
                    case 3:
                        OpcionCirculo();
                        break;
                    case 4:
                        OpcionEdad();
                        break;
                    case 5:
                        continuar = false;
                        MostrarDespedida();
                        break;
                }
            }
        }

        // =========================================================
        //  FUNCIONES DE CÁLCULO (reciben parámetros y retornan)
        // =========================================================

        /// <summary>Calcula el área de un triángulo: (base × altura) / 2.</summary>
        static double CalcularAreaTriangulo(double baseTriangulo, double altura)
        {
            return (baseTriangulo * altura) / 2;
        }

        /// <summary>Calcula el área de un cuadrado: lado².</summary>
        static double CalcularAreaCuadrado(double lado)
        {
            return lado * lado;
        }

        /// <summary>Calcula el área de un círculo: π × radio².</summary>
        static double CalcularAreaCirculo(double radio)
        {
            return Math.PI * Math.Pow(radio, 2);
        }

        /// <summary>Recibe la edad y retorna un mensaje: mayor o menor de edad.</summary>
        static string VerificarMayoriaDeEdad(int edad)
        {
            if (edad >= MAYORIA_DE_EDAD)
            {
                return $"Con {edad} años, la persona es MAYOR de edad.";
            }
            else
            {
                int faltan = MAYORIA_DE_EDAD - edad;
                string detalle = faltan == 1 ? "le falta 1 año" : $"le faltan {faltan} años";
                return $"Con {edad} años, la persona es MENOR de edad ({detalle}).";
            }
        }

        // =========================================================
        //  PROCEDIMIENTOS DE CADA OPCIÓN DEL MENÚ
        // =========================================================

        static void OpcionTriangulo()
        {
            MostrarEncabezado("ÁREA DEL TRIÁNGULO", "Fórmula: (base × altura) / 2");
            double baseTriangulo = LeerNumeroPositivo("  Ingrese la base (cm): ");
            double altura = LeerNumeroPositivo("  Ingrese la altura (cm): ");

            double area = CalcularAreaTriangulo(baseTriangulo, altura);
            MostrarResultado($"El área del triángulo es {area:N2} cm²");
            Pausar();
        }

        static void OpcionCuadrado()
        {
            MostrarEncabezado("ÁREA DEL CUADRADO", "Fórmula: lado × lado");
            double lado = LeerNumeroPositivo("  Ingrese la medida del lado (cm): ");

            double area = CalcularAreaCuadrado(lado);
            MostrarResultado($"El área del cuadrado es {area:N2} cm²");
            Pausar();
        }

        static void OpcionCirculo()
        {
            MostrarEncabezado("ÁREA DEL CÍRCULO", "Fórmula: π × radio²");
            double radio = LeerNumeroPositivo("  Ingrese el radio (cm): ");

            double area = CalcularAreaCirculo(radio);
            MostrarResultado($"El área del círculo es {area:N2} cm²");
            Pausar();
        }

        static void OpcionEdad()
        {
            MostrarEncabezado("VERIFICADOR DE EDAD", $"Mayoría de edad: {MAYORIA_DE_EDAD} años");
            int edad = LeerEntero("  Ingrese la edad: ", 0, 120);

            string mensaje = VerificarMayoriaDeEdad(edad);
            MostrarResultado(mensaje);
            Pausar();
        }

        // =========================================================
        //  PROCEDIMIENTOS DE INTERFAZ (mostrar información)
        // =========================================================

        static void MostrarMenu()
        {
            LimpiarPantalla();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ╔══════════════════════════════════════════════╗");
            Console.WriteLine("  ║   CALCULADORA DE ÁREAS Y VERIFICADOR DE EDAD║");
            Console.WriteLine("  ╚══════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("    1. Calcular el área de un triángulo");
            Console.WriteLine("    2. Calcular el área de un cuadrado");
            Console.WriteLine("    3. Calcular el área de un círculo");
            Console.WriteLine("    4. Verificar si es mayor o menor de edad");
            Console.WriteLine("    5. Salir");
            Console.WriteLine();
        }

        static void MostrarEncabezado(string titulo, string detalle)
        {
            LimpiarPantalla();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"  ── {titulo} ──");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"  {detalle}");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void MostrarResultado(string mensaje)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  ✔ {mensaje}");
            Console.ResetColor();
        }

        static void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  ✖ {mensaje}");
            Console.ResetColor();
        }

        static void MostrarDespedida()
        {
            LimpiarPantalla();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ¡Gracias por usar la aplicación! Hasta pronto.");
            Console.ResetColor();
        }

        static void Pausar()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  Presione cualquier tecla para volver al menú...");
            Console.ResetColor();
            Console.ReadKey(true);
        }

        static void LimpiarPantalla()
        {
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }
        }

        // =========================================================
        //  FUNCIONES DE LECTURA Y VALIDACIÓN DE DATOS
        // =========================================================

        /// <summary>Lee un número decimal mayor que cero. Acepta punto o coma.</summary>
        static double LeerNumeroPositivo(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = (Console.ReadLine() ?? "").Trim().Replace(',', '.');

                if (double.TryParse(entrada, NumberStyles.Float, CultureInfo.InvariantCulture, out double valor) && valor > 0)
                {
                    return valor;
                }
                MostrarError("Valor no válido. Ingrese un número mayor que cero (ej.: 5 o 7.5).");
            }
        }

        /// <summary>Lee un número entero dentro de un rango.</summary>
        static int LeerEntero(string mensaje, int minimo, int maximo)
        {
            while (true)
            {
                Console.Write(mensaje);
                string entrada = (Console.ReadLine() ?? "").Trim();

                if (int.TryParse(entrada, out int valor) && valor >= minimo && valor <= maximo)
                {
                    return valor;
                }
                MostrarError($"Valor no válido. Ingrese un número entero entre {minimo} y {maximo}.");
            }
        }
    }
}
