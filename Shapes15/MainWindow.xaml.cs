using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shapes15
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rng = new Random();

        const int W = 64;
        const int H = 64;

        const int C = 4;
        const int R = 4;
        
        public class CCell
        {
            public Rectangle cell;
            //кисть для заполнения прямоугольника фрагментом изображения
            ImageBrush ib;
            public int i; 
            public int j;

            int[,] link;

            public CCell(Canvas scene)
            {
                cell = new Rectangle();
                //установка цвета линии обводки и цвета заливки при помощи коллекции кистей
                cell.Stroke = Brushes.Black;
                cell.Fill = Brushes.SkyBlue;
                //параметры выравнивания
                cell.HorizontalAlignment = HorizontalAlignment.Left;
                cell.VerticalAlignment = VerticalAlignment.Center;
                //размеры прямоугольника
                cell.Height = H;
                cell.Width = W;
                cell.Margin = new Thickness(0, 0, 0, 0);
                
                //кисть для заполнения прямоугольника фрагментом изображения
                ib = new ImageBrush();
                //настройки, позиция изображения будет указана как координаты левого верхнего угла
                
                //изображение будет выведено без растяжения/сжатия
                ib.AlignmentX = AlignmentX.Left;
                ib.AlignmentY = AlignmentY.Top;
                ib.Stretch = Stretch.None;
                //участок изображения который будет нарисован
                //в данном случае, второй кадр первой строки
                ib.Viewbox = new Rect(100, 0, 200, 100);
                ib.ViewboxUnits = BrushMappingMode.Absolute;
                //загрузка изображения и назначение кисти
                ib.ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Resorces/grid.png", UriKind.Absolute));
                cell.Fill = ib;

                scene.Children.Add(cell);

                cell.MouseDown += Cell_MouseDown;

                i = j = 0;
            }

            public void Cell_MouseDown(object sender, MouseButtonEventArgs e)
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
                    if (link[i, j+1] == 0)
                    {
                        link[i, j+1] = 1;
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
                        link[i, j-1] = 1;
                        link[i, j] = 0;
                        j--;
                        cell.RenderTransform = new TranslateTransform(i * W, j * H);
                        return;
                    }
                }
            }

            public void setPos(int i, int j, ref int[,] l)
            {
                cell.RenderTransform = new TranslateTransform(i*W, j*H);
                ib.Viewbox = new Rect(i*W, j*H, i*W+W, j*H+H);

                this.i = i;
                this.j = j;

                link = l;
            }
        }

        int[,] m = new int[C, R];

        CCell[,] cells = new CCell[C, R];

        public MainWindow()
        {
            InitializeComponent();

        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
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

                    cells[a, b].Cell_MouseDown(cells[a,b].cell, ev);
                }
            }
        
        }
    }
}
