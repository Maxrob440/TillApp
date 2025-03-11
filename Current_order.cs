using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TillApp
{
    class Current_order
    {
        public static Current_order _instance;

        private Current_order() { }

        public static Current_order Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Current_order();
                }
                return _instance;
            }
        }
        List<List<int>> current_order = new List<List<int>>();

        public void add_item(int item, int quant)
        {
            List<int> One_item = new List<int>();
            One_item.Add(item);
            One_item.Add(quant);
            current_order.Add(One_item);
        }
        public void remove_item(int index) //Removes item from list based on index
        {
            current_order.RemoveAt(index);
        }

        public List<List<int>> get_current()
        {
            return this.current_order;

        }

        public void pay_order()
        {
            List<Object> Transaction = new List<Object>();
            DataBaseHelper.Instance.addTransaction(this.current_order);
            current_order.Clear();
        }

        public float total_price()
        {
            float total = 0;
            foreach (List<int> transaction in current_order)
            {
                int ItemId = transaction[0];
                int Quantity = transaction[1];
                float Price = DataBaseHelper.Instance.get_price_from_itemID(ItemId);
                total += Price * Quantity;
            }
            return total;
        }
    }
}

