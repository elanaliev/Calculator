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

namespace Calculate_v3
    //Только целые числа
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
        }

        // Значения
 
        double num1;   
        double num2;
        double z;
        double z2;
        string d;
        string d2;
        bool b = false;
        /// <summary>
        /// Логика цифр при нажатии
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Tb1.Text += (sender as Button).Content;
        }
        int tree = 0;
        private void d_button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (b == false)
                {
                    d = null;
                    d += (sender as Button).Content;
                    num1 = Convert.ToDouble(Tb1.Text);
                    Tb1.Text = null;
                    Tb2.Text += $"{num1.ToString()} {d}";
                    b = true;

                }
                else
                {
                    d2 = null;
                    d2 += (sender as Button).Content;
                    num2 = Convert.ToInt32(Tb1.Text);
                    Tb1.Text = null;
                    Tb2.Text += $" {num2.ToString()}";
                    switch (d)
                    {
                        case "+":
                            sum(num1, num2, true);
                            break;
                        case "-":
                            minus(num1, num2, true);
                            break;
                        case "*":
                            umn(num1, num2, true);
                            break;
                        case "/":
                            del(num1, num2, true);
                            break;
                    }

                    Tb2.Text += $"= {z2} {d2}";
                }
                tree += 1;
                t();
            }
            catch (Exception u)
            {
                MessageBox.Show("Ты настолько плох что смог вызвать ошибку в калькуляторе =/" + u);
            }
            
        }
        public void t()
        {
            if(tree == 3)
            {
                Tb2.Text = $"{num1} {d} ";
                tree = 0;
            }
        }
        //=========================================================================================//
      
        public void sum(double n1, double n2, bool bb)
        {
            try
            {
                if (bb == false)
                {
                    z = n1 + n2;
                    num1 = z;
                    b = false;
                    Tb3.Text += $" {n1} + {n2} = {z}\n";

                }
                else
                {
                    z2 = n1 + n2;
                    num1 = z2;
                    d = d2;               
                    Tb3.Text += $" {n1} + {n2} = {z2}\n";
                    
                    
                }
            }
            catch (Exception u)
            {
                MessageBox.Show("Ты настолько плох что смог вызвать ошибку в калькуляторе =/" + u);
            }
            
        }
        public void minus(double n1, double n2, bool bb)
        {
            try
            {
                if (bb == false)
                {
                    z = n1 - n2;
                    num1 = z;
                    b = false;
                    Tb3.Text += $" {n1} - {n2} = {z}\n";
                }
                else
                {
                    z2 = n1 - n2;
                    num1 = z2;
                    d = d2;
                    Tb3.Text += $" {n1} - {n2} = {z2}\n";
                }
            }
            catch (Exception u)
            {
                MessageBox.Show("Ты настолько плох что смог вызвать ошибку в калькуляторе =/" + u);
            }

        }
        public void umn(double n1, double n2, bool bb)
        {
            try
            {
                if (bb == false)
                {
                    z = n1 * n2;
                    num1 = z;
                    b = false;
                    Tb3.Text += $" {n1} * {n2} = {z}\n";
                }
                else
                {
                    z2 = n1 * n2;
                    num1 = z2;
                    d = d2;
                    Tb3.Text += $" {n1} * {n2} = {z2}\n";
                }
            }
            catch (Exception u)
            {
                MessageBox.Show("Ты настолько плох что смог вызвать ошибку в калькуляторе =/" + u);
            }

        }
        public void del(double n1, double n2, bool bb)
        {
            try
            {
                if (bb == false)
                {
                    z = n1 / n2;
                    num1 = z;
                    b = false;
                    Tb3.Text += $" {n1} / {n2} = {z}\n";

                }
                else
                {
                    z2 = n1 / n2;
                    num1 = z2;
                    d = d2;
                    Tb3.Text += $" {n1} / {n2} = {z2}\n";


                }
            }
            catch (Exception u)
            {
                MessageBox.Show("Ты настолько плох что смог вызвать ошибку в калькуляторе =/" + u);
            }

        }
        //=============================================================================================================//
        private void ravno(object sender, RoutedEventArgs e)
        {
            if(b == false)
            {
                try
                {
                    num2 = Convert.ToDouble(Tb1.Text);
                    Tb1.Text = null;
                    Tb2.Text += $" {num2.ToString()}";
                    switch (d)
                    {
                    case "+":
                        sum(num1, num2, false);
                        break;
                    case "-":
                        minus(num1, num2, false);
                        break;
                    case "*":
                        umn(num1, num2, false);
                        break;
                    case "/":
                         del(num1, num2, false);
                        break;
                    }
                    Tb2.Clear();
                    Tb1.Text = z.ToString();

                }
                catch (Exception u)
                {
                    MessageBox.Show("Ты настолько плох что смог вызвать ошибку в калькуляторе =/" + u);
                }
                
                
            }
            else
            {
                try
                {
                    num2 = Convert.ToDouble(Tb1.Text);
                    Tb1.Text = null;
                    Tb2.Text += $" {num2.ToString()}";
                    switch (d)
                    {
                        case "+":
                            sum(num1, num2, true);
                            break;
                        case "-":
                            minus(num1, num2, true);
                            break;
                        case "*":
                            umn(num1, num2, true);
                            break;
                        case "/":
                            del(num1, num2, true);
                            break;
                    }
                    Tb2.Clear();
                    Tb1.Text = z2.ToString();
                    b = false;
                }
                catch (Exception u)
                {
                    MessageBox.Show("Ты настолько плох что смог вызвать ошибку в калькуляторе =/" + u);
                }
               
            }
            tree = 0;
           
        }

        private void cl_click(object sender, RoutedEventArgs e)
        {
            Tb1.Clear();
            Tb2.Clear();
            b = false;
            Tb3.Clear();
            num1 = 0;
            num2 = 0;
        }

        private void Btn_t(object sender, RoutedEventArgs e)
        {
            if(Tb3.Height != 0)
            {
                Tb3.Height = 0;
                btnp.Visibility = Visibility.Visible;
            }
            else
            {
                Tb3.Height = 218;
                btnp.Visibility = Visibility.Collapsed;
            }
           
        }
        double proc;
        double g;
        double s;
        private void Proc_btn(object sender, RoutedEventArgs e)
        {
            try
            {
                g = num1;
                proc = Convert.ToDouble(Tb1.Text);
                s = g / 100 * proc;
                Tb1.Text = s.ToString();
            }
            catch
            {

            }
            
        }
    }
}
