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
            if (TreeView1.SelectedNode.Text == "退出系统")
            {
                Response.Write("<script lanuage=javascript>window.close();location='javascript:history.go(-1)'</script>");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvQueInfo.PageIndex = e.NewPageIndex;
            datacon.ecadabind(gvQueInfo, "select * from kecheng_taoti_view where " + ddlQueName.SelectedValue + " like '%" + txtSelect.Text + "%'");
        }
        //行绑定事件
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType==DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Text = Convert.ToString(Convert.ToDateTime(e.Row.Cells[2].Text).ToShortDateString());
                ((LinkButton)(e.Row.Cells[4].Controls[0])).Attributes.Add("onclick", "return confirm('确定删除吗')");
            }
        }
        //删除
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            datacon.eccom("delete from  tb_TaoTi where ID='" + gvQueInfo.DataKeys[e.RowIndex].Value + "'");
            Page.Response.Redirect("taoti_xinxi.aspx");
        }
        //查询
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

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("TaotiInsert.aspx");
        }
    }
}