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

namespace DataBinding_HomeWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertData(object sender, RoutedEventArgs e)
        {
            string date = dateText.Text;
            try
            {
                var convertedDate = Convert.ToDateTime(date);
                convertedBlock.Text = convertedDate.ToString();
            }
            catch(FormatException)
            {
                MessageBox.Show("Некорректный формат!!!");
            }
        }

        private void ConvertBack(object sender, RoutedEventArgs e)
        {
            string date = dateText.Text;

            var parsedDate = date.Split('.',' ');
            if(parsedDate.Count() < 3)
            {
                MessageBox.Show("Некорректный формат!!!");
                return;
            }
            convertedBlock.Text = parsedDate[0] + " " + parsedDate[1] + " " + parsedDate[2];
        }
    }
}
