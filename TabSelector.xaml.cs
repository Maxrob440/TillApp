using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TillApp
{
    /// <summary>
    /// Interaction logic for TabSelector.xaml
    /// </summary>
    public partial class TabSelector : Window
    {
        public TabSelector()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Page Loaded");
            List<int> tabs = TabHelper.Instance.get_tabIds();
            Dictionary<int, List<List<int>>> current_order = TabHelper.Instance.get_tabs();
            tablistbox.Items.Clear();

            foreach(KeyValuePair<int,List<List<int>>> entry in current_order)
            {
                double total = 0;
                foreach (List<int> transaction in entry.Value)
                {
                    int ItemId = transaction[0];
                    int Quantity = transaction[1];
                    float Price = DataBaseHelper.Instance.get_price_from_itemID(ItemId);
                    total += Price * Quantity;
                }
                tablistbox.Items.Add($"Tab {entry.Key} - Total: £{total}");
            }
        }

        private void new_tab(object sender, RoutedEventArgs e)
        {
            TabHelper.Instance.new_tab();
            Page_Loaded(sender, e);
        }

        private void pay(object sender, RoutedEventArgs e)
        {
            int selected_tab = tablistbox.SelectedIndex;
            if (selected_tab == -1)
            {
                return;
            }
            List<List<int>> current_order = TabHelper.Instance.get_tabs()[selected_tab];
            foreach (List<int> tab in current_order) {
                Current_order.Instance.add_item(tab[0], tab[1]);
        }
            Current_order.Instance.pay_order();
            TabHelper.Instance.get_tabs().Remove(selected_tab);
            this.Close();


        }

        private void add_to_tab(object sender, RoutedEventArgs e)
        {
            int selected_tab = tablistbox.SelectedIndex;
            List<List<int>> items = Current_order.Instance.get_current();
            foreach(List<int> item in items)
            {
                TabHelper.Instance.add_item(selected_tab, item[0], item[1]);
            }
            Current_order.Instance.get_current().Clear();
            //int item = int.Parse(Current_order.Instance.get_current());
            Page_Loaded(sender, e);

        }

        private void save(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
