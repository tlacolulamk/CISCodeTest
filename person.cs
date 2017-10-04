using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CISCodeTest
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool isActive { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string eyeColor { get; set; }
        public string[] friends { get; set; }
    }
}

