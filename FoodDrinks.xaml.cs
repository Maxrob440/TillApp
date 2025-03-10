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

namespace TillApp
{
    /// <summary>
    /// Interaction logic for FoodDrinks.xaml
    /// </summary>
    public partial class FoodDrinks : Page
    {
        public FoodDrinks()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void viewFood(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Food());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Drinks());
        }

        private void Pay(object sender, RoutedEventArgs e)
        {
            Current_order.Instance.pay_order();


        }
    }
}
