using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab___7
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex reg = new Regex(@"\+375( ?)\(((29?)|(25?)|(33?)|(44?)|(17?))\)( ?)\d{3}( ?)-( ?)\d{2}( ?)-( ?)\d{2}"); //регулярное выражение
            string str = $"Василий +375(29)123-45-67\n";
            str += $"Мария +375 (33) 569-45-89\n";
            str += $"Виктор +375(35)789-63-85\n";
            str += $"Лидия +375 (44)456-89-12\n";
            str += $"Владислав +375(17) 456-78-888\n";

            MatchCollection matches = reg.Matches(str);
            foreach (Match m in matches)
            {
                Console.WriteLine(m.Value);
            }
        }
    }
}
