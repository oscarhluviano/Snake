using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    class ColaSerpiente : Elemento
    {
        private ColaSerpiente siguiente;

        public ColaSerpiente(int x, int y)
        {
            xValue = x;
            yValue = y;
            siguiente = null;
        }

        public void Dibujar(Graphics papel)
        {
            if (siguiente != null)
            {
                siguiente.Dibujar(papel);
            }
            Brush brocha = new SolidBrush(Color.Blue);
            papel.FillRectangle(brocha, xValue, yValue, sizeValue, sizeValue);
        }

        public void Mover(int x, int y)
        {
            if (siguiente != null)
            {
                siguiente.Mover(xValue, yValue);
            }
            xValue = x;
            yValue = y;
        }

        public void Agregar()
        {
            if (siguiente == null)
            {
                siguiente = new ColaSerpiente(xValue, yValue);
            }
            else
            {
                siguiente.Agregar();
            }
        }

        public ColaSerpiente VerSiguiente()
        {
            return siguiente;
        }
    }
}
