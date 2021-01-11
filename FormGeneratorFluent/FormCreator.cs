using System.Collections.Generic;

namespace FormGeneratorFluent
{
    public class FormCreator
    {
        public FormCreator()
        {
            _formSections = new List<FormSection>();
        }
        private readonly List<FormSection> _formSections;

        public FormCreator AddFormSection(FormSection formSection)
        {
            _formSections.Add(formSection);
            return this;
        }
    }
}