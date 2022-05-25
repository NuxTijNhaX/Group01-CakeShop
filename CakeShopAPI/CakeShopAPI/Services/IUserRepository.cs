using CakeShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Services
{
    public interface IUserRepository
    {
        UserVM Login(string phone, string password);
        string Register(string name, string phone, string password);
    }
}
