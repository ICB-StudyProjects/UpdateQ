namespace UpdateQ.Data.Repositories
{
    using System;
    using UpdateQ.Data.Infrastructure;
    using UpdateQ.Model;

    public class InfoNodeRepository : BaseRepository<InfoNode>, IInfoNodeRepository
    {
        public InfoNodeRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

        public override void Update(InfoNode entity)
        {
            entity.UpdatedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
