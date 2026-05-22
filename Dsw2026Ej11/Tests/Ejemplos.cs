using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Tests;


internal class Ejemplos
{
    //Agregar 3 alumnos a la lista
    //Listar por consola los alumnos
    //Buscar por nombre un alumno que exista y mostrar por consola
    //Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
    //Eliminar un alumno y listar por consola los alumnos
    //Eliminar el primer elemento de la lista y listar por consola los alumnos
    public static void EjemploList()                                                  
    {
        Console.WriteLine("=== EJEMPLO LIST ===");
        CasoList casoList = new CasoList();
        Alumno a1 = new Alumno(1, "Jose", 8);
        Alumno a2 = new Alumno(2, "Kiara", 9);
        Alumno a3 = new Alumno(3, "Tadeo", 3);
        casoList.AgregarAlumno(a1);
        casoList.AgregarAlumno(a2);
        casoList.AgregarAlumno(a3);
        Console.WriteLine("\n--- Lista Inicial ---");

        foreach (var alumno in casoList.ObtenerAlumnos())
        {
            Console.WriteLine(alumno.ToString());
        }

        Console.WriteLine("\n--- Buscando alumno existente (Kiara) ---");
        Alumno existe = casoList.BuscarPorNombre("Kiara");
        if (existe != null)
        {
            Console.WriteLine($"Encontrado: {existe}");
        }
        else
        {
            Console.WriteLine($"No encontrado");
        }
        // 4. Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
        Console.WriteLine("\n--- Buscando alumno inexistente (Carlos) ---");
        Alumno encontradoNoExiste = casoList.BuscarPorNombre("Carlos");
        if (encontradoNoExiste != null)
            Console.WriteLine($"Encontrado: {encontradoNoExiste}");
        else
            Console.WriteLine("No existe");

        // 5. Eliminar un alumno y listar por consola los alumnos
        Console.WriteLine("\n--- Eliminando a Tadeo de la lista ---");
        casoList.EliminarAlumno(a3);
        foreach (var alumno in casoList.ObtenerAlumnos())
        {
            Console.WriteLine(alumno.ToString());
        }

        // 6. Eliminar el primer elemento de la lista y listar por consola los alumnos
        Console.WriteLine("\n--- Eliminando el primer elemento (índice 0) ---");
        casoList.EliminarPorPosicion(0);
        foreach (var alumno in casoList.ObtenerAlumnos())
        {
            Console.WriteLine(alumno.ToString());
        }
    }

    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {
        Console.WriteLine("=== EJEMPLO DICTIONARY ===");
        CasoDictionary casoDict = new CasoDictionary();

        // 1. Agregar 3 alumnos al diccionario
        Alumno a1 = new Alumno(10, "Martina", 7.5);
        Alumno a2 = new Alumno(20, "Joaquín", 8.0);
        Alumno a3 = new Alumno(30, "Valentina", 9.5);
        casoDict.AgregarAlumno(a1);
        casoDict.AgregarAlumno(a2);
        casoDict.AgregarAlumno(a3);

        // 2. Listar por consola los alumnos
        Console.WriteLine("\n--- Alumnos en el Diccionario ---");
        foreach (KeyValuePair<int, Alumno> kvp in casoDict.ListaDiccionario())
        {
            Console.WriteLine($"Clave: {kvp.Key} -> {kvp.Value}");
        }

        // 3. Buscar un alumno por clave y mostrar por consola
        Console.WriteLine("\n--- Buscando por clave existente (20) ---");
        Alumno encontradoExiste = casoDict.BuscarAlumno(20);
        if (encontradoExiste != null)
            Console.WriteLine($"Encontrado: {encontradoExiste}");
        else
            Console.WriteLine("No existe");

        // 4. Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
        Console.WriteLine("\n--- Buscando por clave inexistente (99) ---");
        Alumno encontradoNoExiste = casoDict.BuscarAlumno(99);
        if (encontradoNoExiste != null)
            Console.WriteLine($"Encontrado: {encontradoNoExiste}");
        else
            Console.WriteLine("No existe");

        // 5. Eliminar un alumno por clave y listar por consola los alumnos
        Console.WriteLine("\n--- Eliminando alumno con clave 10 ---");
        casoDict.ElimarAlumno(10);
        foreach (KeyValuePair<int, Alumno> kvp in casoDict.ListaDiccionario())
        {
            Console.WriteLine($"Clave: {kvp.Key} -> {kvp.Value}");
        }
    }

    //Realizar una llamada a cada método definido en CasoLinq y mostar por consola según corresponda
    public static void EjemploLinq()
    {
        Console.WriteLine("=== EJEMPLO LINQ ===");
        CasoLinq casoLinq = new CasoLinq();   // 1. GetPrimero
        Libro primero = casoLinq.GetPrimero();
        Console.WriteLine($"1. Primer libro: {primero?.Titulo ?? "N/A"}");



        // 2. GetUltimo
        Libro ultimo = casoLinq.GetUltimo();
        Console.WriteLine($"2. Último libro: {ultimo?.Titulo ?? "N/A"}");

        // 3. GetTotalPrecios
        decimal total = casoLinq.GetTotalPrecios();
        Console.WriteLine($"3. Total de precios: {total:C}");

        // 4. GetPromedioPrecios
        decimal promedio = casoLinq.GetPromedioPrecios();
        Console.WriteLine($"4. Promedio de precios: {promedio:C}");

        // 5. GetListById (Mayores a 15)
        Console.WriteLine("\n5. Libros con Id > 15:");
        foreach (var libro in casoLinq.GetListById())
        {
            Console.WriteLine($"   - Id: {libro.Id}, Título: {libro.Titulo}");
        }

        // 6. GetLibros (Formato moneda)
        Console.WriteLine("\n6. Lista de libros formateada:");
        foreach (var strLibro in casoLinq.GetLibros())
        {
            Console.WriteLine($"   - {strLibro}");
        }

        // 7. GetMayorPrecio
        Libro masCaro = casoLinq.GetMayorPrecio();
        Console.WriteLine($"\n7. Libro más caro: {masCaro?.Titulo} ({masCaro?.Precio:C})");

        // 8. GetMenorPrecio
        Libro masBarato = casoLinq.GetMenorPrecio();
        Console.WriteLine($"8. Libro más barato: {masBarato?.Titulo} ({masBarato?.Precio:C})");

        // 9. GetMayorPromedio
        Console.WriteLine($"\n9. Libros con precio mayor al promedio ({promedio:C}):");
        foreach (var libro in casoLinq.GetMayorPromedio())
        {
            Console.WriteLine($"   - {libro.Titulo}: {libro.Precio:C}");
        }

        // 10. Ordenados por título de forma descendente
        Console.WriteLine("\n10. Libros ordenados por título desc:");
        foreach (var libro in casoLinq.GetOrden())
        {
            Console.WriteLine($"   - {libro.Titulo}");
        }
    }
}
