using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace TextEditorWPF
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            bool? res = saveFile.ShowDialog();

            if (res != false)
            {
                using (Stream s = File.Open(saveFile.FileName, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(textBox.Text);
                    }
                }
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            bool? res = openFile.ShowDialog();
            if (res != false)
            {
                if ((_ = openFile.OpenFile()) != null)
                {
                    textBox.Text = File.ReadAllText(openFile.FileName);
                }
            }
        }

        private void timesNewRomanFont_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontFamily = new FontFamily("Times New Roman");
            verdanaFont.IsChecked = false;
        }

        private void verdanaFont_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontFamily = new FontFamily("Verdana");
            timesNewRomanFont.IsChecked = false;
        }

        private void selectFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var fontSize = selectFontSize.SelectedItem.ToString();
            string fontSizeString = fontSize.Substring(fontSize.Length - 2);
            try
            {
                textBox.FontSize = double.Parse(fontSizeString);
            }
            catch { }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "")
                SaveFile();
            textBox.Text = "";
        }

        private void applyButton_Click(object sender, RoutedEventArgs e)
        {
            string Login = loginField.Text;
            string Password = passwordField.Password;

            using (UserDataContext context = new UserDataContext())
            {
                bool userfound = context.Users.Any(user => user.Login == Login && user.Password == Password);

                if (userfound)
                {
                    MessageBox.Show("User is exist. You can use Editor.");
                }
                else
                {
                    MessageBox.Show("User not found. You can try (admin admin).");
                }
            }
        }
    }
}
