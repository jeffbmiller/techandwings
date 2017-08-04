using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechAndWings
{
    public class MockDataStore : IDataStore<Item>
    {
        bool isInitialized;
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var _items = new List<Item>
            {
                new Item { Date = DateTime.Now, Location="Boston Pizza", Topics="Xamarin, IOS", People=3},
                new Item { Date = DateTime.Now.AddDays(-30), Location="Tavern", Topics="C#, Android, F#", People=3}
            };

            foreach (Item item in _items)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            var task = Task.Factory.StartNew(()=> {
                return items;
            });

            return await task;
        }
    }
}
