using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;



namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByEmail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<Role> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);

        }
    }
}
