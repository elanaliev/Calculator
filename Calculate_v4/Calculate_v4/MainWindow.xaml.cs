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
            { "a2", new string[] { "-", "" } }, 
            { "a3", new string[] { "*", "" } }, 
            { "a4", new string[] { "/", "" } } 
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

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            int operatorIndex = ATBox.Text.Length - 1;
            string result = ATBox.Text;
            result = (result == string.Empty) ? 
                MainTBox.Text + button.Content : Solve(result[operatorIndex], int.Parse(result.Substring(0, operatorIndex)), int.Parse(MainTBox.Text)).ToString() + button.Content;
            ATBox.Text = result;
            MainTBox.Text = string.Empty;
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            int operatorIndex = ATBox.Text.Length - 1;
            string result = ATBox.Text;
            result = Solve(result[operatorIndex], int.Parse(result.Substring(0, operatorIndex)), int.Parse(MainTBox.Text)).ToString();
            ATBox.Text = string.Empty;
            MainTBox.Text = result;
        }

        int Solve(char _operator, int val1, int val2)
        {
            if (_operator == '+') return val1 + val2;
            if (_operator == '-') return val1 - val2;
            if (_operator == '*') return val1 * val2;
            if (_operator == '/') return val1 / ((val2 != 0) ? val2 : 1);
            if (_operator == '^') return val1 ^ val2;
            else return 0;
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
