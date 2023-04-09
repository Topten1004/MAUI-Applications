namespace MauiLoginApp.Repository;

public interface ILoginRepository<T>
{
    Task<T> Login(string userName, string password);
}
