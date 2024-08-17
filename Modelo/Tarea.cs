using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoListAplication.Modelo
{
    public class Tarea
    {
        // Atributos de la clase
        private string Nombre { get; set; }
        private string Descripcion { get; set; }
        private DateTime? FechaLimite { get; set; }
        private bool EstaCompletada { get; set; }

        // Lista estática para almacenar las tareas
        private static List<Tarea> tareas = new List<Tarea>();

        // Constructor de la clase
        private Tarea(string nombre, string descripcion, DateTime? fechaLimite = null)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            FechaLimite = fechaLimite;
            EstaCompletada = false; // Por defecto, la tarea no está completada al ser creada
        }

        // Método para marcar la tarea como completada
        private void MarcarComoCompletada()
        {
            EstaCompletada = true;
        }

        // Método para imprimir la información de la tarea
        private string ObtenerInformacion()
        {
            string fecha = FechaLimite.HasValue ? $"Fecha límite: {FechaLimite.Value.ToString("yyyy-MM-dd")}" : "Fecha límite: Tarea sin fecha";
            string estado = EstaCompletada ? "Completada" : "Pendiente";
            string estadoCuadro = CuadroEstado(estado, EstaCompletada ? ConsoleColor.Green : ConsoleColor.Yellow);

            return $"Nombre: {Nombre}\nDescripción: {Descripcion}\n{fecha}\n{estadoCuadro}";
        }

        // Método para imprimir el estado de la tarea dentro de un cuadro
        private static string CuadroEstado(string estado, ConsoleColor color)
        {
            string[] lineas = new string[]
            {
                "+-----------------+",
                $"| {estado,-15} |",
                "+-----------------+"
            };

            // Guardar el color original
            var colorOriginal = Console.ForegroundColor;
            Console.ForegroundColor = color;

            // Formatear el cuadro y restablecer el color
            string resultado = string.Join("\n", lineas);
            Console.ForegroundColor = colorOriginal;

            return resultado;
        }

        // Métodos públicos para manejar tareas
        public static void AgregarTarea()
        {
            string nombre;
            string descripcion;

            while (true)
            {
                Console.Write("Nombre de la tarea: ");
                nombre = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    break;
                }

                MostrarMensajeEnRojo("El nombre no puede estar vacío.");
            }
            //bucle para validar la entrada de datos validos
            while (true)
            {
                Console.Write("Descripción de la tarea: ");
                descripcion = Console.ReadLine();
                // Validar que el campo solo contenga letras y no números
                if (!string.IsNullOrWhiteSpace(descripcion))
                {
                    break;
                }

                MostrarMensajeEnRojo("La descripción no puede estar vacía ");
            }

            DateTime? fechaLimite = null;
            //bucle para validar el atributo de la fecha
            while (true)
            {
                Console.Write("Fecha límite (opcional, formato: yyyy-MM-dd): ");
                string fechaLimiteInput = Console.ReadLine();

                if (string.IsNullOrEmpty(fechaLimiteInput))
                {
                    // No se ingresó fecha, se mantiene como null
                    break;
                }

                if (DateTime.TryParse(fechaLimiteInput, out DateTime parsedDate))
                {
                    fechaLimite = parsedDate;
                    break;
                }
                else
                {
                    MostrarMensajeEnRojo("Fecha inválida. Por favor, ingrese una fecha en el formato correcto (yyyy-MM-dd).");
                }
            }
            //Se esta creando una nueva instancia para una nueva tarea

            Tarea nuevaTarea = new Tarea(nombre, descripcion, fechaLimite);
            tareas.Add(nuevaTarea);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Tarea agregada exitosamente.");
            Console.ResetColor();
        }

        public static void ListarTareas()
        {
            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas registradas.");
                return;
            }

            Console.WriteLine("\nListado de Tareas:");
            for (int i = 0; i < tareas.Count; i++)
            {
                if (tareas[i].EstaCompletada)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                Console.WriteLine($"Tarea {i + 1}:");
                Console.WriteLine(tareas[i].ObtenerInformacion());
                Console.WriteLine("---------------------------------");
            }

            Console.ResetColor();
        }

        public static void MarcarTareaComoCompletada()
        {
            ListarTareas();

            Console.Write("Selecciona el número de la tarea que deseas marcar como completada: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= tareas.Count)
            {
                if (tareas[indice - 1].EstaCompletada)
                {
                    MostrarMensajeEnRojo("Esta tarea ya está completada.");
                }
                else
                {
                    tareas[indice - 1].MarcarComoCompletada();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Tarea marcada como completada.");
                    Console.ResetColor();
                }
            }
            else
            {
                MostrarMensajeEnRojo("Número de tarea inválido.");
            }
        }

        public static void EliminarTarea()
        {
            ListarTareas();

            Console.Write("Selecciona el número de la tarea que deseas eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= tareas.Count)
            {
                tareas.RemoveAt(indice - 1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Tarea eliminada exitosamente.");
                Console.ResetColor();
            }
            else
            {
                MostrarMensajeEnRojo("Número de tarea inválido.");
            }
        }

        public static void MostrarMensajeEnRojo(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }
    }
}
