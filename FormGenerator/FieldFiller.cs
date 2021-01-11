using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormGenerator
{
    public class FieldFiller<T> : IFieldFiller
    {
        private readonly T _object;

        public FieldFiller(T @object)
        {
            _object = @object;
        }

        public void Fill(IEnumerable<Control> controls)
        {
            
        }
    }

    public interface IFieldFiller
    {
        void Fill(IEnumerable<Control> controls);
    }
}