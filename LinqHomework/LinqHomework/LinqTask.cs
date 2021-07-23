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
            foreach (var actorName in data.OfType<Film>().SelectMany(x => x.Actors.Select(x => x.Name + ", ")).Distinct())
            {
                Console.Write(actorName);
            }
            Console.WriteLine("\n______________________");
        }
        public static void ActorsAugustBirthday()
        {
            Console.WriteLine(data.OfType<Film>().Select(x => x.Actors.Where(x => x.Birthdate.Month == 8)).Count());
            Console.WriteLine("______________________");
        }
        public static void OldestActorsNames()
        {
            foreach (var actorName in data.OfType<Film>().SelectMany(x => x.Actors).OrderBy(x => x.Birthdate).Take(2).Select(x => x.Name + " "))
            {
                Console.Write(actorName);
            }
            Console.WriteLine("\n______________________");
        }
        public static void ArticlsByAuthor()
        {
            foreach (var articles in data.OfType<Article>().GroupBy(x => x.Author).ToDictionary(x => x.Key, x => x.Count()))
            {
                Console.Write(articles);
            }
            Console.WriteLine("\n______________________");
        }
        public static void ArticlesAndFilms()
        {
            foreach (var articles in data.OfType<Article>().GroupBy(x => x.Author).ToDictionary(x => x.Key, x => x.Count()))
            {
                Console.Write(articles);
            }
            Console.WriteLine();
            foreach (var films in data.OfType<Film>().GroupBy(x => x.Author).ToDictionary(x => x.Key, x => x.Count()))
            {
                Console.Write(films);
            }
            Console.WriteLine("\n______________________");
        }
        public static void ActorsNamesDiffLetters()
        {
            foreach (var artor in data.OfType<Film>().SelectMany(x => x.Actors.GroupBy(x => x.Name)
            .ToDictionary(x => x.Key, x => x.Key.Distinct().Count())).Distinct())
            {
                Console.Write(artor);
            }
            Console.WriteLine("\n______________________");

        }
        public static void SortedArticls()
        {
            int i = 0;
            foreach (var article in data.OfType<Article>().OrderBy(x => x.Author).ThenBy(x => x.Pages).Select(x => $"{++i} - {x.Name}\n"))
            {
                Console.Write(article);
            }
            Console.WriteLine("\n______________________");
        }
        public static void ActorFilms()
        {
            var actorsAndFilms = data.OfType<Film>().SelectMany(x => x.Actors.Select(name => name.Name)).Distinct().GroupBy(g => g)
                .Select(actor => new
                {
                    Actor = actor.Key,
                    Films = string.Join(", ", data.OfType<Film>().Where(x => x.Actors.Any(x => x.Name == actor.Key))
                    .Select(x => new
                    {
                        x.Name
                    }))
                }).ToDictionary(x => x.Actor, x => x.Films);

            foreach (var item in actorsAndFilms)
            {
                Console.Write(item);
                Console.WriteLine();
            }
            Console.WriteLine("\n______________________");
        }
        public static void SumOfPages()
        {
            Console.WriteLine(data.OfType<Article>().Sum(x => x.Pages));
            Console.WriteLine(data.OfType<List<int>>().Sum(x => x.Sum()));
            Console.WriteLine("\n______________________");
        }
        public static void DictionaryOfAuthors()
        {
            var authorsAndArticles = data.OfType<Article>().Select(x => x.Author).Distinct().GroupBy(g => g)
                   .Select(author => new
                   {
                       Author = author.Key,
                       Articles = string.Join(", ", data.OfType<Article>().Where(x => x.Author == author.Key)
                       .Select(x => new
                       {
                           ArticleName = x.Name
                       }))
                   }).ToDictionary(x => x.Author, x => x.Articles);
            foreach (var item in authorsAndArticles)
            {
                Console.Write(item);
                Console.WriteLine();
            }
        }

    }
}
