using System.Web.UI;

namespace FormGeneratorFluent.Attributes
{
    public class CustomFieldAttribute : FieldAttribute
    {
        public Control CustomControl { get; set; }
        public CustomFieldAttribute(string id, string name, Control customControl) : base(id, name)
        {
            CustomControl = customControl;
        }
    }
}
