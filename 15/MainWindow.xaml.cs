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


namespace _15
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random rand = new Random();
        Button[] B;
        int yt, yb;
        int xl, xr;
        


        public MainWindow()

        {
            InitializeComponent();
            B = new Button[16];
            B[0] = button1;
            B[1] = button2;
            B[2] = button3;
            B[3] = button4;
            B[4] = button5;
            B[5] = button6;
            B[6] = button7;
            B[7] = button8;
            B[8] = button9;
            B[9] = button10;
            B[10] = button11;
            B[11] = button12;
            B[12] = button13;
            B[13] = button14;
            B[14] = button15;
            B[15] = button16;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Button bclick = (Button)sender;
            int n = (int)Convert.ToInt64(bclick.Tag.ToString()); //save number button
            n--;
            int y = n / 4;
            int x = n - y * 4;
            
            yt = y - 1;
            yb = y + 1;
            xl = x - 1;
            xr = x + 1;

            if (xr < 4)
            {
                int nr = y * 4 + xr;
                if (B[nr].Visibility == Visibility.Hidden)//если кнопка не видима то меняемся
                {
                    B[nr].Visibility = Visibility.Visible;
                    B[n].Visibility = Visibility.Hidden;
                    B[nr].Content = B[n].Content;
                }
                if (xl >= 0)
                {
                    int nl = y * 4 + xl;
                    if (B[nl].Visibility == Visibility.Hidden)
                    {
                        B[nl].Visibility = Visibility.Visible;
                        B[n].Visibility = Visibility.Hidden;
                        B[nl].Content = B[n].Content;
                    }
                }
                if (yt >= 0)
                {
                    int nt = yt * 4 + x;
                    if (B[nt].Visibility == Visibility.Hidden)
                    {
                        B[nt].Visibility = Visibility.Visible;
                        B[n].Visibility = Visibility.Hidden;
                        B[nt].Content = B[n].Content;
                    }
                }
                if (yb < 4)
                {
                    int nb = yb * 4 + x;
                    if (B[nb].Visibility == Visibility.Hidden)
                    {
                        B[nb].Visibility = Visibility.Visible;
                        B[n].Visibility = Visibility.Hidden;
                        B[nb].Content = B[n].Content;
                    }
                }

            }
            
        }
        
    }
}
