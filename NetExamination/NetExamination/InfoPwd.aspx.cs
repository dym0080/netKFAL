using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace NetExamination
{
    public partial class InfoPwd : System.Web.UI.Page
    {
        DataCon dataconn = new DataCon();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string sql = "select * from tb_Student where ID='"+txtStuID.Text+"'";
            SqlConnection conn = dataconn.getcon();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int count=Convert.ToInt32(cmd.ExecuteScalar());
            if(count>0)
            {
                Session["ID"] = txtStuID.Text;
                Page.Response.Redirect("InfoPwdd.aspx");
            }
            else
            {
                Response.Write("<script>alert('无此学生编号或输入有误！');location='javascript:history.go(-1)'</script>");
                return;
            }
            conn.Close();
        }
    }
}