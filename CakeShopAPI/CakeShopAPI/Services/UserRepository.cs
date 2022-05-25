using CakeShopAPI.Data;
using CakeShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly CakeShopDbContext _dbContext;

        public UserRepository(CakeShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserVM Login(string phone, string password)
        {
            var user = (from usr in _dbContext.Users
                        where usr.PhoneNumber == phone && 
                            usr.Password == password
                        select new UserVM
                        {
                            Id = usr.Id,
                            Name = usr.Name,
                            Email = usr.Email,
                            PhoneNumber = usr.PhoneNumber,
                            Address = usr.Address,
                            IsAdmin = usr.IsAdmin,
                            Password = usr.Password
                        }).FirstOrDefault();

            return user;
        }

        public string Register(string name, string phone, string password)
        {
            string result = "Đăng ký thành công";
            int existPhone = (from user in _dbContext.Users
                              where user.PhoneNumber == phone
                              select user.PhoneNumber).Count();

            if(existPhone > 0)
            {
                return result = "Số điện thoại này đã tồn tại";
            }

            User newUser = new User()
            {
                Name = name,
                PhoneNumber = phone,
                Password = password,
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return result;
        }
    }
}
