namespace Car.API.IdentityManager
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetByUserName(string userName);
    }
}
