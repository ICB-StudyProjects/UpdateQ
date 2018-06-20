namespace UpdateQ.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private UpdateQContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public UpdateQContext DbContext
            => this.dbContext ?? (this.dbContext = this.dbFactory.Init());

        public void Commit()
        {
            this.DbContext.Commit();
        }
    }
}
