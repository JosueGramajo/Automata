using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Lógica de interacción para ChartWindow.xaml
    /// </summary>
    public partial class ChartWindow : Window
    {
        Circle q0, q1, q2, q3, q4;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            getChartInfo();

            Testing t = new Testing(q0, q1, q2, q3, q4);
            t.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getChartInfo();

            MainWindow w = new MainWindow(q0, q1, q2, q3, q4);
            //w.circleQ0 = q0;
            w.Show();
        }

        private void getChartInfo() {
            q0 = new Circle();
            q0.Letter = q0Letter.SelectedItem.ToString();
            q0.Number = q0Number.SelectedItem.ToString();
            q0.PlusSymbol = q0Plus.SelectedItem.ToString();
            q0.EqualSymbol = q0Equal.SelectedItem.ToString();
            q0.Fdc = q0Fdc.SelectedItem.ToString();

            q1 = new Circle();
            q1.Letter = q1Letter.SelectedItem.ToString();
            q1.Number = q1Number.SelectedItem.ToString();
            q1.PlusSymbol = q1Plus.SelectedItem.ToString();
            q1.EqualSymbol = q1Equal.SelectedItem.ToString();
            q1.Fdc = q1Fdc.SelectedItem.ToString();

            q2 = new Circle();
            q2.Letter = q2Letter.SelectedItem.ToString();
            q2.Number = q2Number.SelectedItem.ToString();
            q2.PlusSymbol = q2Plus.SelectedItem.ToString();
            q2.EqualSymbol = q2Equal.SelectedItem.ToString();
            q2.Fdc = q2Fdc.SelectedItem.ToString();

            q3 = new Circle();
            q3.Letter = q3Letter.SelectedItem.ToString();
            q3.Number = q3Number.SelectedItem.ToString();
            q3.PlusSymbol = q3Plus.SelectedItem.ToString();
            q3.EqualSymbol = q3Equal.SelectedItem.ToString();
            q3.Fdc = q3Fdc.SelectedItem.ToString();

            q4 = new Circle();
            q4.Letter = q4Letter.SelectedItem.ToString();
            q4.Number = q4Number.SelectedItem.ToString();
            q4.PlusSymbol = q4Plus.SelectedItem.ToString();
            q4.EqualSymbol = q4Equal.SelectedItem.ToString();
            q4.Fdc = q4Fdc.SelectedItem.ToString();
        }

        List<string> defaultDataSource = new List<string>();
        List<string> fdcDataSource = new List<string>();

        public ChartWindow()
        {
            InitializeComponent();

            defaultDataSource.Add("q0");
            defaultDataSource.Add("q1");
            defaultDataSource.Add("q2");
            defaultDataSource.Add("q3");
            defaultDataSource.Add("q4");
            defaultDataSource.Add("E");

            fdcDataSource.Add("A");
            fdcDataSource.Add("E");

            q0Letter.ItemsSource = defaultDataSource;
            q0Number.ItemsSource = defaultDataSource;
            q0Equal.ItemsSource = defaultDataSource;
            q0Plus.ItemsSource = defaultDataSource;
            q0Fdc.ItemsSource = fdcDataSource;

            q1Letter.ItemsSource = defaultDataSource;
            q1Number.ItemsSource = defaultDataSource;
            q1Equal.ItemsSource = defaultDataSource;
            q1Plus.ItemsSource = defaultDataSource;
            q1Fdc.ItemsSource = fdcDataSource;

            q2Letter.ItemsSource = defaultDataSource;
            q2Number.ItemsSource = defaultDataSource;
            q2Equal.ItemsSource = defaultDataSource;
            q2Plus.ItemsSource = defaultDataSource;
            q2Fdc.ItemsSource = fdcDataSource;

            q3Letter.ItemsSource = defaultDataSource;
            q3Number.ItemsSource = defaultDataSource;
            q3Equal.ItemsSource = defaultDataSource;
            q3Plus.ItemsSource = defaultDataSource;
            q3Fdc.ItemsSource = fdcDataSource;

            q4Letter.ItemsSource = defaultDataSource;
            q4Number.ItemsSource = defaultDataSource;
            q4Equal.ItemsSource = defaultDataSource;
            q4Plus.ItemsSource = defaultDataSource;
            q4Fdc.ItemsSource = fdcDataSource;
        }


    }
}
