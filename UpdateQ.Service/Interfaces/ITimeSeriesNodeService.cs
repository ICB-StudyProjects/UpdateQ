﻿namespace UpdateQ.Service.Interfaces
{
    using System;
    using System.Collections.Generic;
    using UpdateQ.Model.Entities;

    public interface ITimeSeriesNodeService
    {
        TimeSeriesNode GetInfoNode(Guid id);
        IEnumerable<TimeSeriesNode> GetTimeSeriesNodes();
        void CreateTimeSeriesNode(TimeSeriesNode timeSeriesNode);
        void SaveTimeSeriesNode();
    }
}
