﻿namespace UpdateQ.Data.Infrastructure
{
    using UpdateQ.Data.Utils;

    public class DbFactory : Disposable, IDbFactory
    {
        private UpdateQContext dbContext;

        public UpdateQContext Init()
            => this.dbContext ?? (this.dbContext = new DesignTimeDbContextFactory().CreateDbContext(new string[0]));

        protected override void DisposeCore()
        {
            // TODO: Check if the context is disposing
            if (this.dbContext != null)
            {
                this.dbContext.Dispose();
            }
        }
    }
}
