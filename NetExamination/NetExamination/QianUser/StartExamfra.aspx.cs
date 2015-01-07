using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace NetExamination.QianUser
{
    public partial class StartExamfra : System.Web.UI.Page
    {
        DataCon datacon = new DataCon();
        static int int_row1 = 0;//单选题题号索引
        static int int_row2 = 0;//多选题题号索引
        static int int_row1Point = 0;//单选题分数
        static int int_row2Point = 0;//多选题分数
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.getCom(1);
                this.getCom(2);
            }
        }

        private void getCom(int i)
        {
            string dd1 = Application["d1"].ToString();//课程编号
            string dd2 = Application["d2"].ToString();//套题编号
            string sql = string.Empty;
            SqlConnection conn = datacon.getcon();
            switch (i)
            {
                #region 从数据库中获取单选题
                case 1:
                    sql = "select * from tb_Questions where que_type='单选题' and que_lessonid=" + dd1 + " and que_taotiid=" + dd2 + "";
                    SqlDataAdapter sdr1 = new SqlDataAdapter(sql, conn);
                    DataSet ds1 = new DataSet();
                    sdr1.Fill(ds1);
                    dlSigOption.DataSource = ds1;
                    dlSigOption.DataBind();
                    //生成单选题题号
                    for (int id1 = 0; id1 < dlSigOption.Items.Count; id1++)
                    {
                        Label lblSelect = (Label)dlSigOption.Items[id1 - 1].FindControl("lblSingle");
                        lblSelect.Text = id1.ToString() + "、";
                    }
                    break;
                #endregion

                #region 从数据库中获取多选题
                case 2:
                    sql = "select * from tb_Questions where que_type='多选题' and que_lessonid=" + dd1 + " and que_taotiid=" + dd2 + "";
                    SqlDataAdapter sdr2 = new SqlDataAdapter(sql, conn);
                    DataSet ds2 = new DataSet();
                    sdr2.Fill(ds2);
                    dlSigOption.DataSource = ds2;
                    dlSigOption.DataBind();
                    for (int id2 = 0; i < dlSigOption.Items.Count; id2++)
                    {
                        Label lblSelect = (Label)dlSigOption.Items[id2 - 1].FindControl("lblSingle");
                        lblSelect.Text = id2.ToString() + "、";
                    }
                    break;
                #endregion

                #region 核对单选题答案
                case 3:
                    sql = "select * from tb_Questions where que_type='单选题' and que_lessonid=" + dd1 + " and que_taotiid=" + dd2 + " order by id desc";
                    SqlDataAdapter sdr3 = new SqlDataAdapter(sql, conn);
                    DataSet ds3 = new DataSet();
                    sdr3.Fill(ds3);
                    DataRow[] row3 = ds3.Tables[0].Select();
                    //计算单选题成绩
                    foreach(DataRow answer1 in row3)
                    {
                        int_row1++;
                        if(int_row1<=3)
                        {
                            RadioButtonList rb3 = (RadioButtonList)(dlSigOption.Items[int_row1 - 1].FindControl("RadioButtonList1"));
                            if(rb3.SelectedValue=="")
                            {
                                lblSel.Text = "0";
                            }
                            else
                            {
                                if (answer1["que_answer"].ToString().Trim() == rb3.SelectedValue.ToString().Trim())
                                {
                                    int_row1Point += 40 / dlSigOption.Items.Count;
                                    lblSel.Text = int_row1Point.ToString();
                                }
                            }
                        }
                    }
                    break;
                #endregion

                #region 核对多选题答案
                case 4:
                    sql = "select * from tb_Questions where que_type='多选题' and que_lessonid=" + dd1 + " and que_taotiid=" + dd2 + " order by id desc";
                    SqlDataAdapter sdr4 = new SqlDataAdapter(sql, conn);
                    DataSet ds4 = new DataSet();
                    sdr4.Fill(ds4);
                    DataRow[] row4 = ds4.Tables[0].Select();
                    //计算多选题成绩
                    foreach (DataRow answer2 in row4)
                    {
                        int_row2++;
                        if (int_row2 <= 3)
                        {
                            CheckBoxList cb1 = (CheckBoxList)(dlSigOption.Items[int_row1 - 1].FindControl("RadioButtonList2"));
                            if (cb1.SelectedValue == "")
                            {
                                lblDSel.Text = "0";
                            }
                            else
                            {
                                this.TextBox1.Text = "";
                                for (int t = 0; t < cb1.Items.Count; t++)
                                {
                                    if(cb1.Items[t].Selected==true)
                                    {
                                        this.TextBox1.Text = TextBox1.Text.Trim()+cb1.Items[i].Value+',';
                                    }
                                }
                                if (answer2["que_answer"].ToString().Trim() ==TextBox1.Text.Trim())
                                {
                                    int_row2Point += 40 / dlMulOption.Items.Count;
                                    lblDSel.Text = int_row2Point.ToString();
                                }
                            }
                        }
                    }
                    break;
                #endregion
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Label12.Visible = Label13.Visible = Label14.Visible = Label15.Visible = Label9.Visible = Label16.Visible = true;
            int_row1 = 0;//单选题题号索引
            int_row2 = 0;//多选题题号索引
            int_row1Point = 0;//单选题分数
            int_row2Point = 0;//多选题分数   
            this.lblStuID.Text = Session["StuID"].ToString();
            this.lblSubject.Text = Session["SelLession"].ToString();
            this.lblQuestion.Text = Session["SetTile"].ToString();
            this.getCom(3);
            this.getCom(4);
            this.lblTotal.Text = Convert.ToString(int_row1Point + int_row2Point);
            string sql=string.Format("insert into tb_StuResult(stu_id,which_lesson,taotiid,taotiname,res_single,res_more,res_total)values('{0}','{1}',{2},'{3}',{4},{5},{6})"
                ,lblStuID.Text,lblSubject.Text,Application["d2"].ToString(),lblQuestion.Text,int_row1Point,int_row2Point,lblTotal.Text);
            //this.getCom(5);
            Response.Write("<script lanuage=javascript>alert('您确定要交卷吗？');localtion='StartExamfra.aspx';</script>");
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Write("<script lanuage=javascript>window.close();location='javascript:history.go(-1)'</script>");
        }
    }
}