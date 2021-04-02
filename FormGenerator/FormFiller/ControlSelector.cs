using System.Web.UI.WebControls;

namespace FormGenerator.FormFiller
{
    public class ControlSelector : IControlSelector
    {
        
        public void SelectDropDownList(DropDownList dropDownList, int index)
        {
            dropDownList.SelectedIndex = index;
        }

        public void SelectRadioButton(RadioButtonList radioButtonList, int index)
        {
            radioButtonList.Items[index].Selected = true;
        }
    }

    public interface IControlSelector
    {
        void SelectDropDownList(DropDownList dropDownList, int index);
        void SelectRadioButton(RadioButtonList radioButtonList, int index);
    }
}