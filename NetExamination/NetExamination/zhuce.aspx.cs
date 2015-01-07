using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace NetExamination
{
    public partial class zhuce : System.Web.UI.Page
    {
        DataCon datacon = new DataCon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string sql = "select ID,NAME from tb_Profession";
                datacon.ecDropDownList(ddlProfession, sql, "ID", "Name");
                Label1.Visible = false;
                Label2.Visible = false;
                Label2.Visible = false;
            }
            
        }

        protected void btnCheckStuID_Click(object sender, EventArgs e)
        {
            string sql = "select COUNT(*) from tb_Student where ID='" + txtStuID.Text + "'";
            SqlConnection conn = datacon.getcon();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
                Label2.Visible = true;
            else
                Label3.Visible = true;
            conn.Close();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string sql =string.Format("insert tb_Student(ID,Name,PWD,Sex,Question,Answer,profession)values('{0}','{1}','{2}','{3}','{4}','{5}',{6})"
                ,txtStuID.Text,txtStuPwd.Text,ddlSex.SelectedValue,txtQuePwd.Text,txtAnsPwd.Text,ddlProfession.SelectedItem);
            if(datacon.eccom(sql))
            {
                Label1.Visible = true;
            }
            else
            {
                Response.Write("<script>alert('注册失败！');location='javascript:history.go(-1)'</script>");
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtStuID.Text = "";
            txtAnsPwd.Text = "";
            txtQuePwd.Text = "";
            txtStuFPwd.Text = "";
            txtStuPwd.Text = "";
            txtStuName.Text = "";
            txtStuID.Focus();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}