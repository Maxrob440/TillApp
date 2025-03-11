using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TillApp
{
    class TabHelper
    {
        // This class should be made into a database to ensure no data is lost when the program is closed
        public static TabHelper _instance;

        private TabHelper() { }

        public static TabHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TabHelper();
                }
                return _instance;
            }
        }
        Dictionary<int, List<List<int>>> tabs = new Dictionary<int, List<List<int>>>();
        //List<List<int>> current_tab = new List<List<int>>();
        public void add_item(int tabID,int item, int quant)
        {
            List<int> One_item = new List<int>();
            One_item.Add(item);
            One_item.Add(quant);
            tabs[tabID].Add(One_item);
        }
        public void remove_item(int tabID,int index) //Removes item from list based on index
        {
            tabs[tabID].RemoveAt(index);
        }

        public List<int> get_tabIds()
        {
            List<int> tabIds = new List<int>();
            foreach (KeyValuePair<int, List<List<int>>> tab in tabs)
            {
                tabIds.Add(tab.Key);
            }
            return tabIds;
        }

        public Dictionary<int, List<List<int>>> get_tabs()
        {
            return this.tabs;
        }
        public void new_tab()
        {
            List<List<int>> new_tab = new List<List<int>>();
            tabs.Add(tabs.Count, new_tab);
        }
    }
}
