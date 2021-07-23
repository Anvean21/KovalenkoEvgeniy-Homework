using System;
using System.Collections.Generic;
using System.Text;

namespace Threads
{
    public class Data
    {
        public decimal[] Array { get; set; }
        public int? Start { get; set; }
        public int? End { get; set; }
        public decimal[] IntermediateArray { get; set; }
        //Пропертя для копирования массива, для корректной работы с пулом потоков
        public int? Indent { get; set; }
    }
}
