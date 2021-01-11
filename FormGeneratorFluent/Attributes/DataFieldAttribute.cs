namespace FormGeneratorFluent.Attributes
{
    public class DataFieldAttribute : FieldAttribute
    {
        public ControlDataType ControlDataType { get; }

        public DataFieldAttribute(string id, string name, ControlDataType controlDataType) : base(id, name)
        {
            ControlDataType = controlDataType;
        }
    }

    public enum ControlDataType
    {
        ListView,
        DropDownList,
        PageWithList
    }
}