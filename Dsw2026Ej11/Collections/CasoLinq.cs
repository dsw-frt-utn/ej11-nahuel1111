using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

/*
 * Para cada punto crear un método que permita:
 * 1. Obtener el primer libro (GetPrimero)
 * 2. Obtener el último libro (GetUltimo)
 * 3. Obtener la suma de precios (GetTotalPrecios)
 * 4. Obtener el promedio de precios (GetPromedioPrecios)
 * 5. Obtener la lista de libros con Id mayor a 15 (GetListById)
 * 6. Obtener una lista de cada libro con su título y precio en formato moneda (GetLibros) (debe retornar una lista de string)
 * 7. Obtener el libro con el precio más alto (GetMayorPrecio)
 * 8. Obtener el libro con el precio más bajo (GetMenorPrecio)
 * 9. Obtener los libros cuyo precio sea mayor al promedio (GetMayorPromedio)
 * 10. Obtener los libros ordenados por título de forma descendente
 * En todos los casos debe aplicarse LINQ
 */
public class CasoLinq
{
    public Libro GetPrimero()
    {
        return Libro.CrearLista().FirstOrDefault();
    }
    public Libro GetUltimo()
    {
        return Libro.CrearLista().LastOrDefault();
    }
    public decimal GetTotalPrecios()
    {
        return Libro.CrearLista().Sum(l => l.Precio);
    }
    public decimal GetPromedioPrecios()
    {
        List<Libro> libros = Libro.CrearLista();
        return libros.Any() ? libros.Average(l => l.Precio) : 0;
    }
    public List<Libro> GetListById()
    {
        return Libro.CrearLista().Where(l => l.Id > 15).ToList();
    }
    public List<string> GetLibros()
    {
        return Libro.CrearLista().Select(l => $"{l.Titulo}- {l.Precio:c}").ToList();
    }
    public Libro GetMayorPrecio()
    {
        return Libro.CrearLista().MaxBy(l => l.Precio);
    }
    public Libro GetMenorPrecio()
    {
        return Libro.CrearLista().MinBy(l => l.Precio);
    }

    public List<Libro> GetMayorPromedio()
    {
        List<Libro> libros = Libro.CrearLista();
        if (!libros.Any()) return new List<Libro>();
        decimal promedio = libros.Average(l => l.Precio);
        return libros.Where(l => l.Precio > promedio).ToList();
    }

    public List<Libro> GetOrden()
    {
        return Libro.CrearLista().OrderByDescending(l => l.Titulo).ToList();
    }

}
