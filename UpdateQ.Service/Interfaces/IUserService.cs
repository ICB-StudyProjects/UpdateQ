namespace UpdateQ.Service.Interfaces
{
    using System;
    using System.Collections.Generic;
    using UpdateQ.Model;

    public interface IUserService
    {
        User GetUser(Guid id);
        IEnumerable<User> GetUsers();
        void CreateUser(User user);
        void SaveUser();
    }
}
