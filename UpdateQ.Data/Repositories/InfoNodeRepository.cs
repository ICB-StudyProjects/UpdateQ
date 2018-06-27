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
            //return this.DbContext.InfoNodes
            //    .Where(node => node.ParentInfoNodeId == null)
            //    .Include(i => i.ChildInfoNodes)
            //        .ThenInclude(m => m.TimeSeriesNodes)
            //    .ToList(); // Only second childrens

            var infoNodes = this.DbContext.InfoNodes
                .Where(node => node.ParentInfoNodeId == null);

            foreach (InfoNode node in infoNodes)
            {
                LoadEntities(node);
            }

            return infoNodes;
        }

        //private void LoadSubordinates(DbSet<InfoNode> nodes)
        //{
        //    nodes
        //        .Include(n => n.TimeSeriesNodes)
        //        .Include(n => n.ChildInfoNodes);

        //    // TODO: Write generic async parallel traversal tree alg
        //    foreach (InfoNode node in nodes)
        //    {
        //        //LoadSubordinates(node.ChildInfoNodes);
        //    }
        //}

        // TODO: Write generic async parallel traversal tree alg
        private void LoadEntities(InfoNode node)
        {
            this.DbContext.Entry(node)
                .Collection(n => n.TimeSeriesNodes)
                .Load();

            this.DbContext.Entry(node)
                .Collection(n => n.ChildInfoNodes)
                .Load();

            foreach (InfoNode child in node.ChildInfoNodes)
            {
                LoadEntities(child);
            }
        }

        public override void Update(InfoNode entity)
        {
            entity.UpdatedOn = DateTime.Now;
            base.Update(entity);
        }
    }
}
