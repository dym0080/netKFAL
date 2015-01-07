using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace NetExamination.HouAdmin
{
    public partial class TaotiUpdate : System.Web.UI.Page
    {
        DataCon datacon = new DataCon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                datacon.ecDropDownList(ddlLesson, "","Name","id");
                SqlConnection con = datacon.getcon();
                SqlDataAdapter sdr = new SqlDataAdapter("select * from tb_TaoTi where id="+ Request["id"], con);
                DataSet ds = new DataSet();
                sdr.Fill(ds, "tb_TaoTi");
                DataRowView rowView = ds.Tables["tb_TaoTi"].DefaultView[0];
                this.txtQueName.Text = Convert.ToString(rowView["Name"]);
                ddlLesson.Text = Convert.ToString(rowView["LessonID"]);
                con.Close();
            }
        }
    }
}