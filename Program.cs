using GestionDeTareas;
using EspacioCalculadora;

Console.WriteLine("\n------Ejercicio 21------\n");

int op;
string ingresado;
int cantidad;
int idTareaTransferir;
int control;
int idIngresado;
string palabraClave;
int contiene;

GestorDeTareas gestor = new GestorDeTareas();
List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();

do
{
    Console.WriteLine("\n\nQue operacion desea realizar?");
    Console.WriteLine("[1]. Agregar una nueva tarea a Pendientes");
    Console.WriteLine("[2]. Transferir tareas de la lista Pendientes a Realizadas");
    Console.WriteLine("[3]. Mostrar las listas");
    Console.WriteLine("[4]. Consultar tarea por id");
    Console.WriteLine("[5]. Consultar tarea por palabra clave");
    Console.WriteLine("[0]. Finalizar");
    Console.WriteLine("Seleccione una opcion: ");
    string operacion = Console.ReadLine();
    if (int.TryParse(operacion, out op) && 0<=op && op<=5)
    {
        switch (op)
            {
            case 1:
                do
                {
                    Console.WriteLine("Ingrese la cantidad de tareas que desea ingresar a su lista de pendientes\n");
                    ingresado = Console.ReadLine();
                } while (!int.TryParse(ingresado, out cantidad) || cantidad < 0);
                tareasPendientes = gestor.crearNTareas(cantidad);
                break;
            case 2:
                do
                {
                    do
                    {
                        Console.WriteLine("\nIngrese el ID de la tarea que desea transferir a la lista de tareas realizadas: ");
                        ingresado = Console.ReadLine();
                    } while (!int.TryParse(ingresado, out idTareaTransferir));
                    gestor.transferirTareasARealizadas(tareasPendientes, tareasRealizadas, idTareaTransferir);
                    Console.WriteLine("\nDesea seguir transfiriendo tareas?");
                    Console.WriteLine("[1].Si");
                    Console.WriteLine("[0]. No");
                    ingresado = Console.ReadLine();
                    if (!int.TryParse(ingresado, out control))
                    {
                        control = 0;
                    }
                } while (control != 0);
                break;
            case 3:
                Console.WriteLine("\nLista de pendientes:");
                foreach (Tarea tarea in tareasPendientes)
                {
                    Console.WriteLine($"---Tarea---");
                    Console.WriteLine($"ID: {tarea.ID}");
                    Console.WriteLine($"Descripcion: {tarea.Descripcion}");
                    Console.WriteLine($"Duracion: {tarea.Duracion}");
                }
                Console.WriteLine("\nLista de realizadas:");
                foreach (Tarea tarea in tareasRealizadas)
                {
                    Console.WriteLine($"---Tarea---");
                    Console.WriteLine($"ID: {tarea.ID}");
                    Console.WriteLine($"Descripcion: {tarea.Descripcion}");
                    Console.WriteLine($"Duracion: {tarea.Duracion}");
                }
                break;
            case 4:
                do
                {
                    Console.Write("\nIngrese el id de la tarea que desea buscar: ");
                    ingresado = Console.ReadLine();
                } while (!int.TryParse(ingresado, out idIngresado));
                contiene = 0;
                foreach (Tarea tarea in tareasPendientes)
                {
                    if (tarea.ID == idIngresado)
                    {
                        contiene = 1;
                        Console.WriteLine("\nLa tarea pertenece a la lista Pendientes");
                        Console.WriteLine($"---TAREA---");
                        Console.WriteLine($"ID: {tarea.ID}");
                        Console.WriteLine($"Descripcion: {tarea.Descripcion}");
                        Console.WriteLine($"Duracion: {tarea.Duracion}");
                        break;
                    }
                }
                foreach (Tarea tarea in tareasRealizadas)
                {
                    if (tarea.ID == idIngresado)
                    {
                        contiene = 1;
                        Console.WriteLine("\nLa tarea pertenece a la lista Realizadas");
                        Console.WriteLine($"---TAREA---");
                        Console.WriteLine($"ID: {tarea.ID}");
                        Console.WriteLine($"Descripcion: {tarea.Descripcion}");
                        Console.WriteLine($"Duracion: {tarea.Duracion}");
                        break;
                    }
                }
                if (contiene == 0)
                {
                    Console.WriteLine("No se encontro una tarea con esa palabra en la descripcion de ninguna de las listas");
                }
                break;
            case 5:
                Console.Write("\nIngrese la palabra clave que desea buscar: ");
                palabraClave = Console.ReadLine();
                contiene = 0;
                foreach (Tarea tarea in tareasPendientes)
                {
                    if (tarea.Descripcion.Contains(palabraClave.Trim()))
                    {
                        contiene = 1;
                        Console.WriteLine("\nLa tarea pertenece a la lista Pendientes");
                        Console.WriteLine($"---TAREA---");
                        Console.WriteLine($"ID: {tarea.ID}");
                        Console.WriteLine($"Descripcion: {tarea.Descripcion}");
                        Console.WriteLine($"Duracion: {tarea.Duracion}");
                        break;
                    }
                }
                foreach (Tarea tarea in tareasRealizadas)
                {
                    if (tarea.Descripcion.Contains(palabraClave.Trim()))
                    {
                        contiene = 1;
                        Console.WriteLine("\nLa tarea pertenece a la lista Realizadas");
                        Console.WriteLine($"---TAREA---");
                        Console.WriteLine($"ID: {tarea.ID}");
                        Console.WriteLine($"Descripcion: {tarea.Descripcion}");
                        Console.WriteLine($"Duracion: {tarea.Duracion}");
                        break;
                    }
                }
                if (contiene == 0)
                {
                    Console.WriteLine("No se encontro una tarea con esa palabra en la descripcion de ninguna de las listas");
                }
                break;
            default:
                break;
            }
        }
} while (op != 0);

