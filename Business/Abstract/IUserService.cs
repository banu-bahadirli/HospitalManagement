using Core.Entities.Concrete;


namespace Business.Abstract
{
    public interface  IUserService
    {
        List<Role> GetUserRoles(User user);

        void Add(User user);

        User GetByEmail(string email);
    }
}
