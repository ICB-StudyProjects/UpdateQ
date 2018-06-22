namespace UpdateQ.Service.Interfaces
{
    using System.Collections.Generic;
    using UpdateQ.Model.Entities;

    public interface IInfoNodeService
    {
        InfoNode GetInfoNode(int id);
        IEnumerable<InfoNode> GetInfoNodes();
        void CreateInfoNode(InfoNode infoNode);
        void SaveInfoNode();
    }
}
