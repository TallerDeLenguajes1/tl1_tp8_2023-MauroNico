using System;
using System.Collections.Generic;
using System.IO;

class Tarea
{
    public int TareaID { get; set; }
    public string Descripcion { get; set; }
    public int Duracion { get; set; }

    public Tarea(int tareaID, string descripcion, int duracion)
    {
        TareaID = tareaID;
        Descripcion = descripcion;
        Duracion = duracion;
    }
}

class Empleado
{
    public List<Tarea> TareasPendientes { get; set; }
    public List<Tarea> TareasRealizadas { get; set; }

    public Empleado()
    {
        TareasPendientes = new List<Tarea>();
        TareasRealizadas = new List<Tarea>();
    }

    public void AgregarTareaPendiente(Tarea tarea)
    {
        TareasPendientes.Add(tarea);
    }

    public void MoverTareaPendienteARealizada(int tareaID)
    {
        Tarea tarea = TareasPendientes.Find(t => t.TareaID == tareaID);
        if (tarea != null)
        {
            TareasPendientes.Remove(tarea);
            TareasRealizadas.Add(tarea);
            Console.WriteLine("La tarea se ha movido de pendiente a realizada.");
        }
        else
        {
            Console.WriteLine("No se encontró una tarea con el ID especificado en las tareas pendientes.");
        }
    }

    public List<Tarea> BuscarTareasPendientesPorDescripcion(string descripcion)
    {
        return TareasPendientes.FindAll(t => t.Descripcion.Contains(descripcion));
    }

    public void GuardarSumarioHorasTrabajadas(string nombreArchivo)
    {
        int horasTrabajadas = 0;
        foreach (Tarea tarea in TareasRealizadas)
        {
            horasTrabajadas += tarea.Duracion;
        }

        using (StreamWriter writer = new StreamWriter(nombreArchivo, true))
        {
            writer.WriteLine($"Horas trabajadas: {horasTrabajadas}");
        }
    }
}

class Program
{
    static void Main()
    {
        Empleado empleado = new Empleado();

        
        Tarea tarea1 = new Tarea(1, "Completar informe", 60);
        Tarea tarea2 = new Tarea(2, "Enviar correo electrónico", 15);
        Tarea tarea3 = new Tarea(3, "Preparar presentación", 45);
        Tarea tarea4 = new Tarea(4, "Realizar llamada telefónica", 10);
        Tarea tarea5 = new Tarea(5, "Actualizar base de datos", 30);

        
        empleado.AgregarTareaPendiente(tarea1);
        empleado.AgregarTareaPendiente(tarea2);
        empleado.AgregarTareaPendiente(tarea3);
        empleado.AgregarTareaPendiente(tarea4);
        empleado.AgregarTareaPendiente(tarea5);

        
        int tareaIDMovida = 3; // ID de la tarea a mover
        empleado.MoverTareaPendienteARealizada(tareaIDMovida);

        
        string descripcionBusqueda = "correo";
        List<Tarea> tareasEncontradas = empleado.BuscarTareasPendientesPorDescripcion(descripcionBusqueda);
        Console.WriteLine($"Se encontraron {tareasEncontradas.Count} tareas pendientes que contienen '{descripcionBusqueda}' en su descripción.");

        
        string nombreArchivo = "sumario_horas_trabajadas.txt";
        empleado.GuardarSumarioHorasTrabajadas(nombreArchivo);

        Console.WriteLine("Se ha guardado el sumario de horas trabajadas en el archivo.");
    }
}