using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            DeLoreanTM tm1 = new DeLoreanTM("DMC-89", 123);
            Console.WriteLine("Вывод только что созданной машины времени:");
            Console.WriteLine(tm1 + "\n");

            DeLoreanTM.SaveClass("DeLoreanTM.txt");
            Console.WriteLine("Сохранение информации о классе DeLoreanTM в файл DeLoreanTM.txt\n");

            tm1.SaveObject("DeLoreanTM_num_1.bin");
            Console.WriteLine("Сохранение информации об объекте в файл DeLoreanTM_num_1.bin\n");
            
            tm1.name = "OOO-00";
            tm1.Speed = 45;
            Console.WriteLine("Изменение параметров объекта");

            Console.WriteLine("\nНынешний объект в памяти:\n" + tm1);
            tm1 = DeLoreanTM.LoadObject("DeLoreanTM_num_1.bin");
            Console.WriteLine("\nОбъект из файла:\n" + tm1);

            tm1.Serialize("serTM1.bin");
            Console.WriteLine("\nСериализовали объект tm1");

            tm1.name = "LLL-11";
            tm1.Speed = 111;
            Console.WriteLine("\nИзменение параметров объекта");

            Console.WriteLine(tm1);

            tm1 = DeLoreanTM.Deserialize("serTM1.bin");
            Console.WriteLine("\nДесериализовали объект tm1");

            Console.WriteLine(tm1);

            Console.ReadKey();
        }
    }
}
