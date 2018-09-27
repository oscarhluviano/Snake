using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    class Comida : Elemento
    {
        public Comida(int num1, int num2)
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
            SolidBrush brocha = new SolidBrush(Color.Red);
            papel.FillRectangle(brocha, xValue, yValue, sizeValue, sizeValue);
        }
        public void Mover(int xMov, int yMov)
        {
            int val1 = Generar(xMov / 10);
            int val2 = Generar(yMov / 10);
            if (440 <= val1 && 40 >= val1)
            {
                val1 = Generar(xMov / 10);
            }
            else
            {
                xValue = val1;
                if ((80 >= val2 && 30 <= val2) || (230 >= val2 && 180 <= val2) || (380 >= val2 && 330 <= val2))
                {
                    val2 = Generar(yMov / 10);

                }
                else
                {
                    yValue = val2;
                }
            }
        }
        public int Generar(int alt)
        {
            Random generador;
            generador = new Random();
            int num = 10 * generador.Next(0, alt);
            return num;
        }
    }
}
