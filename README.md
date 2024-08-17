


COMO COPILAR EL PROYECTO

To-Do List Application

Descripción:
Esta aplicación de consola en C# permite gestionar una lista de tareas. Los usuarios pueden agregar, listar, marcar tareas como completadas y eliminar tareas. La aplicación utiliza una lista estática para almacenar las tareas.

Requisitos
.NET Framework 4.8 
Un entorno de desarrollo compatible con C# (como Visual Studio)

Compilación y Ejecución
1. Clonar el Repositorio
Si aún no has clonado el repositorio, usa el siguiente comando:

git clone https://github.com/LizethRoman99/ToDoList.git


2. Abrir el Proyecto
Abre el archivo del proyecto en tu entorno de desarrollo. Si estás usando Visual Studio, abre el archivo 



4.Puedes ejecutar el proyecto directamente desde Visual Studio presionando F5 o haciendo clic en el botón de "Iniciar depuración".

Uso
Al ejecutar la aplicación, se te presentará un menú con las siguientes opciones:

1.Agregar tarea
2.Listar tareas
3.Marcar tarea como completada
4.Eliminar tarea
5.Salir
Selecciona una opción introduciendo el número correspondiente y presiona Enter.

Ejemplos de Entrada y Comportamiento
1Agregar Tarea:

Se te pedirá ingresar el nombre, descripción y fecha límite (opcional) de la tarea.
Nombre: No puede estar vacío.
Descripción: No puede estar vacía ni contener números.
Fecha límite: Debe estar en el formato yyyy-MM-dd o se guardara sin fecha.
2.Listar Tareas:

Se mostrará una lista de todas las tareas con su nombre, descripción, fecha límite y estado (Completada/Pendiente).
3.Marcar Tarea como Completada: se mostrara en verde si esta completada y en amarillo si esta pendiente

Se te pedirá seleccionar el número de la tarea que deseas marcar como completada.
Si la tarea ya está completada, se mostrará un mensaje de error.
4.Eliminar Tarea:

Se te pedirá seleccionar el número de la tarea que deseas eliminar.
La tarea seleccionada se eliminará de la lista.
5.Salir:

Saldrá de la aplicación.
Entradas Inválidas
Nombre de la tarea vacío: El programa mostrará un mensaje de error y pedirá que ingreses un nombre válido.
Fecha límite en formato incorrecto: El programa mostrará un mensaje de error si la fecha no está en el formato yyyy-MM-dd y pedirá que ingreses una fecha válida.
Notas
La lista de tareas se almacena en memoria mientras la aplicación está en ejecución. Las tareas no se guardan en un archivo o base de datos y se perderán cuando la aplicación se cierre.
