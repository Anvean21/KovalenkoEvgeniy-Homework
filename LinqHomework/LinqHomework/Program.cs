using System;
using System.Collections.Generic;

namespace LinqHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinqMethods.From1To50();
            //LinqMethods.ThreeDivided();
            //LinqMethods.LinqRepeat();
            //LinqMethods.WordsContains();
            //LinqMethods.LetterCount();
            //LinqMethods.IsInString();
            //LinqMethods.MaxLenghtString();
            //LinqMethods.AverageLenghtString();
            //LinqMethods.MinLenght();
            //LinqMethods.StartwithA();
            //LinqMethods.LastWord();
            Console.WriteLine("\n____________________________NEXT TASK____________________________");
            LinqTask.ActorsName();
            LinqTask.ActorsAugustBirthday();
            LinqTask.OldestActorsNames();
            LinqTask.ArticlsByAuthor();
            LinqTask.ArticlesAndFilms();
            LinqTask.ActorsNamesDiffLetters();
            LinqTask.SortedArticls();
            LinqTask.ActorFilms();
            LinqTask.SumOfPages();
            LinqTask.DictionaryOfAuthors();
        }
    }
}
