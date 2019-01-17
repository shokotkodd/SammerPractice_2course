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
    /// Interaction logic for LectureForm.xaml
    /// </summary>
    public partial class LectureForm : Window
    {
        string path;
        public LectureForm()
        {
            InitializeComponent();
            string names;
            StreamReader sr = new StreamReader("Students.txt");
            names = sr.ReadToEnd();
            sr.Close();
            string[] mas = names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < mas.Length; i++)
            {
                ListBox.Items.Add(mas[i]);
            }
        }
        private void Button_Click_Gen(object sender, RoutedEventArgs e)
        {
            if (top.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тему!!!", "", MessageBoxButton.OK);
                return;
            }
            path = "Topics/Topic" + Convert.ToString(top.SelectedIndex + 1) + ".txt";
            DirectoryInfo di = new DirectoryInfo("Cards/");
            int kol = 0;
            foreach (var fi in di.GetFiles(String.Format("Topic{0}_card?.Topic{0}", top.SelectedIndex + 1)))
            {
                kol++;
            }
            for (int i = 1; i <= Convert.ToInt32(bil.Value); i++)
            {
                genCard(path, top.SelectedIndex + 1, i + kol);
            }
            MessageBox.Show(String.Format("Сгенерировано {0} билетов по теме №{1}", Convert.ToInt32(bil.Value), top.SelectedIndex + 1), "", MessageBoxButton.OK);

        }


        private void genCard(string p, int top, int q)
        {
            Encoding enc = Encoding.GetEncoding(1251);
            StreamReader sr = new StreamReader(p, enc);
            int count = 0;
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                count++;

            }
            sr.Close();
            int[] mas = new int[3];
            Random r = new Random();
            //чтоб не повторялись
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = r.Next(count / 4);
                for (int j = 0; j < i; j++)
                {
                    if (mas[j] == mas[i])
                    {
                        i--;
                    }

                }
            }
            Array.Sort(mas);
            string[] strmas = new string[count];
            StreamReader sr1 = new StreamReader(p, enc);
            count = 0;
            while (!sr1.EndOfStream)
            {
                strmas[count] = sr1.ReadLine();
                count++;
            }
            sr1.Close();
            string[,] finalmas = new string[3, 4];
            for (int j = 0; j < 3; j++)
            {
                finalmas[j, 0] = strmas[mas[j] * 4];
                finalmas[j, 1] = strmas[mas[j] * 4 + 1];
                finalmas[j, 2] = strmas[mas[j] * 4 + 2];
                finalmas[j, 3] = strmas[mas[j] * 4 + 3];

            }

            StreamWriter sw = new StreamWriter(String.Format("Cards/Topic{0}_card{1}.Topic{0}", top, q), false, enc);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                {
                    sw.WriteLine(finalmas[i, j]);
                }
            sw.Close();

        }

        private void Button_Click_Prov(object sender, RoutedEventArgs e)
        {
            string name = (string)ListBox.SelectedItem;
            if(name==null)
            {
                MessageBox.Show("Выберите cтудента!!!", "", MessageBoxButton.OK);
                return;
            }
            DirectoryInfo d = new DirectoryInfo("Answers/");
            FileInfo[] mas = d.GetFiles(name + "*.otvet");
            int resoult = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                string res;
                StreamReader r = new StreamReader(mas[i].FullName);
                res = r.ReadToEnd();
                r.Close();
                string[] mres = res.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < 3; j++)
                {
                    if (mres[j][mres[j].Length - 1] == '$')
                        resoult += 3;
                }

            }
            string allres = String.Format(
                    "Студент {0} ответил на {1} билет(-ов) и набрал {2} балла(-ов) (один правильный ответ - 3 балла)", name, mas.Length, resoult);
            MessageBox.Show(allres, "", MessageBoxButton.OK);

            int count = 0;

            StreamReader sr = new StreamReader("Marks.txt");
            string str;
            str = sr.ReadToEnd();
            sr.Close();
            string[] usersres = str.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            int nom = usersres.Length;
            for (int i = 0; i < usersres.Length; i++)
            {
                if (usersres[i].Split(new[] { ' ' })[1] == name)
                {
                    count++; nom = i;
                }
            }

            if (count == 0)
            {
                StreamWriter sw = new StreamWriter("Marks.txt", true);
                sw.WriteLine(allres);
                sw.Close();
            }
            if (count != 0)
            {
                usersres[nom] = allres;
                StreamWriter sw = new StreamWriter("Marks.txt");
                for (int i = 0; i < usersres.Length; i++)
                {
                    sw.WriteLine(usersres[i]);
                }
                sw.Close();
            }

        }

    }
}
