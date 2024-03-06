using System.Net.Http.Json;

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

    class Service {

        private HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://api.sampleapis.com/beers/")
        };

        private Beer[] cache;
        private object cacheLock = new object();

        public Service() {
            
        }

        public async Task fetchBeers()
        {
            var result = await client.GetFromJsonAsync<List<Beer>>("ale");
            lock ( cacheLock) {
            
                cache = result.ToArray();
            }
            
        }

        public async Task<Beer[]> listBeers(int limit)
        {
            lock(cacheLock)
            {
                if (cache == null)
                {
                    fetchBeers().Wait();
                }
            }
            
            return cache.Take(limit).ToArray();
        }

    
    }
}
