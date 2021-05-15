using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqHomework
{
    public static class LinqTask
    {
        static List<object> data = new List<object> {
                "Hello",
                new Article { Author = "Hilgendorf", Name = "Punitive law and criminal law doctrine.", Pages = 44 },
                new List<int> {45, 9, 8, 3},
                new string[] {"Hello inside array"},
                new Film { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                    new Actor { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                    new Actor { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                }},
                new Film { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                    new Actor { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                }},
                new Article { Author = "Basov", Name="Classification and content of restrictive administrative measures applied in the case of emergency", Pages = 35},
                "Leonardo DiCaprio"
            };

        public static void ActorsName()
        {
            foreach (var actorName in data.Where(x => x is Film).Cast<Film>().SelectMany(x => x.Actors.Select(x => x.Name + ", ")))
            {
                Console.Write(actorName);
            }
            Console.WriteLine("\n______________________");
        }
        public static void ActorsAugustBirthday()
        {
            Console.WriteLine(data.Where(x => x is Film).Cast<Film>().Select(x => x.Actors.Where(x => x.Birthdate.Month == 8)).Count());
            Console.WriteLine("______________________");
        }
        public static void OldestActorsNames()
        {
            foreach (var actorName in data.Where(x => x is Film).Cast<Film>().SelectMany(x => x.Actors).OrderBy(x => x.Birthdate).Take(2).Select(x => x.Name +" "))
            {
                Console.Write(actorName);
            }
            Console.WriteLine("\n______________________");
        }
        public static void ArticlsByAuthor()
        {
            foreach (var articles in data.Where(x => x is Article).Cast<Article>().Select(x => x.Author).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()))
            {
                Console.Write(articles);
            }
            Console.WriteLine("\n______________________");
        }
        public static void ArticlesAndFilms() 
        {
            foreach (var articles in data.Where(x => x is Article).Cast<Article>().Select(x => x.Author).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()))
            {
                Console.Write(articles);
            }
            Console.WriteLine();
            foreach (var films in data.Where(x => x is Film).Cast<Film>().Select(x => x.Author).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count()))
            {
                Console.Write(films);
            }
            Console.WriteLine("\n______________________");
        }


    }
}
