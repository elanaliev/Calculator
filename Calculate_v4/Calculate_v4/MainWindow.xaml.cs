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
using System.Text.RegularExpressions;

namespace Calculate_v4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int opState = 0;
        Dictionary<string, string[]> Operators = new Dictionary<string, string[]>() { 
            { "a1", new string[] {"+", "^"} }, 
            { "a2", new string[] { "-", "√" } }, 
            { "a3", new string[] { "*", "R" } }, 
            { "a4", new string[] { "/", "cos" } } 
        };

        #region Main Controls
        private void CloseButton_Click(object sender, RoutedEventArgs e) => this.Close();
        private void LMBFocus(object sender, MouseButtonEventArgs e) => this.DragMove();
        private void ClearButton_Click(object sender, RoutedEventArgs e) => MainTBox.Text = "0";
        #endregion

        private void NumButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            MainTBox.Text = (MainTBox.Text == "0") ? button.Content.ToString() : MainTBox.Text + button.Content;
        }


        #region DRY? nope.
        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            int operatorIndex = ATBox.Text.Length - 1;
            string expr = ATBox.Text;
            string mtext = MainTBox.Text;

            if (double.TryParse(mtext, out var a) == true)
            {
                if(!IsConverting(button.Content.ToString(), mtext))
                {
                    expr = (expr == string.Empty) ? MainTBox.Text + button.Content : Solve(expr[operatorIndex], double.Parse(expr.Substring(0, operatorIndex)), double.Parse(mtext)).ToString() + button.Content;
                    ATBox.Text = expr;
                    MainTBox.Text = string.Empty;
                }
            }
            else
            {
                if (button.Content.ToString() == "-")
                {
                    MainTBox.Text = (mtext.Contains("-")) ? mtext : mtext + '-';
                }
            }
            opState = 0;
            SwitchOperators();
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            int operatorIndex = ATBox.Text.Length - 1;
            string expr = ATBox.Text;
            string mtext = MainTBox.Text;
            expr = (expr == string.Empty) ?  expr : Solve(expr[operatorIndex], double.Parse(expr.Substring(0, operatorIndex)), (double.TryParse(mtext, out var a)) ? a : 0).ToString();
            ATBox.Text = string.Empty;
            MainTBox.Text = expr;
        }
        #endregion

        double Solve(char _operator, double val1, double val2)
        {
            if (_operator == '+') return val1 + val2;
            if (_operator == '-') return val1 - val2;
            if (_operator == '*') return val1 * val2;
            if (_operator == '/') return val1 / ((val2 != 0) ? val2 : 1);
            if (_operator == '^') return Math.Pow(val1, val2);
            else return 0;
        }

        bool IsConverting(string type, string val)
        {
            double value = double.Parse(val);
            if (type == "√")
            {
                MainTBox.Text = Math.Sqrt(value).ToString();
                return true;
            }
            if(type == "R")
            {
                MainTBox.Text = Math.Round(value).ToString();
                return true;
            }
            if(type == "cos")
            {
                MainTBox.Text = Math.Cos(value).ToString();
                return true;
            }
            else return false;
            
        }

        void SwitchOperators()
        {
            foreach(string key in Operators.Keys)
            {
                this.Resources.Remove(key);
                this.Resources.Add(key, Operators[key][opState]);
            }
        }

        private void SwitchState_Click(object sender, RoutedEventArgs e)
        {
            opState = (opState == 0) ? 1 : 0;
            SwitchOperators();
        }
    }
}
