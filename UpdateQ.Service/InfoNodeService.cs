namespace UpdateQ.Service
{
    using System.Collections.Generic;
    using UpdateQ.Data.Infrastructure;
    using UpdateQ.Data.Repositories;
    using UpdateQ.Model.Entities;
    using UpdateQ.Service.Interfaces;

    public class InfoNodeService : IInfoNodeService
    {
        private readonly IInfoNodeRepository infoNodeRepository;
        private readonly IUnitOfWork unitOfWork;

        public InfoNodeService(IInfoNodeRepository infoNodeRepository,
            IUnitOfWork unitOfWork)
        {
            this.infoNodeRepository = infoNodeRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateInfoNode(InfoNode infoNode)
        {
            this.infoNodeRepository.Add(infoNode);
        }

        public InfoNode GetInfoNode(int id)
            => this.infoNodeRepository.GetById(id);

        public IEnumerable<InfoNode> GetInfoNodes()
            => this.infoNodeRepository.GetAll();

        public void SaveInfoNode()
        {
            this.unitOfWork.Commit();
        }
    }
}
