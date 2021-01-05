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
using FormGenerator.Library;
using FormGenerator.Library.Attributes;

namespace FormGenerator
{
    public class ModelGenerator<T> : UserControl
    {
        public Button SaveButton { get; set; }
        public Button DeleteButton { get; set; }
        public Table FormTable { get; set; }
        private object Object { get;}
        private List<Control> AddedControls { get; } = new List<Control>();
        public ModelGenerator(T @object)
        {
            Object = @object;
            if (Object is null)
            {
                throw new ArgumentNullException(nameof(@object));
            }

        }
        public ModelGenerator()
        {
        }

        public void CreateForm()
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
                CreateDeleteButton();
            }
        }

        private void CreateFormHeader()
        {
            var headerName = typeof(T).GetCustomAttribute<HeaderAttribute>()?.Name;
            if (headerName is null)
            {
                throw new ArgumentNullException(nameof(headerName), $"Class for building dynamically have to has {nameof(HeaderAttribute)}");
            }
            var headerRow = new TableHeaderRow();
            headerRow.Cells.Add(new TableCell() {ID = "formHeader" + headerName.Trim(), Text = headerName, ColumnSpan = 2});
            this.FormTable.Rows.Add(headerRow);
        }

        private void CreateDeleteButton()
        {
            if (this.DeleteButton is null)
            {
                this.DeleteButton = new Button() {ID = "btnDelete", Text = "DELETE"};
            }
            Controls.Add(DeleteButton);
        }

        private void CreateSaveButton()
        {
            if (this.SaveButton is null)
            {
                this.SaveButton = new Button() { ID = "btnDelete", Text = "SAVE" };
            }
            Controls.Add(SaveButton);
        }


        private void CreateFormControls()
        {
            var fieldsAttributes = typeof(T).GetProperties().Select(p => p.GetCustomAttribute<FieldAttribute>()).ToList();
            foreach (var fieldAttribute in fieldsAttributes)
            {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell() {Text = fieldAttribute.Name});
                TableCell valueCell = CreateValueCell(fieldAttribute);
                row.Cells.Add(valueCell);
                this.FormTable.Rows.Add(row);
            }
            this.Controls.Add(FormTable);
        }

        private TableCell CreateValueCell(FieldAttribute fieldAttribute)
        {
            TableCell tableCell = new TableCell();
            tableCell.ID = Guid.NewGuid().ToString();
            switch (fieldAttribute.VariableType)
            {
                case VariableType.Unknown:
                    tableCell.Text = "Unknown cell";
                    break;
                case VariableType.String:
                    tableCell.Controls.Add(new TextBox());
                    break;
                case VariableType.Int:
                    tableCell.Controls.Add(new TextBox());
                    break;
                case VariableType.Bool:
                    tableCell.Controls.Add(new CheckBox());
                    break;
                case VariableType.DropDownMenu:
                    tableCell.Controls.Add(new DropDownList());
                    break;
                case VariableType.Nip:
                    tableCell.Controls.Add(new TextBox(){TextMode = TextBoxMode.Date});
                    break;
                case VariableType.MultiControl:
                    tableCell.Controls.Add(fieldAttribute.CustomControl);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return tableCell;
        }
    }
}