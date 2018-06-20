namespace UpdateQ.Service
{
    using System;
    using System.Collections.Generic;
    using UpdateQ.Data.Infrastructure;
    using UpdateQ.Data.Repositories;
    using UpdateQ.Model;
    using UpdateQ.Service.Interfaces;

    public class TimeSeriesNodeService : ITimeSeriesNodeService
    {
        private readonly ITimeSeriesNodeRepository timeSeriesNodeRepository;
        private readonly IUnitOfWork unitOfWork;

        public TimeSeriesNodeService(ITimeSeriesNodeRepository timeSeriesNodeRepository, 
            IUnitOfWork unitOfWork)
        {
            this.timeSeriesNodeRepository = timeSeriesNodeRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateTimeSeriesNode(TimeSeriesNode timeSeriesNode)
        {
            this.timeSeriesNodeRepository.Add(timeSeriesNode);
        }

        public TimeSeriesNode GetInfoNode(Guid id)
            => this.timeSeriesNodeRepository.GetById(id);

        public IEnumerable<TimeSeriesNode> GetTimeSeriesNodes()
            => this.timeSeriesNodeRepository.GetAll();

        public void SaveTimeSeriesNode()
        {
            this.unitOfWork.Commit();
        }
    }
}
