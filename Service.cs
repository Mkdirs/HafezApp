using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;

namespace HafezApp
{
    public record class Rating
    (
        int reviews,
        float average
    );
    public record class Beer
    (
        string name,
        string price,
        string image,
        int id,
        Rating rating

    );

    public class BeersViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Beer> _beers = new ObservableCollection<Beer>();
        public ObservableCollection<Beer> Beers {
            get => _beers;
            set {
                _beers = value;
                NotifyPropertyChanged(nameof( Beers));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
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
