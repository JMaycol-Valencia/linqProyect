// See https://aka.ms/new-console-template for more information
using linqProyect;

Console.WriteLine("Hello, World!");

//Proyecto

LinqQueries queries = new LinqQueries();

//METODO TODOS LOS LIBROS
ImprimirValores(queries.TodaLaColeccion());

//METODO LIBROS MAYORES AL AÑO 2000
ImprimirValores(queries.LibrosDespuesDelDosMil());

//METODO PARA LIBROS CON MAS DE 250 PAGINAS
ImprimirValores(queries.LibrosConMasde250Pag());

//METODO PARA COMPROBAR UNA CARACTERISTICA
ImprimirValores(queries.LibrosDePython());

queries.Linea();
Console.WriteLine($"Algun libro no tiene status = {queries.TodoLosLibrosTienenStatus()}");
Console.WriteLine($"Algun libro fue publicado en 2005 = {queries.AlgunLibroFuePublicadoEn()}");

void ImprimirValores(IEnumerable<Book> listLibros)
{   queries.Linea();
    Console.WriteLine("{0,-70} {1,7} {2, 11}\n","Titulo","N. Paginas", "Fecha Publicacion"); 
    foreach(var item in listLibros)
    {
        Console.WriteLine("{0,-70} {1,7} {2, 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}