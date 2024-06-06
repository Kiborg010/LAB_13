//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Timers;
//using Timer = System.Timers.Timer;

//namespace LAB_13
//{
//    internal class Class2
//    {
//        static int count = 0;
//        static string str = "В траве сидел кузнечик!";
//        static void WriteChar(object source, ElapsedEventArgs e)
//        {
//            Console.WriteLine(str[count++%str.Length]);
//        }
//        static void Main(string[] args)
//        {
//            Timer timer = new Timer(300);
//            timer.Elapsed += WriteChar;
//            timer.Start();
//            Console.ReadLine();
//        }
//        static void Main(string[] args)
//        {
//            Timer timer = new Timer(300);
//        }
//    }
//}
