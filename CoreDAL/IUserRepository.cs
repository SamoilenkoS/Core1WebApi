using CoreDAL.Entities;
using System;
using System.Collections.Generic;

namespace CoreDAL
{
    public interface IUserRepository
    {
        Guid Add(UserDto user);
        IEnumerable<UserDto> GetAll();
        UserDto GetById(Guid id);
        bool RemoveById(Guid id);
        bool UpdateById(UserDto user);
    }
}
