using System;
using System.Collections.Generic;
using System.Text;

namespace OlympList
{
    class Olympiad
    {
        public string name { get; set; }
        public string alink { get; set; }
        public string level { get; set; }
        public string number { get; set; }
        public string subject { get; set; }
        public string profile = "";

        public List<int> classes = new List<int>();

    }
}