Calculadora miCalculadora = new Calculadora();

Console.WriteLine("\n----------Ejercicio 2----------\n");
op=0;
control=0;
do
{
    Console.WriteLine($"Valor actual del operando = {miCalculadora.Resultado}\n");
    Console.WriteLine("Seleccione la operacion que desea realizar\n");
    Console.WriteLine("[1]. Suma\n");
    Console.WriteLine("[2]. Resta\n");
    Console.WriteLine("[3]. Multplicación\n");
    Console.WriteLine("[4]. Division\n");
    Console.WriteLine("[5]. Limpiar\n");
    Console.WriteLine("[6]. Ver historial\n");

    string operacion = Console.ReadLine();
    double num = 0;
    if (int.TryParse(operacion, out op) && 1<=op && op<=6)
    {
        if (op != 5 && op != 6)
        {
            string nro;
            do
            {
                Console.WriteLine("Ingrese un numero: \n");
                nro = Console.ReadLine();
            } while (!double.TryParse(nro, out num));            
        }
        switch (op)
        {
            case 1:
                miCalculadora.Sumar(num);
                Console.WriteLine($"\nEl resultado de la suma es {miCalculadora.Resultado}");
                break;
            case 2:
                miCalculadora.Restar(num);
                Console.WriteLine($"\nEl resultado de la resta es {miCalculadora.Resultado}");
                break;
            case 3:
                miCalculadora.Multiplicar(num);
                Console.WriteLine($"\nEl resultado de la multiplicacion es {miCalculadora.Resultado}");
                break;
            case 4:
                miCalculadora.Dividir(num);
                if (num != 0)
                {
                    Console.WriteLine($"\nEl resultado de la division es {miCalculadora.Resultado}");
                }
                break;
            case 5:
                miCalculadora.Limpiar();
                break;
            case 6:
                int k = 1;
                foreach (Calculadora.Operacion operacion1 in miCalculadora.Historial)
                {
                    Console.WriteLine($"\n---- OPERACION {k}----");
                    Console.WriteLine($"\nTipo de operacion realizado: {operacion1.OperacionRealizada}");
                    Console.WriteLine($"\nDato de entrada: {operacion1.ResultadoAnterior}");
                    Console.WriteLine($"\nResultado: {operacion1.NuevoValor}");
                    k++;
                }
                break;

        }
    } 
    Console.WriteLine("\nDesea seguir operando?\n");
    Console.WriteLine("[1]. Si\n");
    Console.WriteLine("[0]. No\n");
    string controla = Console.ReadLine();
    if (!int.TryParse(controla, out control))
    {
        control = 1;
    }
} while (control != 0);
Console.WriteLine("\nSe ha seleccionado [0]. Saliendo del programa.\n");

