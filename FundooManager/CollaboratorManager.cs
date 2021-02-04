
namespace FundooManager
{
    using FundooModel.Models;
    using FundooRepositiory.Interface;
    using System.Collections.Generic;

    public class CollaboratorManager : ICallboratorManager
    {
        private readonly ICollaborator repository;

        /// <summary>
        /// UserManager Constructor initializing IRepository
        /// </summary>
        /// <param name="repository">initializing IRepository</param>
        public CollaboratorManager(ICollaborator repository)
        {
            this.repository = repository;
        }
        public bool AddCollaborator(CollaboratorModel model)
        {
            bool result = repository.AddCollaborator(model);
            return result;
        }

        public IEnumerable<CollaboratorModel> RetriveCollaborator()
        {
            var result = repository.RetriveCollaborator();
            return result;
        }

        public bool DeleteCollaborator(int id)
        {
            bool result = repository.DeleteCollaborator(id);
            return result;
        }
    }
}

