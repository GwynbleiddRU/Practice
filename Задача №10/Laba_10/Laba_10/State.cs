using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_10
{
    class State
    {
        public string name;
        public string type;
        public double gdp;
        public string t;
        Random rand = new Random();
        public string Name //State name
        {
            get { return name; }
            set { name = value; }
        }
        public double GDP //Gross Domestic Product (n billion usd)
        {
            get { return gdp; }
            set
            {
                if ((value > 100000) && (value < 3000000)) gdp = value;
                else gdp = rand.Next(100000, 3000000);
            }
        }
        //public string Type //State type
        //{
        //    get { return type; }
        //    set { type = value; }
        //}
        public string Type
        {
            get { return type; }
            set
            {
                if ((value == "монархия") || (value == "республика")) type = value;
                else type = "монархия";
            }
        }
        public State(string name)
        {
            this.name = name;
        }
        public State()
        {
            this.name = "";
        }
        virtual public void Show()
        {
            Console.WriteLine("Государство: " + name);
        }
        //virtual public void MonarchSearch()
        //{

        //}
    }
}
