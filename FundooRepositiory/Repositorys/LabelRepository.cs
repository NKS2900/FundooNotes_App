using System;
using System.Collections.Generic;
using System.Text;
using FundooModel.Models;
using FundooRepositiory.Interface;

namespace FundooRepositiory.Repositorys
{
    public class LabelRepository : ILabelRepository
    {
        private readonly FundooContext fundooContext;

        /// <summary>
        /// Constructor to Initializing FundooContext
        /// </summary>
        /// <param name="fundooContext">fundooContext</param>
        public LabelRepository(FundooContext fundooContext)
        {
            this.fundooContext = fundooContext;
        }

        public bool AddLabel(LabelModel model)
        {
            try
            {
                fundooContext.LabelTable.Add(model);
                var emp = fundooContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
