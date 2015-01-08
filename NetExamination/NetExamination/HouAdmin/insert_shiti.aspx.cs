using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace NetExamination.HouAdmin
{
    
    public partial class insert_shiti : System.Web.UI.Page
    {
        DataCon datacon = new DataCon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                datacon.ecDropDownList(ddlProfession, "", "Name", "id");
                GetDropDownList();
            }
            this.Label5.Visible = false;
        }

        private void GetDropDownList()
        {
            string sqlLesson="select * from tb_Lesson where ofprofession='"+ddlProfession.SelectedValue.ToString()+"'";
            string sqlQunName="select a.*,b.ofProfession from tb_TaoTi as a join tb_Lesson as b on a.LessonID=b.ID where a.LessonID='"+ddlLesson.SelectedValue.ToString()+"' and b.ofProfession='"+ddlProfession.SelectedValue.ToString()+"'";
            datacon.ecDropDownList(ddlLesson, sqlLesson, "Name", "id");
            datacon.ecDropDownList(ddlQueName, "", "Name", "id");
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Session["drop1"] = ddlProfession.Text;//保存专业信息
            Session["drop2"] = ddlLesson.Text;    //保存课程信息
            Session["drop3"] = ddlQueName.Text;   //保存套题信息
            if(this.ddlLesson.Text=="")
            {
                this.Label3.Visible = true;
            }
            if(this.ddlQueName.Text=="")
            {
                this.Label5.Visible = true;
            }
            Page.Response.Redirect("InsertShiTi.aspx");
        }

        protected void ddlProfession_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDropDownList();
        }

        protected void ddlLesson_SelectedIndexChanged(object sender, EventArgs e)
        {
            datacon.ecDropDownList(ddlQueName, "select * from tb_TaoTi where LessonID='" + ddlLesson.SelectedValue.ToString() + "'", "Name", "id");
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (TreeView1.SelectedNode.Text == "退出系统")
            {
                Response.Write("<script lanuage=javascript>window.close();location='javascript:history.go(-1)'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("insert_shiti.aspx");
        }
    }
}