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
using WpfApp7.ViewModel;
using WpfApp7.Model;


namespace WpfApp7.View
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        BitmapImage bitim = new BitmapImage();
       public Product pr { get; set; }
        public Window1()
        {
            InitializeComponent();
        }

      public Window1(Product sendpr):this()
        {
            pr = sendpr;
            name.Text = pr.Name;
            cod.Text = pr.Cod;
            price.Text = Convert.ToString(pr.Price);
            pathim.Text = pr.Image;
            bitim.BeginInit();
            bitim.UriSource = new Uri(pathim.Text);
            bitim.DecodePixelWidth = 550;
            bitim.EndInit();
            image.Source = bitim;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
