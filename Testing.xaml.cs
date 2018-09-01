using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MindFusion.Diagramming.Wpf.Samples.CS.Anchors
{
    /// <summary>
    /// Lógica de interacción para Testing.xaml
    /// </summary>
    public partial class Testing : Window
    {
        public Circle circleQ0, circleQ1, circleQ2, circleQ3, circleQ4;

        public Circle currentLoop;

        public Testing()
        {
            InitializeComponent();
        }

        private Circle getCorresponding(String s) {
            switch (s) {
                case "q0": return circleQ0;
                case "q1": return circleQ1;
                case "q2": return circleQ2;
                case "q3": return circleQ3;
                case "q4": return circleQ4;
            }

            return null;
        }

        private String getType(String s) {
            Match match = Regex.Match(s, @"[A-Za-z]", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return "letra";
            }

            Match matchNumero = Regex.Match(s, @"[0-9]", RegexOptions.IgnoreCase);
            if (matchNumero.Success)
            {
                return "numero";
            }

            Match matchPlus = Regex.Match(s, @"[+]", RegexOptions.IgnoreCase);
            if (matchPlus.Success)
            {
                return "mas";
            }

            Match matchEqual = Regex.Match(s, @"[=]", RegexOptions.IgnoreCase);
            if (matchEqual.Success)
            {
                return "igual";
            }

            return "invalido";
        }

        public Testing(Circle circleQ0, Circle circleQ1, Circle circleQ2, Circle circleQ3, Circle circleQ4) {
            InitializeComponent();

            this.circleQ0 = circleQ0;
            this.circleQ1 = circleQ1;
            this.circleQ2 = circleQ2;
            this.circleQ3 = circleQ3;
            this.circleQ4 = circleQ4;
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            currentLoop = circleQ0;

            String response = "";

            String chain = chainTextBox.Text;

            String letter = "";

            Circle nextCircle = null;

            int cont = 0;

            String testaRayo = "";

            foreach (char c in chain) {
                letter = c.ToString();

                cont++;

                String resultType = getType(letter);
                String resultStr = "";

                if (resultType.Equals("letra")) {
                    nextCircle = getCorresponding(currentLoop.Letter);
                    resultStr = currentLoop.Letter;

                    Console.WriteLine();

                    testaRayo = testaRayo + "Letra a " + currentLoop.Letter + " \n";
                }
                else if (resultType.Equals("numero"))
                {
                    nextCircle = getCorresponding(currentLoop.Number);
                    resultStr = currentLoop.Number;

                    testaRayo = testaRayo + "Numero a " + currentLoop.Number + " \n";
                }
                else if (resultType.Equals("mas"))
                {
                    nextCircle = getCorresponding(currentLoop.PlusSymbol);
                    resultStr = currentLoop.PlusSymbol;

                    testaRayo = testaRayo + "signo(+) a " + currentLoop.PlusSymbol + " \n";
                }
                else if (resultType.Equals("igual"))
                {
                    nextCircle = getCorresponding(currentLoop.EqualSymbol);
                    resultStr = currentLoop.EqualSymbol;

                    testaRayo = testaRayo + "signo(=) a " + currentLoop.EqualSymbol + " \n";
                }
                else if (resultType.Equals("invalido"))
                {
                    response = "CADENA INVALIDA";

                    testaRayo = testaRayo + "Caracter invalido" + " \n";
                    break;
                }

                if (cont == chain.Length) {
                    if (nextCircle.Fdc.Equals("A") ){
                        response = "CADENA VALIDA";

                        testaRayo = testaRayo +  "CADENA VALIDA \n";
                        break;
                    }
                    else {
                        response = "CADENA INVALIDA";

                        testaRayo = testaRayo + "Caracter invalido \n";
                        break;
                    }

                } 

                if (nextCircle == null && resultStr.Equals("E"))
                {
                    response = "CADENA INVALIDA";

                    testaRayo = testaRayo + "Caracter invalido \n";
                    break;
                } else {
                    currentLoop = nextCircle;
                    continue;
                }

                
            }

            resultLabel.Content = response;
            resultLabel.Visibility = Visibility.Visible;

            MessageBox.Show(testaRayo);
        }
    }
}
