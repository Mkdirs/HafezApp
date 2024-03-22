using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Json;

namespace HafezApp
{
    public class Rating {
        public int reviews { get; set; }
        public float average { get; set; }
    }
    public class Beer {
        public string name { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public int id { get; set; }
        public Rating rating { get; set; }

    }

    public class BeersViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Beer> _beers = new ObservableCollection<Beer>();
        public ObservableCollection<Beer> Beers {
            get => _beers;
            set {
                _beers = value;
                NotifyPropertyChanged(nameof(Beers));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class BeerAddViewModel : INotifyPropertyChanged
    {
        private string _name, _price;
        private string _source;
        private float _note;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }
        public string Price
        {
            get => _price;
            set
            {
                _price = value;
                NotifyPropertyChanged(nameof(Price));
            }
        }
        public string Source
        {
            get => _source;
            set
            {
                _source = value;
                NotifyPropertyChanged(nameof(Source));
            }
        }
        public float Note
        {
            get => _note;
            set
            {
                _note = value;
                NotifyPropertyChanged(nameof(Note));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

        public class Service {

        private HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://api.sampleapis.com/beers/")
        };


        public Service() {
            
        }

        public async Task<Beer[]> fetchBeers(int limit)
        {
            var result = await client.GetFromJsonAsync<List<Beer>>("ale");
            return result.Take(limit).ToArray();
            
        }

    
    }
}
