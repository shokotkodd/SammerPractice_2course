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
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace SummerPractice
{
    /// <summary>
    /// Interaction logic for StudentForm.xaml
    /// </summary>
    public partial class StudentForm : Window
    {
        private string studentName;
        public StudentForm(string name)
        {
            studentName = name.ToLower();
            int count = 0;
            InitializeComponent();
            StreamReader sr = new StreamReader(@"Students.txt");
            while(!sr.EndOfStream)
            {
                if (sr.ReadLine().ToLower() == studentName) count++;
            }
            sr.Close();
            if (count == 0)
            {
                StreamWriter sw = new StreamWriter(@"Students.txt", true);
                sw.WriteLine(studentName);
                sw.Close();
            }
        }

        private void Topic_Click(object sender, RoutedEventArgs e)
        {
            Topic1.IsChecked = false;
            Topic2.IsChecked = false;
            Topic3.IsChecked = false;
            ((MenuItem)sender).IsChecked = true;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            string filter = "";
            if (Topic1.IsChecked)
                filter = "Тема 1 (*.Topic1)|*.Topic1";

            if (Topic2.IsChecked)
                filter = "Тема 2 (*.Topic2)|*.Topic2";

            if (Topic3.IsChecked)
                filter = "Тема 3 (*.Topic3)|*.Topic3";
            OpenFileDialog f = new OpenFileDialog();
            f.InitialDirectory = "Cards";
            f.Filter = filter;
            if (f.ShowDialog() == true)
            {
                AnswerForm a = new AnswerForm(f.FileName, studentName);
                a.Show();
            }
        }
    }
}
