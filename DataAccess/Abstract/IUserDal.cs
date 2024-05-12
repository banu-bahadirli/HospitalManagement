using Core.DataAccess;
using Core.Entities.Concrete;


namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<Role> GetUserRoles(User user);
    }
}
