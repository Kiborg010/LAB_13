//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LAB_13
//{
//    delegate void ModifyString(ref string str);
//    class StringHandlers
//    {
//        public void ReplaceSpaces(ref string str)
//        {
//            Console.WriteLine("Замена пробелов");
//            str = str.Replace(" ", "-");
//        }

//        public void RemoveSpaces(ref string str)
//        {
//            Console.WriteLine("Удаление пробелов");
//            string temp = "";
//            foreach (char c in str)
//            {
//                if (c != ' ')
//                {
//                    temp += c;
//                }
//            }
//            str = temp;
//        }

//        public void ReverseString(ref string str)
//        {
//            Console.WriteLine("Реверс строки");
//            char[] temp = str.ToCharArray();
//            Array.Reverse(temp);
//            str = new string(temp);
//        }
//    }
//    internal class Class1
//    {
//        static void Main(string[] args)
//        {
//            StringHandlers sh = new StringHandlers();
//            string str = "В траве сидел кузнечик";
//            ModifyString ms = sh.RemoveSpaces;
//            ms += sh.ReverseString;
//            if (ms != null)
//            {
//                ms(ref str);
//            }
//            Console.WriteLine(str);
            
//            str = "В траве сидел кузнечик";
//            ms -= sh.RemoveSpaces;
//            ms += sh.ReplaceSpaces;
//            if (ms != null)
//            {
//                ms(ref str);
//            }
//            Console.WriteLine(str);
//        }
//    }
//}
