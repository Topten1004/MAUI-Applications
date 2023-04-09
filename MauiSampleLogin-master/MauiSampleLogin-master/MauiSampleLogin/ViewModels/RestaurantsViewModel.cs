using MauiSampleLogin.Models.Restaurant;
using MauiSampleLogin.Services.Restaurants;
using System.Runtime.InteropServices;

namespace MauiSampleLogin.ViewModels
{
    [ObservableObject]
    public partial class RestaurantsViewModel
    {
        private readonly IRestaurantService _service;

        public ObservableCollection<RestaurantResponse> Restaurants { get; set; } = new ObservableCollection<RestaurantResponse>();
        public RestaurantsViewModel(IRestaurantService service)
        {
            _service = service;
        }

        public async Task InitAsync()
        {
            var result = await _service
                .GetAllAsync(await SecureStorage.GetAsync("token"));

            if (result is null)
                return;

            Restaurants?.Clear();
            foreach (var item in result)
                Restaurants.Add(item);
        }
    }
}
