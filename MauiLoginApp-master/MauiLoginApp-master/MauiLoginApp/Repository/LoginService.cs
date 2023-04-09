
namespace MauiLoginApp.Repository;

public class LoginService : ILoginRepository<User>
{
    public async Task<User> Login(string userName, string password)
    {
        try
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                var user = new User();
                var httpClient = new HttpClient();
                string url = "http://192.168.1.51:8323/api/User/SignIn?" + "userName=" + userName + "&password=" + password;
                httpClient.BaseAddress = new Uri(url);
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    user = await response.Content.ReadFromJsonAsync<User>();
                    return user;
                }
                return null;
            }
            return null;
        }
        catch (Exception ex) { return null; }
    }
}
