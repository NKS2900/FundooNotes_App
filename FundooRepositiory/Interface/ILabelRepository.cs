
namespace FundooRepositiory.Interface
{
    using FundooModel.Models;

    public interface ILabelRepository 
    {
        public bool AddLabel(LabelModel model);

	public IEnumerable<LabelModel> RetriveLabeles();

	public bool UpdateLable(LabelModel lable);
    }
}
