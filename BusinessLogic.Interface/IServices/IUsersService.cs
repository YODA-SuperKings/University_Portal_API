using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Model.Models;

namespace BusinessLogic.Interface.IServices
{
    public interface IUsersService
    {
        List<Users> GetUsers();
        string CreateUser(Users user);
    }
}
