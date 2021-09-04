using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationExample
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        List<City> cities = new List<City>();
        protected void Page_Load(object sender, EventArgs e)
        {
            cities.Add(new City(1, "Gdańsk"));
            cities.Add(new City(2, "Kraków"));
            cities.Add(new City(3, "Warszawa"));

            DropDownList1.DataSource = cities;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Id";
            DropDownList1.DataBind();

            if (IsPostBack)
            {
                //odczyt checkboxa
                Label1.Text += $"Pojedynczy checkbox: {CheckBox1.Checked} <br/>";
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Selected)
                        Label1.Text += $"Checkbox lista = {item.Value} <br/>";
                }
                Label1.Text += $"dropdown list1: {DropDownList1.SelectedValue} <br/>";
                Label1.Text += $"dropdown list2: {DropDownList2.SelectedValue} <br/>";
                Label1.Text += $"radiobutton list: {RadioButtonList1.SelectedValue} <br/>";
                foreach (var index in ListBox1.GetSelectedIndices())
                {
                    Label1.Text += $"ListBox : {ListBox1.Items[index].Value} <br/>";
                } 
            }

        }
    }
}