// -----------------------------------------------------------------------------------------------------
// <copyright file="ILabelManager.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooManager
{
    using FundooModel.Models;
    using System.Collections.Generic;

    public interface ILabelManager 
    {
        public bool AddLabel(LabelModel model);

        public IEnumerable<LabelModel> RetriveLabeles();

        public LabelModel RetrieveLabelById(int id);

        public bool UpdateLable(LabelModel lable);

        public bool DeleteLable(int id);
    }
}
