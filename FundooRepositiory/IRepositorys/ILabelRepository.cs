// ----------------------------------------------------------------------------------------------------
// <copyright file="ILabelRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Nijam Sayyad"/>
// -----------------------------------------------------------------------------------------------------

namespace FundooRepositiory.IRepositorys
{
    using FundooModel.Models;
    using System.Collections.Generic;

    public interface ILabelRepository 
    {
        public bool AddLabel(LabelModel model);

        public IEnumerable<LabelModel> RetriveLabeles();

        public LabelModel RetrieveLabelById(int id);

        public bool UpdateLable(LabelModel lable);

        public bool DeleteLable(int id);
    }
}
