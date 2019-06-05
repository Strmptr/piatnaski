using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using static Shapes15.MainWindow;

namespace Shapes15
{





    public partial class Logics

    {
        CCell[,] cells = new CCell[C, R];
        Random rng = new Random();
        const int W = 64;
        const int H = 64;
        int[,] m = new int[C, R];
        const int C = 4;
        const int R = 4;

        public Rectangle cell;
        public int i;
        public int j;

        int[,] link;
        public void start()
        {
            for (int i = 0; i < C; i++)
                for (int j = 0; j < R; j++)
                {
                    m[i, j] = 1;
                }
            m[C - 1, R - 1] = 0;

            for (int i = 0; i < C; i++)
                for (int j = 0; j < R; j++)
                {
                    if ((i == C - 1) && (j == R - 1))
                    {
                        cells[i, j] = null;
                    }
                    else
                    {
                        cells[i, j] = new CCell(scene);
                        cells[i, j].setPos(i, j, ref m);
                    }
                }

            MouseButtonEventArgs ev = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
            for (int i = 0; i < 100; i++)
            {
                int a = rng.Next(4);
                int b = rng.Next(4);

                if (cells[a, b] != null)
                {

                    cells[a, b].Cell_MouseDown(cells[a, b].cell, ev);
                }
            }
        }

        public void game_over()
        {

        }
        public void predv()
        {
            if (i + 1 < C)
            {
                if (link[i + 1, j] == 0)
                {
                    link[i + 1, j] = 1;
                    link[i, j] = 0;
                    i++;
                    cell.RenderTransform = new TranslateTransform(i * W, j * H);
                    return;
                }
            }

            if (j + 1 < R)
            {
                if (link[i, j + 1] == 0)
                {
                    link[i, j + 1] = 1;
                    link[i, j] = 0;
                    j++;
                    cell.RenderTransform = new TranslateTransform(i * W, j * H);
                    return;
                }
            }

            if (i - 1 >= 0)
            {
                if (link[i - 1, j] == 0)
                {
                    link[i - 1, j] = 1;
                    link[i, j] = 0;
                    i--;
                    cell.RenderTransform = new TranslateTransform(i * W, j * H);
                    return;
                }
            }

            if (j - 1 >= 0)
            {
                if (link[i, j - 1] == 0)
                {
                    link[i, j - 1] = 1;
                    link[i, j] = 0;
                    j--;
                    cell.RenderTransform = new TranslateTransform(i * W, j * H);
                    return;
                }
            }

        }
       
    }
}