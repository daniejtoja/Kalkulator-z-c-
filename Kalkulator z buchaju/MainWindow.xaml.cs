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
    public partial class MainWindow
    {
        
        protected bool isOperatorUsed = false;
        protected bool justUsedEquals = false;
        protected bool digitPressed = false;
        protected bool changedOperator = false;
        protected bool isOperatorLocked = false;
        protected string[] operation = new string[3];
        protected string[] lastOperation = new string[3];

        delegate double DelegateCalc(string[] ops);
        delegate void DelegateHistory(System.Windows.Controls.ListBox listBox, string toAdd);
        DelegateCalc handleOperations = CalculatorUtils.kalkulacja;
        DelegateHistory handleAddToHistory = CalculatorUtils.dodajDoHistorii;
        Button clickedButton = new Button();


        public MainWindow()
        {
            InitializeComponent();
            operation[0] = "0";
            operation[1] = CalculatorConstants.EMPTY_STRING;
            operation[2] = CalculatorConstants.EMPTY_STRING;
        }

        private void digitButtonClick(object sender, RoutedEventArgs e)
        {
            if ((operation[1].Contains(".") || operation[2].Contains(".") || resultBox.Text.Contains(".")) && ((String)((Button)sender).Content).Equals("."))
                return;

            if (justUsedEquals)
            {
                resultBox.Text = (String)((Button)sender).Content;

                operation[2] = resultBox.Text;
                justUsedEquals = false;
            }
            else
            {

                resultBox.Text = resultBox.Text.Equals("0") ? (String)((Button)sender).Content : String.Concat(resultBox.Text, (String)((Button)sender).Content);

                if (!isOperatorUsed)
                    operation[0] = operation[0].Equals("0") ? (String)((Button)sender).Content : String.Concat(operation[0], (String)((Button)sender).Content);
                else
                    operation[2] = operation[2].Equals("0") ? (String)((Button)sender).Content : String.Concat(operation[2], (String)((Button)sender).Content);


            }
            digitPressed = true;
                

            
        }

        private void operatorButtonClick(object sender, RoutedEventArgs e)
        {
            if (!isOperatorLocked)
            {
                if (!isOperatorUsed)
                {
                    operation[1] = ((Button)sender).Name;
                    resultBox.Text = CalculatorConstants.EMPTY_STRING;
                    if (((Button)sender).Name.Equals("EXP"))
                        resultButtonClick(sender, e);
                    isOperatorUsed = true;
                }
                else
                {
                    if (justUsedEquals)
                    {
                        operation[1] = ((Button)sender).Name;
                        resultBox.Text = CalculatorConstants.EMPTY_STRING;
                        operation[2] = CalculatorConstants.EMPTY_STRING;
                    }
                    
                }
                digitPressed = false;
                isOperatorLocked = true;
                ((Button)sender).Background = SystemParameters.WindowGlassBrush;
                clickedButton = ((Button)sender);
            } 





           
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

        private void resultButtonClick(object sender, RoutedEventArgs e)
        {

            if (digitPressed && justUsedEquals)
            {
                resultBox.Text = operation[0];
                operation[2] = lastOperation[2];
                return;
            }
                

            operation[0] = handleOperations(operation).ToString();

            resultBox.Text = operation[0];
            if (!(resultBox.Text.Equals(CalculatorConstants.EMPTY_STRING) || resultBox.Text.Equals("0")))
                handleAddToHistory(historyBox, resultBox.Text);
            justUsedEquals = true;
            Array.Copy(operation, lastOperation, operation.Length);
            digitPressed = false;
            isOperatorLocked = false;
            clickedButton.Background = RES.Background;






           
        }

        private void clearButtonClick(object sender, RoutedEventArgs e)
        {
            
          
            if (!isOperatorUsed)
                operation[0] = CalculatorConstants.EMPTY_STRING;
            else
                operation[2] = CalculatorConstants.EMPTY_STRING;

            if(justUsedEquals && isOperatorUsed)
                operation[2] = CalculatorConstants.EMPTY_STRING;
            else if(justUsedEquals && !isOperatorUsed)
                operation[0] = CalculatorConstants.EMPTY_STRING;

            resultBox.Text = CalculatorConstants.EMPTY_STRING;
            justUsedEquals = false;
        }

        private void deleteAllButtonClick(object sender, RoutedEventArgs e)
        {
            
            resultBox.Text = CalculatorConstants.EMPTY_STRING;
            operation[0] = CalculatorConstants.EMPTY_STRING;
            operation[1] = CalculatorConstants.EMPTY_STRING;
            operation[2] = CalculatorConstants.EMPTY_STRING;
            clickedButton.Background = RES.Background;
            isOperatorUsed = false;
            justUsedEquals = false;
            isOperatorLocked = false;
        }

        private void clearHistoryButtonClick(object sender, RoutedEventArgs e)
        {
            historyBox.Items.Clear();
        }
    }
}
