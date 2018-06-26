namespace UpdateQ.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UpdateQ.Data.Infrastructure;
    using UpdateQ.Model.Entities;

    public class InfoNodeRepository : BaseRepository<InfoNode>, IInfoNodeRepository
    {
        public InfoNodeRepository(IDbFactory dbFactory) : base(dbFactory)
        { }

        public override IEnumerable<InfoNode> GetAll()
        {
            var fullInfoNodes = this.DbContext
                .InfoNodes
                .Include(i => i.ParentInfoNode)
                .Include(i => i.ChildInfoNodes)
                .Include(i => i.TimeSeriesNodes)
                .ToList();

            return fullInfoNodes;
        }

        public override void Update(InfoNode entity)
        {
            entity.UpdatedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
