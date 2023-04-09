using Flurl;
using Flurl.Http;
using MauiSampleLogin.Helper;
using MauiSampleLogin.Models.Restaurant;
using Newtonsoft.Json;

namespace MauiSampleLogin.Services.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        public async Task<IList<RestaurantResponse>> GetAllAsync(string token)
        {
            try
            {
                var response = await Constants.BASE_URL
                    .AppendPathSegment("/restaurants")
                    .WithOAuthBearerToken(token)
                    .GetAsync();

                if (response.ResponseMessage.IsSuccessStatusCode)
                {
                    var content = await response.ResponseMessage.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IList<RestaurantResponse>>(content);
                }
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<RestaurantResponse>();
        }
    }
}
