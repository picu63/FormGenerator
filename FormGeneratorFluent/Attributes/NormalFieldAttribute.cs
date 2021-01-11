using System;
using System.Linq;

namespace FormGeneratorFluent.Attributes
{

    public class NormalFieldAttribute : FieldAttribute
    {
        public VariableType VariableType { get; }
        public string DefaultValue { get; }
        /// <summary>
        /// Pole w którym określa się właściwości wyświetlonych danych
        /// </summary>
        /// <param name="name">Nazwa pola.</param>
        /// <param name="variableType">Typ zmiennej.</param>
        /// <param name="defaultValue"></param>
        public NormalFieldAttribute(string id, string name, VariableType variableType = VariableType.Unknown, string defaultValue = "") : base(id, name)
        {
            VariableType = variableType;
            DefaultValue = defaultValue;
            if (id.Any(char.IsWhiteSpace))
                throw new Exception("Id cannot contains white spaces");
        }
    }

    public enum VariableType
    {
        Unknown,
        String,
        Int,
        Bool,
        Nip,
    }
}