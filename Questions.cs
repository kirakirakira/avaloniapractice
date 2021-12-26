using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp
{
    public class Questions
    {
        public double Version { get; set; }

        public List<QuestionPair?>? QuestionPairs { get; set; }

        public int counter { get; set; } = -1;
        public void IncrementCounter()
        {
            counter++;
        }

    }
}
