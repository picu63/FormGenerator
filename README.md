# Form Generator
The project was created because of the need for ASP.NET Web Forms technology to create unified forms based on properties in object models.
To use FormGenerator, you must assign provided attributes to the model properties that you need.

## Example demo:

Demo model:

    [Header("User edit")]
    public class User
    {
        [NormalField("userFirstName","First name", VariableType.String) ]
        public string FirstName { get; set; }
        [NormalField("userLastName", "Last name",VariableType.String)]
        public string LastName { get; set; }
        [EnumField("userRole", "Role", ControlDataType.DropDownList, 
			        defaultValue: (int)Models.Role.Manager)]
        public Role Role { get; set; }
        [NormalField("userIsMale?","Is male?", VariableType.Bool)]
        public bool IsMale { get; set; }
    }

#### Usage
ASPX File:

    <asp:PlaceHolder runat="server" ID="dynamicPH"></asp:PlaceHolder>

Code behind:

    dynamicPH.Controls.Add(new FormGenerator<User>()
	    .AddSection(new FieldsSection<User>())
	    .AddSection(new ButtonsSection<User>())
	    .CreateForm()
	    .FillWithData(new User() {FirstName = "Jordan", 
						LastName = "Peterson", 
						Role = Role.Administrator, 
						IsMale = true)));

### Output:
![Form Generator Simple Demo](https://github.com/picu63/FormGenerator/blob/master/Documentation/img/formGeneratorSimpleDemo.png)

## Attributes
- `DataFieldAttribute` - Represents 
