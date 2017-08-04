using System;

using Newtonsoft.Json;

namespace TechAndWings
{
    public class Item : ObservableObject
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

		[JsonProperty("location")]
        public string Location { get; set; }

		[JsonProperty("topics")]
		public string Topics { get; set; }

		[JsonProperty("people")]
		public int People { get; set; }

    }
}
