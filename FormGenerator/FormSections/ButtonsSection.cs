using System.Web.UI.WebControls;

namespace FormGenerator.FormSections
{
    public class ButtonsSection<T>:FormSection<T>
    {
        public virtual Button SaveButton { get; set; }
        public virtual Button DeleteButton { get; set; }
        public override void CreateForm()
        {
            this.Controls.Add(new Button() {ID = "testBtn"});
        }

        public override void FillControls(T @object)
        {
            
        }
    }
}