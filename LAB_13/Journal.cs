using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_13
{
    internal class Journal
    {
        List<JournalEntry> journal = new List<JournalEntry>();
        public void WriteRecord(object source, CollectionHandlerEventArgs args)
        {
            journal.Add(new JournalEntry(((MyObservableCollection<Car>)source).Name, args.changeType, args.changeObject.ToString()));
        }

        public void PrintJournal()
        {
            if (journal.Count == 0)
            { 
                Console.WriteLine("Журнал пустой"); 
            }
            else
            {
                foreach (JournalEntry entry in journal)
                {
                    Console.WriteLine(entry.ToString());
                }
            }
        }
    }
}
