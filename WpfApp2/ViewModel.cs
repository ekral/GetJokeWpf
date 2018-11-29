
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Value
    {
        
        public int id { get; set; }
        public string joke { get; set; }
        public List<string> categories { get; set; }
    }

    public class RootObject
    {
        public string type { get; set; }
        public Value value { get; set; }
    }

    public class ViewModel : ViewModelBase
    {
        private string _joke;

        public string Joke
        {
            get { return _joke; }
            set { _joke = value; OnPropertyChanged(); }
        }


        public MujCommand CommandGetJoke { get; set; }

        public ViewModel()
        {
            CommandGetJoke = new MujCommand(async (param) => await GetJoke());
        }

        public async Task GetJoke()
        {
            System.Diagnostics.Debug.WriteLine("Get Joke start");

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://api.icndb.com/jokes/random");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(content);
                    Joke = (string)json["value"]["joke"];
                }
            }

            System.Diagnostics.Debug.WriteLine("Get Joke end");

        }
    }
}
