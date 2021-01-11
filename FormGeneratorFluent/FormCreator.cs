using System.Collections.Generic;

namespace FormGeneratorFluent
{
    public class FormCreator
    {
        public FormCreator()
        {
            _formSections = new List<IFormSection>();
        }
        private readonly List<IFormSection> _formSections;

        public FormCreator AddFormEntity(IFormSection formSection)
        {
            _formSections.Add(formSection);
            return this;
        }
        
    }

    public class FormSection:IFormSection
    {
        
    }

    public interface IFormSection
    {
        
    }
}