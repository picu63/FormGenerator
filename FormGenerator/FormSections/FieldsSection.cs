using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using FormGenerator.Attributes;
using FormGenerator.FormFiller;
using WebFormsHelper;

namespace FormGenerator.FormSections
{
    /// <summary>
    /// Tworzenie pustej formatki na podstawie typu.
    /// </summary>
    public class FieldsSection<T> : FormSection<T>
    {
        public Table FormTable { get;} = new Table();

        public override void CreateForm()
        {
            FormTable.Rows.Add(CreateTableHeaderRow());
            FormTable.Rows.AddRange(CreateTableRows().ToArray());
            this.Controls.Add(FormTable);
        }

        public override void FillControls(T @object)
        {
            var controlSelector = new ControlSelector();
            var controlFiller = new ControlFiller();
            var fieldFiller = new ControlsFiller<T>(@object, controlFiller, controlSelector);
            var ca = ControlsAdded.ToList();
            fieldFiller.Fill(ca);
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
                row.Cells.Add(new TableCell() {Text = fieldAttribute.Name, ID = fieldAttribute.Id + "NameId"});
                var valueCell = new TableCell(){};
                var controlToAddToValueCell = new Control() {ID = fieldAttribute.Id};
                if (fieldAttribute is NormalFieldAttribute normalFieldAttribute)
                { 
                    controlToAddToValueCell = CreateNormalValueControl(normalFieldAttribute);
                }
                else if (fieldAttribute is DataFieldAttribute dataFieldAttribute)
                {
                    controlToAddToValueCell = CreateDataFieldControl(dataFieldAttribute);
                }
                else if (fieldAttribute is CustomFieldAttribute customFieldAttribute)
                {
                    controlToAddToValueCell = customFieldAttribute.Control;
                }
                else if (fieldAttribute is EnumFieldAttribute enumFieldAttribute)
                {
                    controlToAddToValueCell = CreateEnumFieldAttribute(enumFieldAttribute);
                }

                controlToAddToValueCell.ID = fieldAttribute.Id;
                valueCell.Controls.Add(controlToAddToValueCell);
                row.Cells.Add(valueCell);
                yield return row;
            }
        }

        private Control CreateEnumFieldAttribute(EnumFieldAttribute enumFieldAttribute)
        {
            Control controlToAdd = new Control(){ID = enumFieldAttribute.Id};
            var enumType = base.GetPropertyByFieldId(enumFieldAttribute.Id).PropertyType;
            var enumItems = Enum.GetNames(enumType).Select(enumName => new ListItem(enumName)).ToArray();
            switch (enumFieldAttribute.ControlDataType)
            {
                case ControlDataType.ListBox:
                    var listBox = new ListBox();
                    listBox.Items.AddRange(enumItems);
                    controlToAdd = listBox;
                    break;
                case ControlDataType.DropDownList:
                    var dropDownList = new DropDownList();
                    dropDownList.Items.AddRange(enumItems);
                    controlToAdd = dropDownList;
                    break;
                case ControlDataType.PageWithList:
                    throw new ArgumentException($"{nameof(ControlDataType.PageWithList)} is not supported.");
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return controlToAdd;
        }

        private Control CreateDataFieldControl(DataFieldAttribute dataFieldAttribute)
        {
            Control controlToAdd;
            if (!dataFieldAttribute.Values.Any()) throw new ArgumentException("Collection is empty", $"{nameof(dataFieldAttribute)}.{nameof(dataFieldAttribute.Values)}");
            var controlDataType = dataFieldAttribute.ControlDataType;
            switch (controlDataType)
            {
                case ControlDataType.ListBox:
                    ListBox listBox = new ListBox();
                    listBox.Enabled = false;
                    ListHelper.Fill(listBox, dataFieldAttribute.Values);
                    controlToAdd = listBox;
                    break;
                case ControlDataType.DropDownList:
                    var dropDownList = new DropDownList();
                    ListHelper.Fill(dropDownList, dataFieldAttribute.Values);
                    controlToAdd = dropDownList;
                    break;
                case ControlDataType.PageWithList:
                    // TODO przejście na nowa strona z wyborem pozycji z listy
                    throw new NotImplementedException();
                    controlToAdd = new Button(){Text = "Wybierz", OnClientClick = $"javascript: alert('{nameof(ControlDataType.PageWithList)}: Ta opcja nie jest jeszcze dostępna.')"};
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
                    controlToAdd = new TextBox(){TextMode = TextBoxMode.SingleLine, MaxLength = 10};
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