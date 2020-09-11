using ApplicationModelLayer;
using System;

namespace ApplicationRepositoryLayer.Interface
{
    public interface IUserRepository
    {
        Boolean AddUser(Users userDetails);
        string Login(UserLogin user);
    }
}
