﻿namespace UpdateQ.Data.Repositories
{
    using System;
    using System.Linq;
    using UpdateQ.Data.Infrastructure;
    using UpdateQ.Model;

    public class TimeSeriesNodeRepository : BaseRepository<TimeSeriesNode>, ITimeSeriesNodeRepository
    {
        public TimeSeriesNodeRepository(IDbFactory dbFactory) : base(dbFactory)
        { }
    }
}
