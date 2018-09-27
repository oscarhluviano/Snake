using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    public class Elemento
    {
        protected int xValue, yValue, sizeValue, widthValue, heigthValue;
        public int X
        {
            get { return xValue; }
        }
        public int Y
        {
            get { return yValue; }
        }
        public int Size
        {
            get { return sizeValue; }
        }
        public int Width
        {
            get
            {
                return widthValue;
            }
        }
        public int Heigth
        {
            get
            {
                return heigthValue;
            }
        }
        public Elemento()
        {
            sizeValue = 10;
        }

        public Boolean Colision(Elemento otro)
        {
            int difx = Math.Abs(this.X - otro.X);
            int dify = Math.Abs(this.Y - otro.Y);
            if (difx >= 0 && difx < sizeValue && dify >= 0 && dify < sizeValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
