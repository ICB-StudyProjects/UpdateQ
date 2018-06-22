namespace UpdateQ.Service
{
    using System;
    using System.Collections.Generic;
    using UpdateQ.Data.Infrastructure;
    using UpdateQ.Data.Repositories;
    using UpdateQ.Model.Entities;
    using UpdateQ.Service.Interfaces;

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, 
            IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateUser(User user)
        {
            this.userRepository.Add(user);
        }

        public User GetUser(Guid id)
            => this.userRepository.GetById(id);

        public IEnumerable<User> GetUsers()
            => this.userRepository.GetAll();

        public void SaveUser()
        {
            this.unitOfWork.Commit();
        }
    }
}
