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
using System.Diagnostics;


namespace TillApp
{
    /// <summary>
    /// Interaction logic for Drinks.xaml
    /// </summary>
    public partial class Drinks : Page
    {
        public Drinks()
        {
            InitializeComponent();
            for (int i = 1; i<=10; i++)
            {
                ItemComboBox.Items.Add(i);
            }
            ItemComboBox.SelectedIndex = 0;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Page Loaded");
            List<List<int>> current_order = Current_order.Instance.get_current();
            //List<string> transactions = DataBaseHelper.Instance.getTransactions();
            transactionlistbox.Items.Clear();
            foreach (List<int> transaction in current_order)
            {
                int ItemId = transaction[0];
                int Quantity = transaction[1];
                string ItemName = DataBaseHelper.Instance.get_name_from_itemID(ItemId);
                float Price = DataBaseHelper.Instance.get_price_from_itemID(ItemId);
                float total_price = Price * Quantity;
                string ToAdd = $"{ItemName} - {Quantity} = £{total_price}";
                transactionlistbox.Items.Add(ToAdd);


            }
            totalpricetextbox.Text = $"Total Price: £{Current_order.Instance.total_price()}";
        }

        private void beer(object sender, RoutedEventArgs e)
        {
            int quantity = (int)ItemComboBox.SelectedItem;
            Current_order.Instance.add_item(1, quantity);
            ItemComboBox.SelectedIndex = 0;
            Page_Loaded(sender, e);


        }

        private void coke(object sender, RoutedEventArgs e)
        {
            int quantity = (int)ItemComboBox.SelectedItem;

            Current_order.Instance.add_item(2, quantity);
            ItemComboBox.SelectedIndex = 0;
            Page_Loaded(sender, e);
        }

        private void pay(object sender, RoutedEventArgs e)
        {
            ConfirmationDialog dialog = new ConfirmationDialog();
            dialog.ShowDialog();
            MessageBoxResult result = dialog.Result;
            if (result == MessageBoxResult.Yes)
            {
                Current_order.Instance.pay_order();
                Page_Loaded(sender, e);
            }
            Page_Loaded(sender, e);

        }
        private void removeitem(object sender, RoutedEventArgs e)
        {
            if (transactionlistbox.SelectedIndex != -1)
            {
                int index = transactionlistbox.SelectedIndex;
                Current_order.Instance.remove_item(index);
                Debug.WriteLine(Current_order.Instance.get_current());
                Debug.WriteLine(Current_order.Instance.total_price());
                Page_Loaded(sender, e);
            }
        }

        private void home(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FoodDrinks());

        }
    }
}
