using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_10
{
    class Republic : State
    {
        static Random rand = new Random();
        public Republic(string type, string name, int gdp)
        {
            t = type;
            this.name = name;
            this.gdp = gdp;
        }
        public Republic()
        {
            string[] NAME = new string[] { "Великобритания", "Замбия", "Россия", "Уганда", "Китай", "Германия", "Франция", "Помпея", "Инженерия", "Эфиопия", "Румыния", "Норвегия", "Швейцария", "Кровосток", "Польша", "Киргизия", "Армения", "Япония", "Казахстан", "Офис", "Утопия", "Украина" };
            int num_t = rand.Next(1, 4);
            if (num_t == 1) this.t = "парламентарная";
            if (num_t == 2) this.t = "президентская";
            if (num_t == 3) this.t = "смешанная";

            name = $"{NAME[rand.Next(0, NAME.Length)]}";
            this.gdp = rand.Next(1000, 3000);
        }
        public override void Show()
        {
            //Console.WriteLine("Государство: " + "республика" + "\n тип: " + t + "\n название: " + name + "\n ВВП: " + gdp + " млрд. долларов США");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n Государство: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("республика");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n тип: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(t);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n название: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n ВВП: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(gdp + " млрд. долларов США");
            Console.WriteLine();
        }
    }
}
