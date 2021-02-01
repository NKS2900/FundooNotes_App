// -----------------------------------------------------------------------------------------------------
// <copyright file="LabelManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooManager
{
    using FundooModel.Models;
    using FundooRepositiory.Interface;
    using System.Collections.Generic;

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

        public bool AddLabel(LabelModel model)
        {
            var result = repository.AddLabel(model);
            return result;
        }

        public IEnumerable<LabelModel> RetriveLabeles()
        {
            var result = repository.RetriveLabeles();
            return result;
        }

        public bool UpdateLable(LabelModel lable)
        {
            var result = repository.UpdateLable(lable);
            return result;
        }
    }
}
