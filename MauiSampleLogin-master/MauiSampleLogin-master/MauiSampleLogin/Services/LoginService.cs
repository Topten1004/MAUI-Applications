using Flurl;
using Flurl.Http;
using MauiSampleLogin.Helper;
using MauiSampleLogin.Models;
using MauiSampleLogin.Models.CreateAccount;
using Newtonsoft.Json;

namespace MauiSampleLogin.Services
{
    public class LoginService : ILoginService
    {
        public async Task<bool> CreateAccount(CreateAccountRequest createAccountRequest)
        {
            try
            {
                var response = await Constants.BASE_URL
                .AppendPathSegment("/users")
                .PostJsonAsync(createAccountRequest);

                return response.ResponseMessage.IsSuccessStatusCode;
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            try
            {
                var response = await Constants.BASE_URL
                    .AppendPathSegment("/auth")
                    .PostJsonAsync(loginRequest);

                if (response.ResponseMessage.IsSuccessStatusCode)
                {
                    var content = await response.ResponseMessage.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<LoginResponse>(content);
                }
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new LoginResponse();
        }
    }
}
