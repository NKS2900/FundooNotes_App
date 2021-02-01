
namespace FundooRepositiory.Interface
{
    using FundooModel.Models;
    using System.Collections.Generic;

    public interface ILabelRepository 
    {
        public bool AddLabel(LabelModel model);

        public IEnumerable<LabelModel> RetriveLabeles();

        public bool UpdateLable(LabelModel lable);

        public bool DeleteLable(int id);
    }
}
