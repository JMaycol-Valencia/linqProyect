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

//METODOS DE ORDENAMIENTO
ImprimirValores(queries.OrdenJava());
ImprimirValores(queries.LibrosDescendentes());

//Take y Skip
ImprimirValores(queries.TresPrimeros());
ImprimirValores(queries.MasdeCUtrocientas());

//SELECT
ImprimirValores(queries.TresPrimerosLibros());

//COUNT y LONGCOUNT
Console.WriteLine($"Se tiene lasiguiente cantidad de libros es: {queries.CantidadLibros()}");

//MIN MAX
queries.Linea();
Console.WriteLine($"La fecha del libro con la fecha mas antigua es : {queries.FechaMasAntigua()}");
Console.WriteLine($"El numero de paginas del libro con mas paginas es : {queries.LibroMasLargo()}");

//MINBY MAXBY
var bookMenor = queries.LibroConMenosPaginas();
Console.WriteLine($"El libro con menos paginas que cero es : {bookMenor.Title}");

var bookMayor = queries.LibroConFechaMasReciente();
Console.WriteLine($"El libro con la fecha mas reciente es : {bookMayor.Title} {bookMayor.PublishedDate.ToShortDateString()}");

//SUM Y AGGREGATE
queries.Linea();
Console.WriteLine($"La suma de las paginas con mas de 0 y menos de 500 es  : {queries.SumaDePaginas()}");
Console.WriteLine($"Libros despues del 2015 son : {queries.LibroDespuesDel2015()}");

//AVERAGE
queries.Linea();
Console.WriteLine($"Este es el promedio de caracteres en los titulos de nuestros libros : {queries.PromedioLibros()}");

//GROUPBY
ImprimirGrupo(queries.LibrosAgrupados());

//LOOKUP
var diccionario = queries.DiccionarioPorLetra();
ImprimirDiccionario(diccionario, 'S');

//JOIN
ImprimirValores(queries.LibrosJoin());
Console.WriteLine("nose");

queries.Linea();
Console.WriteLine($"Algun libro no tiene status = {queries.TodoLosLibrosTienenStatus()}");
Console.WriteLine($"Algun libro fue publicado en 2005 = {queries.AlgunLibroFuePublicadoEn()}");

void ImprimirValores(IEnumerable<Book> listLibros)
{
    queries.Linea();
    Console.WriteLine("{0,-70} {1,7} {2, 11}\n", "Titulo", "N. Paginas", "Fecha Publicacion");
    foreach (var item in listLibros)
    {
        Console.WriteLine("{0,-70} {1,7} {2, 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> listdeLibros)
{
    queries.Linea();
    foreach (var grupo in listdeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo {grupo.Key}");
        Console.WriteLine("{0,-70} {1,7} {2, 11}\n", "Titulo", "N. Paginas", "Fecha Publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0,-70} {1,7} {2, 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }
}

void ImprimirDiccionario(ILookup<char, Book> listdeLibros, char letter)
{
    queries.Linea();
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in listdeLibros[letter])
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
    }

}