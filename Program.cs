using System;
using System.Collections.Generic;
using System.IO;


List<Tarea> pendientes = new List<Tarea>();
List<Tarea> realizadas = new List<Tarea>();
Random rnd = new Random();
int N;
Console.WriteLine("Ingrese el numero de tareas a realizar\n");
N = Convert.ToInt32(Console.ReadLine());
string penal;
for(int i = 0;i<N;i++){
    Tarea tarea = new Tarea();
    tarea.TareaID = i+1;
    Console.WriteLine($"Ingrese la descripcion de la tarea {tarea.TareaID}");
    penal = Console.ReadLine();
    tarea.Descripcion = penal;
    Console.WriteLine($"Ingrese la duracion de la tarea {tarea.TareaID}");
    tarea.duracion = Convert.ToInt32(Console.ReadLine());
    pendientes.Add(tarea);
}
Console.WriteLine("PENDIENTES");
foreach(Tarea tarea in pendientes)
{
    Console.WriteLine($"TareaID= {tarea.TareaID}");
    Console.WriteLine($"Descripcion: {tarea.Descripcion}");
    Console.WriteLine($"Duracion: {tarea.duracion}\n");
}
Console.WriteLine("Que item desea mover?");
N = Convert.ToInt32(Console.ReadLine());
Tarea item = pendientes[(N-1)];
realizadas.Add(item);
pendientes.Remove(item);

Console.WriteLine("\n\nPENDIENTES");
foreach(Tarea tarea in pendientes)
{
    Console.WriteLine($"TareaID= {tarea.TareaID}");
    Console.WriteLine($"Descripcion: {tarea.Descripcion}");
    Console.WriteLine($"Duracion: {tarea.duracion}\n");
}
Console.WriteLine("\n\nREALIZADAS");
foreach(Tarea tarea in realizadas)
{
    Console.WriteLine($"TareaID= {tarea.TareaID}");
    Console.WriteLine($"Descripcion: {tarea.Descripcion}");
    Console.WriteLine($"Duracion: {tarea.duracion}\n");
}
string busca;
Console.WriteLine("\n\nIngrese la descripcion de la tarea a buscar");
busca = Console.ReadLine();
foreach(Tarea tarea in pendientes)
{
    if(tarea.Descripcion == busca)
    {
        Console.WriteLine($"TareaID= {tarea.TareaID}");
        Console.WriteLine($"Descripcion: {tarea.Descripcion}");
        Console.WriteLine($"Duracion: {tarea.duracion}\n");
    }
}
int horasTrabajadas = 0;;
foreach(Tarea tarea in pendientes){
    horasTrabajadas += tarea.duracion;
}
string nombreArchivo = "horas_trabajadas.txt";
StreamWriter archivo = new StreamWriter(nombreArchivo);

archivo.WriteLine("Sumario de horas trabajadas:");
archivo.WriteLine(horasTrabajadas);

public class Tarea
{
    public int TareaID;
    public string Descripcion;
    public int duracion;
}
