using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormGenerator.Attributes;
using FormGenerator.FormFiller;

namespace FormGenerator.FormBuilder
{
    public class TableSection<T> : FormSection<T>
    {
        public Table FormTable { get;} = new Table();
        /// <summary>
        /// Tworzenie pustej formatki na podstawie typu.
        /// </summary>
        public TableSection() { }

        public override void CreateForm()
        {
            FormTable.Rows.Add(CreateTableHeaderRow());
            FormTable.Rows.AddRange(CreateTableRows().ToArray());
            this.Controls.Add(FormTable);
        }

        public override void FillControls(T @object)
        {
            var fieldFiller = new ControlsFiller<T>(@object);

            fieldFiller.Fill(ControlsAdded);
        }

        /// <summary>
        /// Tworzenie nagłówka formularza.
        /// </summary>
        private TableHeaderRow CreateTableHeaderRow()
        {
            var headerName = HeaderAttribute.Name;
            var headerRow = new TableHeaderRow();
            headerRow.Cells.Add(new TableCell() {ID = "formHeader" + headerName.Trim(), Text = headerName, ColumnSpan = 2});
            this.FormTable.Rows.AddAt(0,headerRow);
            return headerRow;
        }
        
        /// <summary>
        /// Generuje niewypełnione kontrolki
        /// </summary>
        private IEnumerable<TableRow> CreateTableRows()
        {
            foreach (var fieldAttribute in FieldsAttributes)
            {
                var row = new TableRow();
                row.Cells.Add(new TableCell() {Text = fieldAttribute.Name});
                var valueCell = new TableCell();
                if (fieldAttribute is NormalFieldAttribute normalFieldAttribute)
                { 
                    valueCell.Controls.Add(CreateNormalValueControl(normalFieldAttribute));
                }
                else if (fieldAttribute is DataFieldAttribute dataFieldAttribute)
                {
                    valueCell.Controls.Add(CreateDataFieldControl(dataFieldAttribute));
                }
                row.Cells.Add(valueCell);
                yield return row;
            }
        }

        private Control CreateDataFieldControl(DataFieldAttribute dataFieldAttribute)
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
                    controlToAdd = WebFormsHelper.DropDownListHelper.DropDownListFromEnum<ControlDataType>();
                    break;
                case ControlDataType.PageWithList:
                    controlToAdd = new Button();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            controlToAdd.ID = dataFieldAttribute.Id;
            return controlToAdd;
        }

        private Control CreateNormalValueControl(NormalFieldAttribute normalFieldAttribute)
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
                    controlToAdd = new TextBox(){TextMode = TextBoxMode.Number};
                    break;
                case VariableType.Nip:
                    controlToAdd = new TextBox(){TextMode = TextBoxMode.Color, };
                    break;
                case VariableType.Bool:
                    controlToAdd = new CheckBox();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            controlToAdd.ID = normalFieldAttribute.Id;
            return controlToAdd;
        }
    }
}