using CoreDAL.Entities;
using System.Threading.Tasks;

namespace CoreDAL
{
    public interface IAuthRepository
    {
        Task<bool> LoginAsync(Credentials credentials);
    }
}