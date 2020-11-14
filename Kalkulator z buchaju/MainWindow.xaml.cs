using System;
using System.Collections.Generic;
using System.Data.Common;
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

namespace Kalkulator_z_buchaju
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected int leftBracketsCounter = 0;
        protected int rightBracketsCounter = 0;
        protected string actualOperation = "";
        protected Boolean isBracketUsed = false;
        protected readonly HashSet<String> OPERATORS = new HashSet<string>(new string[] {"+","-","x","/" });
        protected Queue<String> operations = new Queue<string>(100);
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void digitButtonClick(object sender, RoutedEventArgs e)
        {
            resultBox.Text = resultBox.Text.Equals("0") ? (String)((Button) sender).Content : String.Concat(resultBox.Text, (String)((Button) sender).Content);
            actualOperation = actualOperation.Equals("0") ? (String)((Button)sender).Content : String.Concat(actualOperation, (String)((Button)sender).Content);
        }

        private void operatorButtonClick(object sender, RoutedEventArgs e)
        {
            //if(resultBox.Text[resultBox.Text.Length - 1])
        }

        private void checkBoxChecked(object sender, RoutedEventArgs e)
        {
            historyBox.Visibility = Visibility.Visible;
        }

        private void checkBoxUnchecked(object sender, RoutedEventArgs e)
        {
            historyBox.Visibility = Visibility.Hidden;
        }

        private void historyBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

       
    }
}
