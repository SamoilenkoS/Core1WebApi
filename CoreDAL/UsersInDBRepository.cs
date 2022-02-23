using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDAL
{
    public class UsersInDBRepository : IUserRepository
    {
        private readonly EfCoreContext _dbContext;

        public UsersInDBRepository(EfCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Guid Add(UserDto user)
        {
            user.Id = Guid.NewGuid();
            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();

            return user.Id;
        }

        public IEnumerable<UserDto> GetAll()
        {
            return _dbContext.Users.AsEnumerable();
        }

        public UserDto GetById(Guid id)
        {
            return _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool RemoveById(Guid id)
        {
            var user = new UserDto { Id = id };
            _dbContext.Users.Remove(user);
            return _dbContext.SaveChanges() != 0;
        }

        public bool UpdateById(UserDto user)
        {
            _dbContext.Users.Update(user);
            var result = _dbContext.SaveChanges();

            return result != 0;
        }
    }
}
