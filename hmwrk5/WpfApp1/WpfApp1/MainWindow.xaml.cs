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

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public class QuadEq
        {
            public QuadEq(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;
            }

            public int A { get; set; }
            public int B { get; set; }
            public int C { get; set; }

            public static string ToString(QuadEq a)//письменное представление
            {
                return (string.Format($"В уравнении {a.A} * x^2 + {a.B} * x + {a.C} = 0 :"));
            }
            public static string ToStringLin(QuadEq a)//письменное представление линейного
            {
                return (string.Format($"В уравнении {a.B} * x + {a.C} = 0 :"));
            }

            public static int DFind(QuadEq a)//поиск дискриминанта
            {
                return (a.B * a.B) - (4 * a.A * a.C);
            }

            public static double X1Find(QuadEq a)//поиск первого корня
            {
                if (a.A == 0)
                {
                    return 0;
                }
                else
                {
                    return ((a.B * -1) + Math.Sqrt(QuadEq.DFind(a))) / (2 * a.A);
                }

            }

            public static double X2Find(QuadEq a)//поиск второго корня
            {
                if (a.A == 0)
                {
                    return (-a.B / a.C);
                }
                else
                {
                    return ((a.B * -1) - Math.Sqrt(QuadEq.DFind(a))) / (2 * a.A);
                }
            }
            public static double LinFind(QuadEq a)//поиск корня линейного уравнения
            {
                if (a.A == 0)
                {
                    double r = a.B;
                    double k = a.C;
                    return (-k/ r);
                }
               else
                {
                    return 0;
                }
            }

        }

        QuadEq Eq = new QuadEq(0, 0, 0);//создаём экземпляр класса, занулив все значения
        private void aBox_TextChanged(object sender, TextChangedEventArgs e) //запись а
        {
            try
            {
                if (aBox.Text != " ")
                {
                    Eq.A = int.Parse(aBox.Text);
                }
            }
            catch { MessageBox.Show("Допустимы только целые числа!"); aBox.Text = ""; }
        }

        private void bBox_TextChanged(object sender, TextChangedEventArgs e) //запись b
        {
            try
            {
                if (bBox.Text != " ")
                {
                    Eq.B = int.Parse(bBox.Text);
                }
            }
            catch { MessageBox.Show("Допустимы только целые числа!"); bBox.Text = ""; }
        }

        private void cBox_TextChanged(object sender, TextChangedEventArgs e) //запись c
        {
            try
            {
                if (cBox.Text != " ")
                {
                    Eq.C = int.Parse(cBox.Text);
                }
            }
            catch { MessageBox.Show("Допустимы только целые числа!"); cBox.Text = ""; }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //double j = -1.0 / 0.0 ;
            
            if ((aBox.Text == " ") || (bBox.Text == " ") || (cBox.Text == " ")) //проверка чтобы все числа были введены
            {
                MessageBox.Show("Введите достаточное количество данных!");
            }
            else
            {      if (0 == Eq.A)
                {
                    ans.Text = QuadEq.ToStringLin(Eq) + "\nкорень один (т. к. A = 0) , уравнение линейное:" + $"x =  {QuadEq.LinFind(Eq)}";
                }
                else if (QuadEq.DFind(Eq) < 0) { ans.Text = QuadEq.ToString(Eq) + "\nкорней нет (D < 0)"; }
                else if (QuadEq.DFind(Eq) == 0)
                {
                    ans.Text = QuadEq.ToString(Eq) + "\nкорень один (т. к. D = 0):" + $" {QuadEq.X1Find(Eq)}";
                }
                
                else { ans.Text = QuadEq.ToString(Eq) + "\nкорня два (т. к. D > 0):" + $" {QuadEq.X1Find(Eq):0.00000} и {QuadEq.X2Find(Eq):0.00000}"; }
            }
        }
    }
}
