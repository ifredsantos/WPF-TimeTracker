﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.Core.Models;

namespace TimeTracker.Core.Interfaces.Repository
{
   public interface IUserRepository
   {
      Task<IEnumerable<User>> GetAllUsers();
      Task<User> SearchUserByTerm(string term);
      Task CreateUser(User user);
      Task UpdateUser(User user);
      Task DeleteUser(int user_id);
   }
}