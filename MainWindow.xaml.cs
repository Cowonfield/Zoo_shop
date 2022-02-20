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
using WpfApp7.ViewModel;
using WpfApp7.Model;
using Infralution.Localization.Wpf;
using System.Globalization;
namespace WpfApp7.View

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
       

        private void Button_Click(object sender, RoutedEventArgs e)

        {
            if (list.SelectedItem != null)
            {
                Product pr = list.SelectedItem as Product;
                Window1 win = new Window1(pr);
                win.Show();
                this.Close();
            }
            else
                MessageBox.Show("Chose item!");
        }

        private void BattonBase_OnClick(object sender, RoutedEventArgs e)
        {
            CultureManager.UICulture = new CultureInfo("ru-Ru");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CultureManager.UICulture = new CultureInfo("en");
        }
    }
}
