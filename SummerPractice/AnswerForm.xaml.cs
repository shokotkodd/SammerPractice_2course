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
using System.IO;

namespace SummerPractice
{
    /// <summary>
    /// Interaction logic for AnswerForm.xaml
    /// </summary>
    public partial class AnswerForm : Window
    {
        private string path;
        private string name;
        private string[] mas;
        public AnswerForm(string path, string name)
        {
            this.name = name;
            this.path = path;
            
            InitializeComponent();
            SetAll(path);
        }

        private void SetAll(string path)
        {
            string t = path.Remove(path.Length - 7, 7);
            Title = t.Substring(t.Length - 12, 12);

            string s;
            Encoding enc = Encoding.GetEncoding(1251);
            StreamReader sr = new StreamReader(path, enc);
            s = sr.ReadToEnd();
            mas = s.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            sr.Close();

            question1.Content = mas[0];
            if (mas[1][mas[1].Length - 1] == '$')
                q1a1.Content = mas[1].TrimEnd('$');
            else
                q1a1.Content = mas[1];
            if (mas[2][mas[2].Length - 1] == '$')
                q1a2.Content = mas[2].TrimEnd('$');
            else
                q1a2.Content = mas[2];
            if (mas[3][mas[3].Length - 1] == '$')
                q1a3.Content = mas[3].TrimEnd('$');
            else
                q1a3.Content = mas[3];

            question2.Content = mas[4];
            if (mas[5][mas[5].Length - 1] == '$')
                q2a1.Content = mas[5].TrimEnd('$');
            else
                q2a1.Content = mas[5];
            if (mas[6][mas[6].Length - 1] == '$')
                q2a2.Content = mas[6].TrimEnd('$');
            else
                q2a2.Content = mas[6];
            if (mas[7][mas[7].Length - 1] == '$')
                q2a3.Content = mas[7].TrimEnd('$');
            else
                q2a3.Content = mas[7];

            question3.Content = mas[8];
            if (mas[9][mas[9].Length - 1] == '$')
                q3a1.Content = mas[9].TrimEnd('$');
            else
                q3a1.Content = mas[9];
            if (mas[10][mas[10].Length - 1] == '$')
                q3a2.Content = mas[10].TrimEnd('$');
            else
                q3a2.Content = mas[10];
            if (mas[11][mas[11].Length - 1] == '$')
                q3a3.Content = mas[11].TrimEnd('$');
            else
                q3a3.Content = mas[11];

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string f = (new FileInfo(path)).Name;
            StreamWriter wr = new StreamWriter("Answers/" + name + "_" + f.Substring(0, 12) + ".otvet", false);
            if ((bool)q1a1.IsChecked)
            {
                if (mas[1][mas[1].Length - 1] == '$')
                {
                    wr.WriteLine("1$");
                }
                else
                    wr.WriteLine("1");

            }
            if ((bool)q1a2.IsChecked)
            {
                if (mas[2][mas[2].Length - 1] == '$')
                {
                    wr.WriteLine("2$");
                }
                else
                    wr.WriteLine("2");

            }
            if ((bool)q1a3.IsChecked)
            {
                if (mas[3][mas[3].Length - 1] == '$')
                {
                    wr.WriteLine("3$");
                }
                else
                    wr.WriteLine("3");

            }

            if ((bool)q2a1.IsChecked)
            {
                if (mas[5][mas[5].Length - 1] == '$')
                {
                    wr.WriteLine("1$");
                }
                else
                    wr.WriteLine("1");

            }
            if ((bool)q2a2.IsChecked)
            {
                if (mas[6][mas[6].Length - 1] == '$')
                {
                    wr.WriteLine("2$");
                }
                else
                    wr.WriteLine("2");

            }
            if ((bool)q2a3.IsChecked)
            {
                if (mas[7][mas[7].Length - 1] == '$')
                {
                    wr.WriteLine("3$");
                }
                else
                    wr.WriteLine("3");

            }

            if ((bool)q3a1.IsChecked)
            {
                if (mas[9][mas[9].Length - 1] == '$')
                {
                    wr.WriteLine("1$");
                }
                else
                    wr.WriteLine("1");

            }
            if ((bool)q3a2.IsChecked)
            {
                if (mas[10][mas[10].Length - 1] == '$')
                {
                    wr.WriteLine("2$");
                }
                else
                    wr.WriteLine("2");

            }
            if ((bool)q3a3.IsChecked)
            {
                if (mas[11][mas[11].Length - 1] == '$')
                {
                    wr.WriteLine("3$");
                }
                else
                    wr.WriteLine("3");
            }
            wr.Close();
            Close();
        }
    }
}
