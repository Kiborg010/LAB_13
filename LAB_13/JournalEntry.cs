using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_13
{
    public class JournalEntry
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }

        public JournalEntry(string name, string type, Car data)
        {
            Name = name;
            Type = type;
            Data = data.ToString();
        }

        public override string ToString()
        {
            return $"Новое действие\n\t{Name}\n\t{Type}\n\t{Data}";
        }
    }
}
