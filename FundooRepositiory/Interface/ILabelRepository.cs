
namespace FundooRepositiory.Interface
{
    using FundooModel.Models;

    public interface ILabelRepository 
    {
        public bool AddLabel(LabelModel model);

	public IEnumerable<LabelModel> RetriveLabeles();
    }
}
