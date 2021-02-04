// -----------------------------------------------------------------------------------------------------
// <copyright file="LabelRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooRepositiory.Repositorys
{
    using FundooModel.Models;
    using FundooRepositiory.IRepositorys;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public IEnumerable<LabelModel> RetriveLabeles()
        {
            try
            {
                IEnumerable<LabelModel> result= fundooContext.LabelTable.ToList(); 
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LabelModel RetrieveLabelById(int id)
        {
            try
            {
                LabelModel notes = this.fundooContext.LabelTable.Where(x => x.LabelId == id).SingleOrDefault();
                return notes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateLable(LabelModel lable)
        {
            try
            {
                if (lable.LabelId > 0)
                {
                    this.fundooContext.Entry(lable).State = EntityState.Modified;
                    this.fundooContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteLable(int id)
        {
            try
            {
                var userData = fundooContext.LabelTable.Where(x => x.LabelId == id).SingleOrDefault();
                if (userData != null)
                {
                    fundooContext.LabelTable.Remove(userData);
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
