using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TechAndWings
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Item> Items { get; set; }
        public ObservableCollection<DayGroupList> DaysGroupings {get;set;}

        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Meetups";
            Items = new ObservableRangeCollection<Item>();
            DaysGroupings = new ObservableCollection<DayGroupList>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                DaysGroupings.Clear();
                var items = await DataStore.GetItemsAsync(true);
                Items.ReplaceRange(items);

                SortItems();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void SortItems(){
            foreach (var monthGrouping in Items.OrderByDescending(x=>x.Date).GroupBy(x=>x.Date.ToString("MMMM"))){
                var dayGroup = new DayGroupList();
                dayGroup.AddRange(monthGrouping);
                dayGroup.Heading = monthGrouping.Key.ToString();
                DaysGroupings.Add(dayGroup);
            }
        }

		
    }

	public class DayGroupList : List<Item>
	{
		public string Heading { get; set; }
		public List<Item> Items => this;
	}

	public class Grouping<K, T> : ObservableCollection<T>
	{
		public K Key { get; private set; }

		public Grouping(K key, IEnumerable<T> items)
		{
			Key = key;
			foreach (var item in items)
				this.Items.Add(item);
		}
	}
}
