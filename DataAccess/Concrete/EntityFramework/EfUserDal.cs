using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, HospitalContext>, IUserDal
    {
        public List<Role> GetUserRoles(User user)
        {
            using(var context = new HospitalContext())
            {
                var result = from role in context.Roles
                             join userRole in context.UserRoles
                             on role.Id equals userRole.RoleId
                             where userRole.UserId == user.Id
                             select new Role { Id= role.Id,Name = role.Name };

                return result.ToList();
            }
        }
    }
}
