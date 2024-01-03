namespace Tatesoft.WebAPI.Entities

{
    public class LoggedInUser : ILoggedInUser
    {
        public User User { get; } = new(42, "arthur_dent");
    }

}
