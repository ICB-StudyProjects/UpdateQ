namespace UpdateQ.Data.Repositories
{
    using UpdateQ.Data.Infrastructure;
    using UpdateQ.Model.Entities;

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
