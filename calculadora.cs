namespace EspacioCalculadora{
    public enum TipoOperacion
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        Limpiar
    }
    class Calculadora{
        private List<Operacion>historial;
        public List<Operacion> Historial{get=>historial;set => historial = value;}
        private double dato;
        public void Sumar(double termino){
            double ant = dato;
            dato = dato + termino;
            Operacion op = new Operacion(ant, dato, TipoOperacion.Suma);
            if(Historial == null)
            {
                Historial = new List<Operacion>();

            }
            Historial.Add(op);
        }

        public void Restar(double termino){
            double ant = dato;
            dato = dato - termino;
            Operacion op = new Operacion(ant, dato, TipoOperacion.Resta);
            if(Historial == null)
            {
                Historial = new List<Operacion>();

            }
            Historial.Add(op);
        }

        public void Multiplicar(double termino){
            double ant = dato;
            dato = dato * termino;
            Operacion op = new Operacion(ant, dato, TipoOperacion.Multiplicacion);
            if(Historial == null)
            {
                Historial = new List<Operacion>();

            }
            Historial.Add(op);
        }
    
        public void Dividir(double termino){
            if (termino != 0)
            {
                double ant = dato;
                dato = dato / termino;
                Operacion op = new Operacion(ant, dato, TipoOperacion.Division);
                if(Historial == null)
                {
                    Historial = new List<Operacion>();

                }
                Historial.Add(op);
            } else
            {
                Console.WriteLine("ERROR. Divisor igual a cero");
            }        
        }
        public void Limpiar(){
            double ant = dato;
            dato = 0;
            Operacion op = new Operacion(ant, dato, TipoOperacion.Limpiar);
            if(Historial == null)
            {
                Historial = new List<Operacion>();

            }
            Historial.Add(op);
        }

        public class Operacion
        {
            private double resultadoAnterior;
            private double nuevoValor;
            private TipoOperacion operacion;
            public double ResultadoAnterior{get => resultadoAnterior; set => resultadoAnterior = value;}  
            public double NuevoValor{get => nuevoValor; set => nuevoValor = value;}
            public TipoOperacion OperacionRealizada { get => operacion; set => operacion = value; }

            public Operacion(double anterior, double resultadoNuevo, TipoOperacion operacion)
            {
                ResultadoAnterior = anterior;
                NuevoValor = resultadoNuevo;
                OperacionRealizada = operacion;
            }
        }

        public double Resultado{get=>dato;}
    }
}