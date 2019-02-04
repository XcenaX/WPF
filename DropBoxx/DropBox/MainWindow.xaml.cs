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
using Dropbox.Api;
using System.Net.Http;

namespace DropBox
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string ACCESS_TOKEN = "qdtrasBv5sAAAAAAAAAADEh7RgD4U3xQiBGCEK52WgCGCxxvU_xLffpN0TixaXiP";
        public MainWindow()
        {
            InitializeComponent();
            dropBoxData.ShowGridLines = true;
        }

        //"qdtrasBv5sAAAAAAAAAADEh7RgD4U3xQiBGCEK52WgCGCxxvU_xLffpN0TixaXiP"

        private void Run(object sender, RoutedEventArgs e)
        {
            Run();
        } 

        public async void Run() {
            var dbx = new DropboxClient(ACCESS_TOKEN);
                        
            await ListRootFolder(dbx);
            
        }

        async Task ListRootFolder(DropboxClient dbx)
        {
            var button = dropBoxData.Children[dropBoxData.Children.Count - 1];
            dropBoxData.Children.Clear();
            
            var list = await dbx.Files.ListFolderAsync(string.Empty);

            // show folders then files
            int rowsCount = dropBoxData.ColumnDefinitions.Count;
            int columnsCount = dropBoxData.ColumnDefinitions.Count;
            int column = 0, row = 0;

        
            foreach (var item in list.Entries.Where(i => i.IsFolder))
            {
                var textBlock = new TextBlock()
                {
                    Text = "\nИмя: " + item.Name + "\n"                    
                };

                dropBoxData.Children.Add(textBlock);
                Grid.SetRow(textBlock, row);
                Grid.SetColumn(textBlock, column);



                column++;
                if(column > columnsCount) { column = 0; row++; }
            }


            foreach (var item in list.Entries.Where(i => i.IsFile))
            {

                var stackPanel = new StackPanel()
                {

                };

                var textBlock = new TextBlock()
                {
                    Text = "\nРазмер: " + item.AsFile.Size + "\nИмя : " + item.Name + "\n" ,
                    TextAlignment = TextAlignment.Left
                };
                var hiddenTextBlock = new TextBlock()
                {
                    Text = item.PathDisplay,
                    Visibility = Visibility.Collapsed
                };
                var downloadButton = new Button()
                {
                    Content = "Скачать",
                    Width = 100,
                    Height = 40,
                    HorizontalAlignment= HorizontalAlignment.Center,                    
                };
                downloadButton.Click += DownloadFile;

                stackPanel.Children.Add(textBlock);
                stackPanel.Children.Add(hiddenTextBlock);
                stackPanel.Children.Add(downloadButton);

                dropBoxData.Children.Add(stackPanel);

                Grid.SetRow(stackPanel, row);
                Grid.SetColumn(stackPanel, column);
                column++;
                if (column > columnsCount) { column = 0; row++; }

            }
            dropBoxData.Children.Add(button);
        }

        async private void DownloadFile(object sender, RoutedEventArgs e)
        {
            var dbx = new DropboxClient(ACCESS_TOKEN);
            string path = ((((sender as Button).Parent) as StackPanel).Children[1] as TextBlock).Text; // путь указан правильно но он не скачивает
            await Download(dbx,path);
        }


        async Task Download(DropboxClient dbx, string path)
        {
            using (var response = await dbx.Files.DownloadAsync(path))
            {
                Console.WriteLine(await response.GetContentAsStringAsync());
            }
        }

    }
}
