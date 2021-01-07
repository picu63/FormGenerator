using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormGenerator.Attributes
{
    public class FieldAttribute: Attribute
    {
        public string Id { get; }
        public string Name { get; }

        protected FieldAttribute(string id, string name)
        {
            Id = id;
            Name = name;
        }
        //TODO spytać się czy zamienić tą klasę na abstrakcyjną i przenieść wszystkie zwykłe dane do NormalFieldAttribute
        protected FieldAttribute(string id, string name, VariableType variableType)
        {
            Id = id;
            Name = name;
        }
    }
}
