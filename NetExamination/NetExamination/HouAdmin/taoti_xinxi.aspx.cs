using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace NetExamination.HouAdmin
{
    public partial class taoti_xinxi : System.Web.UI.Page
    {
        DataCon datacon = new DataCon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                datacon.ecadabindinfostring(gvQueInfo, "Select * From kecheng_taoti_view ORDER BY Id DESC", "ID");
            }
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txtSelect.Text=="")
            {
                datacon.ecadabindinfostring(gvQueInfo, "Select * From kecheng_taoti_view ORDER BY Id DESC", "ID");
            }
            else
            {

                datacon.ecadabindinfostring(gvQueInfo, "select * from kecheng_taoti_view where "+ddlQueName.SelectedValue+" like '%"+txtSelect.Text+"%';", "ID");
            }
        }
    }
}