using MauiSampleLogin.Models.Restaurant;

namespace MauiSampleLogin.Services.Restaurants
{
    public interface IRestaurantService
    {
        Task<IList<RestaurantResponse>> GetAllAsync(string token);
    }
}
