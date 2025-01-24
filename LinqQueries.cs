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
    }
}