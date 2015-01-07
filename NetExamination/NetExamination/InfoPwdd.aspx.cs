using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace NetExamination
{
    public partial class InfoPwdd : System.Web.UI.Page
    {
        DataCon datacon = new DataCon();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from tb_Student where ID='" + Convert.ToString(Session["ID"])+ "'";
            SqlConnection conn = datacon.getcon();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            labQuePwd.Text =Convert.ToString( cmd.ExecuteScalar());
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from tb_Student where ID='" + Convert.ToString(Session["ID"]) + "' AND Answer='"+txtAnsPwd.Text.Trim()+"'";
            SqlConnection conn = datacon.getcon();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int count =Convert.ToInt32(cmd.ExecuteScalar());
            if(count>0)
            {
                Page.Response.Redirect("InfoPwddd.aspx");
            }
            else
            {
                Response.Write("<script>alert('提示问题答案输入不正确！');location='javascript:history.go(-1)'</script>");
                return;
            }
            conn.Close();
        }
    }
}