using System.Web.UI.WebControls;

namespace FormGenerator
{
    public class ButtonsSection<T>:FormSection<T>
    {
        public virtual Button SaveButton { get; set; }
        public virtual Button DeleteButton { get; set; }
        public override IFinishedSection CreateForm()
        {
            this.Controls.Add(new Button());
            return this;
        }
    }
}