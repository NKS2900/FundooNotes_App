using FundooModel.Models;
using FundooRepositiory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRepositiory.Repositorys
{
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


    }
}
