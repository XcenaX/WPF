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
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace DataBinding
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShopContext context = new ShopContext();

        public MainWindow()
        {
            InitializeComponent();
            using(var context = new ShopContext())
            {
                usersDataGrid.ItemsSource = context.Goods.ToList();
                
                usersDataGrid.RowEditEnding += UsersDataGridRowEditEnding;
            }
        }

        private void UsersDataGridRowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            var item = (e.Row.DataContext as Good);

            context.Goods.Add(item);
            context.SaveChanges();

        }

        private void AddNewItemButtonClick(object sender, RoutedEventArgs e)
        {
          
        }

    }
}
