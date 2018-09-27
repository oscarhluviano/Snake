using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    public class Extra : Elemento
    {
        int stepsize = 10;
        public Extra(int num1, int num2)
        {
            int val1 = Generar(num1 / 10);
            int val2 = Generar(num2 / 10);
            if (440 <= val1 && 40 >= val1)
            {
                val1 = Generar(num1 / 10);
            }
            else
            {
                xValue = val1;
                if ((80 >= val2 && 30 <= val2) || (230 >= val2 && 180 <= val2) || (380 >= val2 && 330 <= val2))
                {
                    val2 = Generar(num2 / 10);

                }
                else
                {
                    yValue = val2;
                }
            }
        }

        public void Dibujar(Graphics papel)
        {
            SolidBrush brocha = new SolidBrush(Color.Black);
            papel.FillRectangle(brocha, xValue, yValue, 10, 10);
        }

        public int Generar(int alt)
        {
            Random generador;
            generador = new Random();
            int num = 10 * generador.Next(0, alt);
            return num;
        }

        public bool MoverX(int num1)
        {
            while (num1 < xValue || xValue < 0)
            {
                stepsize = -stepsize;
            }
            xValue = xValue + stepsize;
            return true;
        }

        public bool MoverY(int num1)
        {
            while (num1 < yValue || yValue < 0)
            {
                stepsize = -stepsize;
            }
            yValue = yValue + stepsize;
            return false;
        }
    }
}
