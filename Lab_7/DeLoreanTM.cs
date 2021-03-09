using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    [Serializable]
    class DeLoreanTM : Car
    {
        public new int Speed    //Свойство на скорость
        {
            get { return speed; }
            set
            {
                if (value < 0 || value > 177) speed = 0;    //DeLorean DMC-12 может разгоняться до 177 км/ч
                else speed = value;
            }
        }
        public DeLoreanTM(string name, int speed) : base(name, speed) { } //Конструктор (с тремя аргументами) вызывает базовый с двумя аргументами и заполняет поле цвета
        public override string drive() //Переопределенный метод для езды. При разгоне до 88 миль/ч (или 141 км/ч) машина может путешествовать во времени
        {
            return $"Машина времени DeLorean {name} едет со скоростью {speed} км/ч";
        }
        public string fly() //Переопределенный метод для полета. При разгоне до 88 миль/ч (или 141 км/ч) машина может путешествовать во времени
        {
            return $"Машина времени DeLorean {name} летит со скоростью {speed} км/ч";
        }
        public override string ToString()   //Переопределенный ToString
        {
            return $"Машина времени DeLorean {name}, скорость - {speed} км/ч";
        }


        //Добавьте статический метод, который запишет в текстовый файл всю информацию о типе вашего класса (рефлексия). Имя файла – параметр метода.
        public static void SaveClass(string filename)
        {
            Type t = typeof(DeLoreanTM);
            StreamWriter f = new StreamWriter(filename);
            f.WriteLine("Полное имя класса:" + t.FullName);
            if (t.IsAbstract) f.WriteLine("Абстрактный класс");
            if (t.IsClass) f.WriteLine("Обычный класс");
            if (t.IsInterface) f.WriteLine("Интерфейс");
            if (t.IsEnum) f.WriteLine("Перечисление");
            if (t.IsSealed) f.WriteLine("Закрыт для наследования");
            f.WriteLine("Базовый класс - " + t.BaseType);

            FieldInfo[] fields = t.GetFields(); //GetFields возвращает все поля
            if (fields.Count() > 0)
                f.WriteLine("*** Поля класса: ***");
            foreach (var field in fields)
            {
                f.WriteLine(field);
            }

            PropertyInfo[] properties = t.GetProperties();  //GetProperties возвращает все свойства
            if (properties.Count() > 0)
                f.WriteLine("*** Свойства класса: ***");
            foreach (var property in properties)
            {
                f.WriteLine(property);
            }

            MethodInfo[] methods = t.GetMethods();  //GetMethods возвращает все методы
            if (methods.Count() > 0)
                f.WriteLine("*** Методы класса: ***");
            foreach (var method in methods)
            {
                f.WriteLine(method);
            }

            f.Close();
        }

        //Добавьте экземплярный метод, который будет сохранять в бинарный файл всю информацию о текущем объекте. Имя файла – параметр метода.
        public void SaveObject(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(name);
            bw.Write(speed);
            fs.Close();
        }

        //Метод, который будет читать информацию из бинарного файла и возвращать готовый объект. Имя файла – параметр метода.
        public static DeLoreanTM LoadObject(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            string name = br.ReadString();
            int speed = br.ReadInt32();
            fs.Close();
            return new DeLoreanTM(name, speed);
        }

        //Добавьте методы, которые сериализуют и десериализуют объекты вашего класса. Имя файла – параметр метода.
        //Сериализация
        public void Serialize(string filename)
        {
            Stream fs = new FileStream(filename, FileMode.Create);
            BinaryFormatter fmt = new BinaryFormatter();
            fmt.Serialize(fs, this);
            fs.Close();
        }

        //Десериализация
        public static DeLoreanTM Deserialize(string filename)
        {
            Stream fs = new FileStream(filename, FileMode.Open);
            BinaryFormatter fmt = new BinaryFormatter();
            DeLoreanTM deLorean = (DeLoreanTM)fmt.Deserialize(fs);
            fs.Close();
            return deLorean;
        }
    }
}
