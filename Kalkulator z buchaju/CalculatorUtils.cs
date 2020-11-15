using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator_z_buchaju
{
    
    
    



    class CalculatorUtils
    {

        public static double kalkulacja(string[] operation)
        {
            double left, right = 0.0d;
            if(String.IsNullOrEmpty(operation[1]))
                return 0.0d;
            if (!Double.TryParse(operation[0], out left))
                return 0.0d;
            if (!operation[1].Equals("EXP"))
                if (!Double.TryParse(operation[2], out right))
                    return 0.0d;

            switch (operation[1])
            {
                case "M":
                    return left * right;
                case "D":
                    return left / right;
                case "N":
                    return Math.Pow(left, right);
                case "P":
                    return left + right;
                case "S":
                    return left - right;
                case "R":
                    return Math.Pow(left, 1 / right);
                case "EXP":
                    return Math.Exp(left);
                case "LOG":
                    return Math.Log(left, right);
            }

            return 0.0d;
        }


        public static void dodajDoHistorii(System.Windows.Controls.ListBox calculationHistoryBox, string wynik)
        {
            if (calculationHistoryBox.Items.Count == 100)
                calculationHistoryBox.Items.Clear();

            calculationHistoryBox.Items.Add(wynik);
        }
    }
}
