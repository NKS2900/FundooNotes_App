// ----------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooRepositiory.Repositorys
{
    using FundooModel.Models;
    using FundooRepositiory.IRepositorys;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CollaboratorRepository : ICollaborator
    {
        private readonly FundooContext fundooContext;

        /// <summary>
        /// Constructor to Initializing FundooContext
        /// </summary>
        /// <param name="fundooContext">fundooContext</param>
        public CollaboratorRepository(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        /// <summary>
        /// Add New Collaborator
        /// </summary>
        /// <param name="model">CollaboratorModel</param>
        /// <returns></returns>
        public bool AddCollaborator(CollaboratorModel model)
        {
            try
            {
                fundooContext.CollaboratorTable.Add(model);
                var emp = fundooContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get all Collaborator.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CollaboratorModel> RetriveCollaborator()
        {
            try
            {
                IEnumerable<CollaboratorModel> result = fundooContext.CollaboratorTable.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Delet Collaborator
        /// </summary>
        /// <param name="id">Collaborator ID</param>
        /// <returns></returns>
        public bool DeleteCollaborator(int id)
        {
            try
            {
                var userData = fundooContext.CollaboratorTable.Where(x => x.CallId == id).SingleOrDefault();
                if (userData != null)
                {
                    fundooContext.CollaboratorTable.Remove(userData);
                    fundooContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
