using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicTest.Tests
{
    public partial class Test03 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = new List<string>() {"value01", "value02"};
            ddlWithData.DataSource = list;
            ddlWithData.DataBind();
        }
    }
}