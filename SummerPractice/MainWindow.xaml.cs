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

namespace SummerPractice
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pwdBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (pwdBox.Password == "123456")
                {
                    LectureForm t = new LectureForm();
                    t.Show();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void studBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (studBox.Text.Length > 1)
                {
                    MessageBox.Show("Ваша фамилия:" + studBox.Text, "Приветствие", MessageBoxButton.OK);
                    StudentForm m = new StudentForm(studBox.Text);
                    m.Show();
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}

