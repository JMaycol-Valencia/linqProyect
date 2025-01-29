using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace linqProyect
{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();

        public void Linea()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
        }

        public LinqQueries()
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
            ;
        }

        public IEnumerable<Book> TodaLaColeccion()
        {
            return librosCollection;
        }

        public IEnumerable<Book> LibrosDespuesDelDosMil()
        {
            //EXTENSION METHOD
            //return librosCollection.Where(p => p.PublishedDate.Year > 2000 );

            //QUERY EXPRESION
            return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
        }

        public IEnumerable<Book> LibrosConMasde250Pag()
        {
            //EXTENSION METHODS
            //return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

            //QUERY EXPRESION
            return from l
                    in librosCollection
                    where l.PageCount > 250 && l.Title.Contains("in Action")
                    select l;
        }

        public bool TodoLosLibrosTienenStatus()
        {
            //EXTENSION METHODS
            return librosCollection.All(p => p.Status != string.Empty);

            //QUERY EXPRESION
            //return from l in librosCollection all
        }

        public bool AlgunLibroFuePublicadoEn()
        {
            //EXTENSION METHODS
            return librosCollection.Any(p => p.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book> LibrosDePython()
        {
            return librosCollection.Where(p => p.Categories.Contains("Python"));
        }

        public IEnumerable<Book> OrdenJava()
        {
            return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
        }

        public IEnumerable<Book> LibrosDescendentes()
        {
            return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
        }

        public IEnumerable<Book> TresPrimeros()
        {
            return librosCollection
            .Where(p => p.Categories.Contains("Java"))
            .OrderByDescending(p => p.PublishedDate)        //PODEMOS USAR OrderBy para alterar el orden
            .Take(3);
        }

        public IEnumerable<Book> MasdeCUtrocientas()
        {
            return librosCollection
            .Where(p => p.PageCount > 400)
            .Take(4)
            .Skip(2);
        }

        public IEnumerable<Book> TresPrimerosLibros()
        {
            return librosCollection.Take(3)
            .Select(p => new Book() {Title = p.Title,PageCount = p.PageCount});
        }

        public long CantidadLibros()
        {
            //public int si se usa Count
            //TRES FORMAS DE IMPLEMETAR count y longcount

            return librosCollection.LongCount(p => p.PageCount >= 200 && p.PageCount <= 500);
            //return librosCollection.Where(p => p.PageCount >= 200 && p.PageCount <= 500).LongCount();
            //return librosCollection.Where(p => p.PageCount >= 200 && p.PageCount <= 500).Count();
        }

        public DateTime FechaMasAntigua()
        {
            return librosCollection.Min(p => p.PublishedDate);
        }

        public int LibroMasLargo()
        {
            return librosCollection.Max(p => p.PageCount);
        }

        public Book LibroConMenosPaginas()
        {
            return librosCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
        }

        public Book LibroConFechaMasReciente()
        {
            return librosCollection.MaxBy(p => p.PublishedDate);
        }
    }
}