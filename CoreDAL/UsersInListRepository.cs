using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDAL
{
    public class UsersInListRepository : IUserRepository
    {
        private static List<UserDto> _users;

        static UsersInListRepository()
        {
            _users = new List<UserDto>();
        }

        public Guid Add(UserDto user)
        {
            user.Id = Guid.NewGuid();
            _users.Add(user);

            return user.Id;
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _users;
        }

        public UserDto GetById(Guid id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public UserDto RemoveById(Guid id)
        {
            var entity = GetById(id);

            _users.Remove(entity);

            return entity;
        }

        public bool UpdateById(UserDto user)
        {
            var dbUser = GetById(user.Id);

            if (dbUser != null)
            {
                var index = _users.IndexOf(dbUser);
                _users[index] = user;
            }

            return dbUser != null;
        }
    }
}
