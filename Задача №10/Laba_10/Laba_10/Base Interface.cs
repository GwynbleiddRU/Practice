using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_10
{
    interface Base_Interface
    {
        void Input(); //метод ввода

        void Show(); //метод вывода

        new int CompareTo(object other); //сравнение
    }
}
