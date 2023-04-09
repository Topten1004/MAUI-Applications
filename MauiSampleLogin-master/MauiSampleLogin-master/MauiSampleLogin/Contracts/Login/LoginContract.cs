using Flunt.Validations;
using MauiSampleLogin.Models;

namespace MauiSampleLogin.Contracts.Login
{
    public class LoginContract : Contract<LoginRequest>
    {
        public LoginContract(LoginRequest login)
        {
            Requires()
                .IsEmail(login.Email, nameof(login.Email), "E-mail is invalid")
                .IsNotNullOrEmpty(login.Email, nameof(login.Email), "E-mail is invalid");

            Requires()
                .IsNotNullOrEmpty(login.Password, nameof(login.Password), "Password is invalid");
        }
    }
}
