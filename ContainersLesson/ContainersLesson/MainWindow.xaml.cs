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
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ContainersLesson
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ShowWeather(object sender, RoutedEventArgs e)
        {
            InitializeComponent();

            ComboBoxItem item = Days.SelectedItem as ComboBoxItem;
            string dayStr = item.ToString();
            string withoutLetters = Regex.Replace(dayStr, "[A-Za-zА-Яа-я]", "").Replace(".", "").Replace(":", "").Trim();

            WebClient client = new WebClient();
            var strLocation = (client.DownloadString(@"http://dataservice.accuweather.com/locations/v1/cities/search?apikey=UN1AkqVicgi5pDmT7pfLiAegW2sce9hq&q=" + City.Text +"&language=ru"));
            var location = JsonConvert.DeserializeObject<List<Location>>(strLocation);
                      
            var result= client.DownloadString(@"http://dataservice.accuweather.com/forecasts/v1/daily/"+ withoutLetters + "day/"+location[0].Key+ "?apikey=UN1AkqVicgi5pDmT7pfLiAegW2sce9hq&language=en-us");
            var wheather = JsonConvert.DeserializeObject<ForeCast>(result);
                listBox1.Items.Clear();

            for(int i = 0;i < wheather.DailyForecasts.Count; i++)
            {
                string workingDirectory = Environment.CurrentDirectory;

                ListBox mainTextBox = new ListBox()
                {                   
                    Width = listBox1.Width/3,
                    Height = listBox1.Height,
                    Margin = new Thickness(50,100, 0, 0),                                        
                    Name = "wheather" + i,                    
                };

                

                StackPanel stackPanel1 = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Width = mainTextBox.Width,
                    Height = mainTextBox.Height/3
                };

                StackPanel stackPanel2 = new StackPanel()
                {
                    Orientation = Orientation.Horizontal,
                    Width = mainTextBox.Width,
                    Height = mainTextBox.Height / 3
                };


                TextBox textBox1 = new TextBox()
                {
                    Height = mainTextBox.Height / 3,
                    Width = mainTextBox.Width,
                    TextAlignment = TextAlignment.Center,
                    Text = City.Text + " (" + wheather.DailyForecasts[i].Date + ")\nМинимальная температура: " + wheather.DailyForecasts[i].Temperature.Minimum.Value + "\nМаксимальная температура: " + wheather.DailyForecasts[i].Temperature.Maximum.Value,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Top
                };



                //")\n\nУтром: " + wheather.DailyForecasts[i].Day.IconPhrase + " число:\n\nНочью: " + wheather.DailyForecasts[i].Night.IconPhrase + "\n\nМинимальная температура воздуха : " + wheather.DailyForecasts[i].Temperature.Minimum.Value + " градусов\n\nМаксимальная температура воздуха: " + wheather.DailyForecasts[i].Temperature.Maximum.Value + " градусов",
                TextBox textBox2 = new TextBox()
                {
                    Height = stackPanel1.Height,
                    Width = stackPanel1.Width / 2,
                    TextAlignment = TextAlignment.Center,
                    Text = "Утром: " + wheather.DailyForecasts[i].Day.IconPhrase,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,


                };

                TextBox textBox3 = new TextBox()
                {
                    Height = stackPanel2.Height,
                    Width = stackPanel2.Width / 2,
                    TextAlignment = TextAlignment.Center,
                    Text = "Ночью: " + wheather.DailyForecasts[i].Night.IconPhrase,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };

                Image img = new Image()
                {
                    Source = new BitmapImage(new Uri(workingDirectory + "/Icons/" + wheather.DailyForecasts[i].Day.Icon + ".png")),
                    Height = stackPanel1.Height,
                    Width = stackPanel1.Width / 2,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                };

                Image img2 = new Image()
                {
                    Source = new BitmapImage(new Uri(workingDirectory + "/Icons/" + wheather.DailyForecasts[i].Night.Icon + ".png")),
                    Height = stackPanel2.Height,
                    Width = stackPanel2.Width / 2,
                    VerticalAlignment = VerticalAlignment.Top,
                    HorizontalAlignment = HorizontalAlignment.Left,
                };

                stackPanel1.Children.Add(textBox2);
                stackPanel1.Children.Add(img);

                stackPanel2.Children.Add(textBox3);
                stackPanel2.Children.Add(img2);

                mainTextBox.Items.Add(textBox1);
                mainTextBox.Items.Add(stackPanel1);
                mainTextBox.Items.Add(stackPanel2);
                listBox1.Items.Add(mainTextBox);
                
                

            }

        }
    }
}
