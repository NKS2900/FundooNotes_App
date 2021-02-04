// ----------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooManager
{
    using FundooModel.Models;
    using FundooRepositiory.IRepositorys;
    using System;
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

        /// <summary>
        /// Add Collaborator.
        /// </summary>
        /// <param name="model">Collaborator Model</param>
        /// <returns>true or false</returns>
        public bool AddCollaborator(CollaboratorModel model)
        {
            try
            {
                bool result = repository.AddCollaborator(model);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retriving all Callborators.
        /// </summary>
        /// <returns>Collaborator Model</returns>
        public IEnumerable<CollaboratorModel> RetriveCollaborator()
        {
            try
            {
                var result = repository.RetriveCollaborator();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deleting Collaborator
        /// </summary>
        /// <param name="id">Note ID</param>
        /// <returns>true or false</returns>
        public bool DeleteCollaborator(int id)
        {
            try
            {
                bool result = repository.DeleteCollaborator(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

