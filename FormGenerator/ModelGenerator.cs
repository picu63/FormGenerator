using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Net.Mime;
using FormGenerator.Attributes;

namespace FormGenerator
{
    public class ModelGenerator<T> : FormGenerator
    {
        /// <summary>
        /// Class with object parameters
        /// </summary>
        /// <param name="object">Object to send.</param>
        public ModelGenerator(T @object)
        {
            Object = @object;
            if (Object is null)
            {
                throw new ArgumentNullException(nameof(@object));
            }
        }
        
        public ModelGenerator() { }

        private object Object { get;}
        private List<Control> AddedControls { get; } = new List<Control>();
        private static IEnumerable<FieldAttribute> FieldsAttributes { get
        {
            return typeof(T)
                .GetProperties()
                .Select(p => p.GetCustomAttribute<FieldAttribute>())
                .Where(p => p != null)
                .ToList();
        } }
        public override void CreateForm()
        {
            if (this.FormTable is null)
            {
                FormTable = new Table();
            }
            CreateFormHeader();
            CreateFormControls();
            if (Object is null)
            {
                CreateSaveButton();
            }
            else
            {
                FillFields();
                CreateDeleteButton();
            }
        }


        private void FillFields()
        {
            if (Object is null)
            {
                throw new ArgumentNullException(typeof(T).Name, "Object cannot be null");
            }

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(Object))
            {
                FillControlFromProperty(property);
            }
        }

        private void FillControlFromProperty(PropertyDescriptor property)
        {
            var name = property.Name;
            var value = property.GetValue(Object);
            var attributeId = typeof(T).GetProperty(name)?.GetCustomAttribute<NormalFieldAttribute>()?.Id;
            if (attributeId is null) return;
            var addedControls = this.GetAllChildren().FirstOrDefault(c => c.ID == attributeId);
            
            switch (addedControls)
            {
                case TextBox textBox:
                    if (value != null) textBox.Text = value.ToString();
                    break;
                
                case DropDownList dropDownList:
                    if (value != null && value.GetType().IsEnum)
                    {
                        var enums = Enum.GetValues(value.GetType());
                        foreach (var @enum in enums)
                        {
                            var enumType = value.GetType();
                            var memberInfos = enumType.GetMember(@enum.ToString());
                            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                            var valueAttributes =
                                enumValueMemberInfo.GetCustomAttributes(typeof(EnumFieldAttribute), false);
                            var description = ((EnumFieldAttribute) valueAttributes[0]).Name;

                            dropDownList.Items.Insert(0, new ListItem(description));
                        }
                    }
                    else
                    {
                        addedControls = new Button();
                    }
                    break;
                
                case CheckBox checkBox:
                    checkBox.Checked = (bool) value;
                    break;
            }
        }

        /// <summary>
        /// Tworzenie nagłówka formularza.
        /// </summary>
        private void CreateFormHeader()
        {
            var headerName = typeof(T).GetCustomAttribute<HeaderAttribute>()?.Name;
            if (headerName is null)
            {
                throw new ArgumentNullException(nameof(headerName), $"Class for building dynamically have to has {nameof(HeaderAttribute)}");
            }
            var headerRow = new TableHeaderRow();
            headerRow.Cells.Add(new TableCell() {ID = "formHeader" + headerName.Trim(), Text = headerName, ColumnSpan = 2});
            this.FormTable.Rows.AddAt(0,headerRow);
        }
        
        /// <summary>
        /// Tworzy przycisk usuwania.
        /// </summary>
        private void CreateDeleteButton()
        {
            if (this.DeleteButton is null)
            {
                this.DeleteButton = new Button() {ID = "btnDelete", Text = "DELETE"};
            }
            Controls.Add(DeleteButton);
        }

        /// <summary>
        /// Trzyrzy przycisk zapisu.
        /// </summary>
        private void CreateSaveButton()
        {
            if (this.SaveButton is null)
            {
                this.SaveButton = new Button() { ID = "btnDelete", Text = "SAVE" };
            }
            Controls.Add(SaveButton);
        }

        /// <summary>
        /// Generuje niewypełnione kontrolki
        /// </summary>
        private void CreateFormControls()
        {
            foreach (var fieldAttribute in FieldsAttributes)
            {
                var row = new TableRow();
                row.Cells.Add(new TableCell() {Text = fieldAttribute.Name});
                var valueCell = new TableCell();
                if (fieldAttribute is NormalFieldAttribute normalFieldAttribute)
                { 
                    valueCell = CreateNormalValueCell(normalFieldAttribute);
                }
                else if (fieldAttribute is DataFieldAttribute dataFieldAttribute)
                {
                    valueCell = CreateDataFielCell(dataFieldAttribute);
                }
                row.Cells.Add(valueCell);
                this.FormTable.Rows.Add(row);
            }
            this.Controls.Add(FormTable);
        }

        private TableCell CreateDataFielCell(DataFieldAttribute dataFieldAttribute)
        {
            var tableCell = new TableCell();
            var controlToAdd = new Control();
            
            var controlDataType = dataFieldAttribute.ControlDataType;
            switch (controlDataType)
            {
                case ControlDataType.ListView:
                    controlToAdd = new ListView();
                    break;
                case ControlDataType.DropDownList:
                    controlToAdd = new DropDownList();
                    break;
                case ControlDataType.PageWithList:
                    Response.Redirect("~/Test04.aspx");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            controlToAdd.ID = dataFieldAttribute.Id;
            AddedControls.Add(controlToAdd);
            tableCell.Controls.Add(controlToAdd);
            return tableCell;
        }

        private TableCell CreateNormalValueCell(NormalFieldAttribute normalFieldAttribute)
        {
            var tableCell = new TableCell();
            var controlToAdd = new Control();
            switch (normalFieldAttribute.VariableType)
            {
                case VariableType.Unknown:
                    tableCell.Text = "Unknown cell";
                    break;
                case VariableType.String:
                    controlToAdd = new TextBox();
                    break;
                case VariableType.Int:
                    controlToAdd = new TextBox();
                    break;
                case VariableType.Nip:
                    controlToAdd = new TextBox(){TextMode = TextBoxMode.Number};
                    break;
                case VariableType.Bool:
                    controlToAdd = new CheckBox();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            controlToAdd.ID = normalFieldAttribute.Id;
            AddedControls.Add(controlToAdd);
            tableCell.Controls.Add(controlToAdd);
            return tableCell;
        }
    }
}