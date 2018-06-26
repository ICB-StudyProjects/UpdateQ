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
            return this.DbContext.InfoNodes
                .Where(node => node.ParentInfoNodeId == null)
                .Include(i => i.ChildInfoNodes)
                    .ThenInclude(m => m.TimeSeriesNodes)
                .ToList();
        }

        //private void LoadSubordinates(ref InfoNode node)
        //{
        //    TODO: Write generic async parallel traversal tree alg
        //    this.DbContext.Entry(node)
        //        .Include(i => i.ParentInfoNode)
        //        .Include(i => i.ChildInfoNodes)
        //        .Include(i => i.TimeSeriesNodes)
        //        .Load();
        //} 

        //private void LoadSubordinates(this ref InfoNode parent)
        //{
        //    this.DbContext.Entry(parent).Collections;
        //}

        public override void Update(InfoNode entity)
        {
            entity.UpdatedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
