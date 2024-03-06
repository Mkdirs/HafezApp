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


        public Service() {
            
        }

        public async Task<Beer[]> fetchBeers(int limit)
        {
            var result = await client.GetFromJsonAsync<List<Beer>>("ale");
            return result.Take(limit).ToArray();
            
        }

    
    }
}
