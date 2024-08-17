using System;
using System.Linq;
using ToDoListAplication.Modelo;

namespace ToDoListAplication
{
    class Program
    {
        static void Main(string[] args)
        //Menu de opciones para el usuario el bucle es para que el usuario decida en que momento quiere salir del menú
        {
            while (true)
            {
                Console.WriteLine("LISTA DE TAREAS");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Agregar tarea");
                Console.WriteLine("2. Listar tareas");
                Console.WriteLine("3. Marcar tarea como completada");
                Console.WriteLine("4. Eliminar tarea");
                Console.WriteLine("5. Salir");
                Console.Write("Opción: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Tarea.AgregarTarea();
                        break;
                    case "2":
                        Tarea.ListarTareas();
                        break;
                    case "3":
                        Tarea.MarcarTareaComoCompletada();
                        break;
                    case "4":
                        Tarea.EliminarTarea();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                        break;
                }
            }
        }
    }
}


