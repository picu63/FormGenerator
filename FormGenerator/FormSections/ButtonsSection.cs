using System.Web.UI.WebControls;

namespace FormGenerator.FormSections
{
    public class ButtonsSection<T>:FormSection<T>
    {
        public virtual Button SaveButton { get; }
        public virtual Button DeleteButton { get; }

        public ButtonsSection()
        {
            SaveButton = new Button() { Text = "Save" };
            DeleteButton = new Button() { Text = "Delete" };
        }
        public override void CreateForm()
        {
            this.Controls.Add(SaveButton);
            this.Controls.Add(DeleteButton);
        }
    }
}