
namespace FundooManager
{
    using FundooModel.Models;

    public interface ILabelManager 
    {
        public bool AddLabel(LabelModel model);

	public IEnumerable<LabelModel> RetriveLabeles()
    }
}
