using MoneyManagerApi.Models;
using System.Collections.Generic;

namespace MoneyManagerApi.Services.Contracts
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User GetbyName(string name);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
