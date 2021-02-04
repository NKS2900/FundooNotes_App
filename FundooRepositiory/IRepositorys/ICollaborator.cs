// ----------------------------------------------------------------------------------------------------
// <copyright file="ICollaborator.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooRepositiory.IRepositorys
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
