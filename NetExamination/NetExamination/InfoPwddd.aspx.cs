using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace NetExamination
{
    public partial class InfoPwddd : System.Web.UI.Page
    {
        DataCon datacon = new DataCon();
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select PWD from tb_Student where ID='"+Convert.ToString(Session["ID"])+"' ";
            SqlConnection conn = datacon.getcon();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            txtStuPwd.Text = Convert.ToString(cmd.ExecuteScalar());
            txtStuID.Text = Convert.ToString(Session["ID"]);
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}