using System;
using System.Collections.Generic;
using System.Text;

namespace LinqHomework
{
    class Film : ArtObject
    { 
        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
}
