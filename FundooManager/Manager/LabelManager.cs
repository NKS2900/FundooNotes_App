// -----------------------------------------------------------------------------------------------------
// <copyright file="LabelManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooManager
{
    using FundooModel.Models;
    using FundooRepositiory.IRepositorys;
    using System.Collections.Generic;
    using FundooManager;
    using System;

    public class LabelManager : ILabelManager
    {
        private readonly ILabelRepository repository;

        /// <summary>
        /// UserManager Constructor initializing IRepository
        /// </summary>
        /// <param name="repository">initializing IRepository</param>
        public LabelManager(ILabelRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Add New Label
        /// </summary>
        /// <param name="model">Label Model</param>
        /// <returns>true or false</returns>
        public bool AddLabel(LabelModel model)
        {
            try
            {
                var result = repository.AddLabel(model);
                return result;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message); 
            }
        }

        /// <summary>
        /// Retriving Labels
        /// </summary>
        /// <returns>LabelModel</returns>
        public IEnumerable<LabelModel> RetriveLabeles()
        {
            try
            {
                var result = repository.RetriveLabeles();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retriving Label By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>LabelModel</returns>
        public LabelModel RetrieveLabelById(int id)
        {
            try
            {
                var result = repository.RetrieveLabelById(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Updating Label
        /// </summary>
        /// <param name="lable">Label model</param>
        /// <returns>true or false</returns>
        public bool UpdateLable(LabelModel lable)
        {
            try
            {
                var result = repository.UpdateLable(lable);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deleting Label
        /// </summary>
        /// <param name="id">Label ID</param>
        /// <returns></returns>
        public bool DeleteLable(int id)
        {
            try
            {
                var result = repository.DeleteLable(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
