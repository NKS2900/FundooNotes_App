
namespace FundooRepositiory.Interface
{
    using FundooModel.Models;
    using System.Collections.Generic;

    public interface ICollaborator
    {
        public bool AddCollaborator(CollaboratorModel model);

        public IEnumerable<CollaboratorModel> RetriveCollaborator();

        public bool DeleteCollaborator(int id);
    }
}
