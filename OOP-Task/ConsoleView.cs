using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public class ConsoleView
    {
        public ConsoleView()
        {
            string text = @"Text:file.txt(6B); Some string content 
                            Image:img.bmp(19MB); 1920х1080 
                            Text:data.txt(12B); Another string
                            Text:data1.txt(7B); Yet another string
                            Movie:logan2017.mkv(19GB); 1920х1080; 2h12m";
            var parsersList = new List<IParser<AbstractFile>>();
            parsersList.AddRange(new IParser<AbstractFile>[] { new TextParser(), new ImagesParser(), new VideosParser() });

            foreach (var item in parsersList)
            {
                FileParser parser = new FileParser(item);
                parser.ExecuteParser(text);
            }
        }
    }
}
