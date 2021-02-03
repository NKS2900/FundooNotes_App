
namespace FundooManager
{
    using FundooModel.Models;
    using System.Collections.Generic;

    public interface ICallboratorManager
    {
        public bool AddCollaborator(CollaboratorModel model);

        public IEnumerable<CollaboratorModel> RetriveCollaborator();

        public bool DeleteCollaborator(int id);
    }
}
