using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using ToolBox;

namespace ToolWindow1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewTopThing(object sender, RoutedEventArgs e)
        {
            var a = new KeepOnTop(true);
            a.Height = 70;
            a.Width = 1600;
            a.Show();
        }

        private void NewBackgroundThing(object sender, RoutedEventArgs e)
        {
            var a = new KeepOnTop(false);
            a.Height = 70;
            a.Width = 1600;
            a.Show();
        }

        private void RecordWords(object sender, RoutedEventArgs e)
        {
            var a = new OpenFileDialog();
            a.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            a.InitialDirectory = @"c:\temp\";
            a.ShowDialog();
            var b = new GetWordsInText(a.FileName);
            MessageBox.Show(b.words.Count.ToString());
            Task task = WriteFileLine(b.words);
        }

        public static async Task WriteFileLine(HashSet<string> lines)
        {
            await File.WriteAllLinesAsync("WriteLines.txt", lines);
        }

        private void BMICalculator(object sender, RoutedEventArgs e)
        {
            var a = new BMIcalculator();
            a.Height = 250;
            a.Width = 250;
            a.Show();
        }

        private void TranslateWords(object sender, RoutedEventArgs e)
        {
            Translator translator = new Translator();
            var a = new OpenFileDialog();
            a.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            a.InitialDirectory = @"c:\temp\";
            a.ShowDialog();
            var b = new GetWordsInText(a.FileName);
            string[] chinesesmeaning = new string[b.words.Count];
            int num = 0;
            foreach (string i in b.words)
            {
                chinesesmeaning[num] = (translator.GetTranslate(i));
                num++;
            }
            String[] stringArray = new String[b.words.Count];
            b.words.CopyTo(stringArray);
            new WriteToExcel(stringArray, chinesesmeaning);
        }

        private void FunctionAlarm(object sender, RoutedEventArgs e)
        {
            var a = new BMIcalculator();
            a.Height = 250;
            a.Width = 250;
            a.Show();
        }
    }
}