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
    public class TableSection<T> : FormSection<T>
    {
        
        public Table FormTable { get; set; }

        /// <summary>
        /// Tworzenie pustej formatki na podstawie typu.
        /// </summary>
        public TableSection() { }

        public override IFinishedSection CreateForm()
        {
            if (this.FormTable is null)
            {
                FormTable = new Table();
            }
            CreateTableHeader();
            CreateTableRows();
            return this;
        }

        /// <summary>
        /// Tworzenie nagłówka formularza.
        /// </summary>
        private void CreateTableHeader()
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
        /// Generuje niewypełnione kontrolki
        /// </summary>
        private void CreateTableRows()
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
                this.FormTable.Rows.Add(row);
            }
            this.Controls.Add(FormTable);
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
                    controlToAdd = new DropDownList();
                    break;
                case ControlDataType.PageWithList:
                    
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
            return controlToAdd;
        }
    }
}