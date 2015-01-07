using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace NetExamination
{
    public partial class Default : System.Web.UI.Page
    {
        DataCon datacon = new DataCon();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["StudentName"] =this.txtUserName.Text;//学生证号d
            if(!IsPostBack)
            {

                Random rm = new Random();
                this.lblValiDate.Text = rm.Next(1000, 9999).ToString();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtValiDate.Text!=lblValiDate.Text)
            {
                Response.Write("<script>alert('验证码有误！')location='javascript:history.go(-1)'</script>");
            }
            else
            {
                if (cbAdminLogin.Items[0].Selected == true)
                    getcom(1);
                else
                    getcom(2);
            }
        }

        private void getcom(int type)
        {
            SqlConnection conn = datacon.getcon();
            conn.Open();
            string sql=string.Empty;
            SqlCommand cmd=conn.CreateCommand();
            switch(type)
            {
                case 1:
                    sql="select COUNT(*) from tb_Administrator where NAME='"+txtUserName.Text+"' and PWD='"+txtPWD.Text+"'";
                    cmd.CommandText=sql;
                    int count1=Convert.ToInt32(cmd.ExecuteScalar());
                    if(count1>0)
                    {
                        Application["NAME"]=txtUserName.Text;
                        Application["PWD"]=txtPWD.Text;
                        Response.Redirect("HouAdmin/Admin.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('验证码有误！')location='javascript:history.go(-1)'</script>");
                    }
                    break;
                case 2:
                    sql = "select COUNT(*) from tb_Student where Name='" + txtUserName.Text + "' and PWD='" + txtPWD.Text + "'";
                    cmd.CommandText = sql;
                    int count2 = Convert.ToInt32(cmd.ExecuteScalar());
                    if(count2>0)
                    {
                        Application["NAME"]=txtUserName.Text;
                        Application["PWD"]=txtPWD.Text;
                        Response.Redirect("QianUser/zaixian_kaoshi.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('验证码有误！')location='javascript:history.go(-1)'</script>");
                    }
                    break;

            }
        }

        protected void btnZC_Click(object sender, EventArgs e)
        {
            Response.Redirect("zhuce.aspx");
        }

        protected void btnFindPWD_Click(object sender, EventArgs e)
        {
            Response.Redirect("InfoPwd.aspx");
        }
    }
}