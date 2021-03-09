using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    [Serializable]
    class Car
    {
        public string name;
        protected int speed;
        public int Speed    //Свойство для скорости езды
        {
            get { return speed; }
            set
            {
                if (value < 0 || value > 200) speed = 0;    //Скорость не должна быть больше 200 км/ч
                else speed = value;
            }
        }
        public Car() : this("Noname", 100) { }  //Конструктор с одним аргументом
        public Car(string name, int speed)  //Конструктор с двумя аргументами
        {
            this.name = name;
            Speed = speed;
        }
        public virtual string drive()  //Виртуальный метод для езды
        {
            return $"Машина {name} едет со скоростью {speed} км/ч";
        }
        public override string ToString()   //Переопределенный ToString
        {
            return $"Автомобиль {name}, скорость {speed} км/ч";
        }
    }
}
