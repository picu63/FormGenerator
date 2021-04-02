using System.Linq;
using System.Reflection;
using FormGenerator.Attributes;

namespace FormGenerator
{
    internal static class FieldAttributeHelper
    {
        internal static object GetValue<T>(T o, string controlId)
        {
            var propertyInfo = typeof(T).GetProperties()
                .First(p => p.GetCustomAttribute<FieldAttribute>().Id == controlId);
            return propertyInfo.GetValue(o);
        }
    }
}