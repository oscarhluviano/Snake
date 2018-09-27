using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    class Obstaculo :Elemento
    {
        public Obstaculo(int n1, int n2)
        {
            xValue = n1;
            yValue = n2;
        }
        public void Dibujar(Graphics papel)
        {
            SolidBrush brocha = new SolidBrush(Color.Gray);
            papel.FillRectangle(brocha, xValue, yValue, 400, 50);
        }
    }
}
