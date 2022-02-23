using AutoMapper;
using Core1WebApi.Models;
using CoreDAL;
using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBL
{
    public class UserService
    {
        private IUserRepository _userRepository;
        private IAuthRepository _authRepository;
        private IAuthService _authService;
        private IMapper _mapper;

        public UserService(
            IMapper mapper,
            IUserRepository userRepository,
            IAuthRepository authRepository,
            IAuthService authService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _authRepository = authRepository;
            _authService = authService;
        }

        public Guid AddUser(User user)
        {
            if (!char.IsUpper(user.FirstName[0]))
            {
                throw new ArgumentException("Name should starts with upper-case!");
            }

            var dbUser = _mapper.Map<UserDto>(user);

            return _userRepository.Add(dbUser);
        }

        public IEnumerable<User> GetAllUsers()
        {
            var dbItems = _userRepository.GetAll();

            return _mapper.Map<IEnumerable<User>>(dbItems);
        }

        public User GetUserById(Guid id)
        {
            var dbUser = _userRepository.GetById(id);

            return _mapper.Map<User>(dbUser);
        }

        public bool RemoveUser(Guid id)
        {
            return _userRepository.RemoveById(id);
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateById(_mapper.Map<UserDto>(user));
        }

        public async Task<string> LoginAsync(Credentials credentials)
        {
            credentials.Password = HashPassword(credentials.Password);

            var successfullAutentication =  await _authRepository.LoginAsync(credentials);
            string token = string.Empty;
            if (successfullAutentication)
            {
                token = _authService.CreateAuthToken(credentials.Login);
            }

            return token;
        }

        private string HashPassword(string password)
        {
            return password;
        }
    }
}
