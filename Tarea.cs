namespace GestionDeTareas
{
    class Tarea
    {
        private int id; //Numerado en ciclo iterativo
        private string descripcion; //
        private int duracion; // entre 10 – 100
        private Estados estado;
        public int ID { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Duracion { get => duracion; set =>duracion = value; }
        public Estados Estado { get => estado; set =>estado = value; }
        
        public Tarea(int id, string descripcion, int duracion, Estados estado)
        {
            ID = id;
            Descripcion = descripcion;
            Duracion = duracion;
            Estado = estado;
        }
    };
    class GestorDeTareas
    {
        public List<Tarea> crearNTareas(int n)
        {
            int id = 1000;
            var semilla = Environment.TickCount;
            var random = new Random(semilla);
            List<Tarea> tareas = new List<Tarea>();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\nIngrese la descripcion de la tarea: ");
                string descripcion = Console.ReadLine();
                int duracion = random.Next(10, 101);
                Tarea tarea = new Tarea(id, descripcion, duracion, Estados.Pendiente);
                tareas.Add(tarea);
                id++;
            }
            return tareas;
        }

        public void transferirTareasARealizadas(List<Tarea> pendientes, List<Tarea> realizadas, int id)
        {
            int i = 0;
            while (i < pendientes.Count && pendientes[i].ID != id)i++;
            if (pendientes[i].ID == id)
            {
                Tarea tareaP = pendientes[i];
                tareaP.Estado = Estados.Realizada;
                realizadas.Add(tareaP);
                pendientes.Remove(tareaP);
            } else
            {
                Console.WriteLine("\nNo existe una tarea con ese ID");
            }
        }
    }
}
