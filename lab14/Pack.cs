using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab14
{
    public class Pack
    {
        private string[] authtors = { "Vasya", "Ilya", "Kolya", "Ivan", "Sergey", "Anton", "Bogdan" };
        private string[] names = { "Овощи", "Сбер кот", "Собаки", "Смайлы", "Утка" };
        public string Smile { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public Pack(string smile) 
        {
            Random rnd = new Random();
            Smile = smile;
            Author = authtors[rnd.Next(0, authtors.Length - 1)];
            Name = names[rnd.Next(0, names.Length - 1)];
        }
    }
}
