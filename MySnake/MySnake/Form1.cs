using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySnake
{
    public partial class Form1 : Form
    {
        private Graphics papel;
        private ColaSerpiente cabeza;
        private Comida manzana;
        private Extra ext;
        private Obstaculo ob1, ob2, ob3;
        private int tamanio = 10;
        private int xdir = 0, ydir = 0;
        private int puntos = 0;
        private int nivel = 1;
        private int valor = 1;
        private Boolean ejex = true, ejey = true;
        Random aleatorio;

        public Form1()
        {
            InitializeComponent();
            papel = canvas.CreateGraphics();
            cabeza = new ColaSerpiente(10, 10);
            manzana = new Comida(canvas.Width, canvas.Height);
            ext = new Extra(canvas.Width, canvas.Height);
            label1.Text = "Score: ";
            label2.Text = "0";
            label3.Text = "Level";
            label4.Text = Convert.ToString(nivel);
            aleatorio = new Random();
            bucle.Start();
        }

        

        private void bucle_Tick(object sender, EventArgs e)
        {
            DibujarTodo();
            MoverTodo();
            ChocarPared();
            ChocarCuerpo();
            ChocarObstaculo(ob1);
            ChocarObstaculo(ob2);
            ChocarObstaculo(ob3);

            if (cabeza.Colision(manzana))
            {
                manzana.Mover(canvas.Width, canvas.Height);
                cabeza.Agregar();
                puntos++;
                label2.Text = puntos + "";
            }
            if (cabeza.Colision(ext)) FinDelJuego();

            if (ext.Colision(manzana))
                ext = new Extra(canvas.Width, canvas.Height);
        
            if (puntos == 5 && nivel == 1) Reset();

            if (puntos == 5 && nivel == 2) Reset();

            if (nivel > 2)
                bucle.Interval = 100 - 4 * puntos;

            if (puntos == 5 && nivel == 3) Reset();

            if (puntos == 5 && nivel == 4) Reset();

            if (puntos == 5 && nivel == 5)
            {
                xdir = 0;
                ydir = 0;
                puntos = 0;
                label2.Text = "0";
                ejex = true;
                ejey = true;
                cabeza = new ColaSerpiente(10, 10);
                manzana = new Comida(canvas.Width, canvas.Height);
                MessageBox.Show("Felicidades, terminaste el juego");
                Application.Exit();
            }
        }

        private void MoverTodo()
        {
            cabeza.Mover(cabeza.X + xdir, cabeza.Y + ydir);
            if (nivel > 3)
            {
                bool mov = true;
                if (valor % 2 == 0 && mov)
                {
                    mov = ext.MoverX(canvas.Width);
                }
                else
                {
                    ext.MoverY(canvas.Width);
                }
            }
            if (nivel > 4)
            {
                valor = aleatorio.Next(0, 100);
                if (valor % 2 == 0)
                {
                    ext.MoverX(canvas.Width);
                }
                else
                {
                    ext.MoverY(canvas.Width);
                }
            }
        }

        private void Reset()
        {
            xdir = 0;
            ydir = 0;
            puntos = 0;
            label2.Text = "0";
            ejex = true;
            ejey = true;
            cabeza = new ColaSerpiente(10, 10);
            manzana = new Comida(canvas.Width, canvas.Height);
            MessageBox.Show("Superaste el nivel");
            nivel++;
            label4.Text = Convert.ToString(nivel);
        }

        private void ChocarCuerpo()
        {
            ColaSerpiente colatemporal;
            try
            {
                colatemporal = cabeza.VerSiguiente().VerSiguiente();
            }
            catch (Exception error)
            {
                colatemporal = null;
            }
            while (colatemporal != null)
            {
                if (cabeza.Colision(colatemporal) || ext.Colision(colatemporal))
                {
                    FinDelJuego();
                }
                else
                {
                    colatemporal = colatemporal.VerSiguiente();
                }
            }
        }

        private void ChocarObstaculo(Elemento otro)
        {
            if (nivel > 1)
            {
                if (((((otro.X + 400) > cabeza.X) && (otro.X) <= cabeza.X)) &&
                        (((otro.Y + 50) > cabeza.Y) && ((otro.Y) <= cabeza.Y)))
                {
                    FinDelJuego();
                }
            }
        }

        private void ChocarPared()
        {
            if (cabeza.X < 0 || cabeza.X >= canvas.Width || cabeza.Y < 0 || cabeza.Y >= canvas.Height)
            {
                FinDelJuego();
            }
            if (nivel > 3)
            {
                if (ext.X < 0 || ext.X >= canvas.Width || ext.Y < 0 || ext.Y >= canvas.Height)
                {
                    ext = new Extra(canvas.Width, canvas.Height);
                }
            }

        }

        private void DibujarTodo()
        {
            papel.Clear(Color.White);

            if (nivel > 1)
            {
                ob1 = new Obstaculo(40, 30);
                ob1.Dibujar(papel);
                ob2 = new Obstaculo(40, 180);
                ob2.Dibujar(papel);
                ob3 = new Obstaculo(40, 330);
                ob3.Dibujar(papel);
            }
            if (nivel > 3)
            {
                ext.Dibujar(papel);
            }
            cabeza.Dibujar(papel);
            manzana.Dibujar(papel);
        }

        private void FinDelJuego()
        {
            xdir = 0;
            ydir = 0;
            puntos = 0;
            label2.Text = "0";
            ejex = true;
            ejey = true;
            cabeza = new ColaSerpiente(10, 10);
            manzana = new Comida(canvas.Width, canvas.Height);
            MessageBox.Show("Perdiste");
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ejex)
            {
                if (e.KeyCode == Keys.Up)
                {
                    ydir = -tamanio;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    ydir = tamanio;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
            }
            if (ejey)
            {
                if (e.KeyCode == Keys.Left)
                {
                    xdir = -tamanio;
                    ydir = 0;
                    ejey = false;
                    ejex = true;
                }
                if (e.KeyCode == Keys.Right)
                {
                    xdir = tamanio;
                    ydir = 0;
                    ejey = false;
                    ejex = true;
                }
            }
        }
    }
}
