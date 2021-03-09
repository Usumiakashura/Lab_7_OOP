using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/*
 Для строки StringBuilder реализуйте следующие действия:
1 – ввод строки с клавиатуры (указывать размер)
2 – вывод строки
3 – после указанного символа каждый раз вставить *
4 – заменить один символ на другой
5 – удалить все вхождения указанной подстроки
0 - выход
 */
namespace Lab__7
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder str = new StringBuilder();
            //Вывод меню на экран
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|                   Меню:                  |");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1 – ввод строки с клавиатуры (указывать размер)");
            Console.WriteLine("2 – вывод строки");
            Console.WriteLine("3 – после указанного символа каждый раз вставить *");
            Console.WriteLine("4 – заменить один символ на другой");
            Console.WriteLine("5 – удалить все вхождения указанной подстроки");
            Console.WriteLine("0 – выход");

            //Цикл считывания пунктов меню и выполнения методов
            bool r = true;
            while (r)
            {
                Console.Write("\nВыбрать пункт меню: ");
                string point = Console.ReadLine();
                int p;
                if (!Int32.TryParse(point, out p)) continue; //Проверка на корректность ввода
                switch (p)
                {
                    case 1: met1(ref str); break;
                    case 2: met2(ref str); break;
                    case 3: met3(ref str); break;
                    case 4: met4(ref str); break;
                    case 5: met5(ref str); break;
                    case 0: r = false; break;
                }
            }
        }
        //ввод строки с клавиатуры (указывать размер)
        static void met1(ref StringBuilder str)
        {
            str.Clear();
            str.Append(Console.ReadLine());
            Console.WriteLine($"Длина строки: {str.Length}");
        }
        //вывод строки
        static void met2(ref StringBuilder str)
        {
            Console.WriteLine(str);
            Console.WriteLine($"Длина строки: {str.Length}");
            Console.WriteLine($"Емкость строки: {str.Capacity}");
        }
        //после указанного символа каждый раз вставить *
        static void met3(ref StringBuilder str)
        {
            Console.Write("Введите символ: ");
            char s = Convert.ToChar(Console.ReadLine());

            bool control = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (control)
                {
                    str[i] = '*'; 
                }
                if (str[i] == s)
                {
                    control = true;
                }
            }
        }
        //заменить один символ на другой
        static void met4(ref StringBuilder str)
        {
            Console.Write("Введите символ, который нужно заменить: ");
            char s = Convert.ToChar(Console.ReadLine());

            Console.Write("Введите новый символ: ");
            char c = Convert.ToChar(Console.ReadLine());

            str.Replace(s, c);
        }
        //удалить все вхождения указанной подстроки
        static void met5(ref StringBuilder str)
        {
            Console.Write("Введите подстроку: ");
            string st = Console.ReadLine();
            str.Replace(st, "");
        }
    }
}
