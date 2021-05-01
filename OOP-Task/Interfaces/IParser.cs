using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Task
{
    public interface IParser<T> where T : AbstractFile
    {
        T Parse(string[] inputString);
    }
}
