using CoreDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDAL
{
    public class AuthRepository : IAuthRepository
    {
        private EfCoreContext _dbContext;

        public AuthRepository(EfCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> LoginAsync(Credentials credentials)
        {
            var items = await _dbContext.Users
                .Where(x =>
                    x.Login == credentials.Login &&
                    x.Password == credentials.Password)
                .ToListAsync();

            return items.Any();
        }
    }
}
