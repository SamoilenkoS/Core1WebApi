using AutoMapper;
using Core1WebApi.Models;
using CoreDAL;
using CoreDAL.Entities;
using System;
using System.Collections.Generic;

namespace CoreBL
{
    public class UserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(
            IMapper mapper,
            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
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

        public User RemoveUser(Guid id)
        {
            var dbUser = _userRepository.RemoveById(id);

            return _mapper.Map<User>(dbUser);
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateById(_mapper.Map<UserDto>(user));
        }
    }
}
