﻿using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDAL
{
    public interface IUserRepository
    {
        Guid Add(UserDto user);
        IEnumerable<UserDto> GetAll();
        UserDto GetById(Guid id);
        UserDto RemoveById(Guid id);
        bool UpdateById(UserDto user);
    }
}
