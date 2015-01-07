using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace NetExamination
{
    public class DataCon
    {
        public DataCon()
        { }
        /// <summary>
        /// 建立数据库连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection getcon()
        {
            string strCon = ConfigurationManager.ConnectionStrings["ConStr"].ToString();
            SqlConnection conn = new SqlConnection(strCon);
            return conn;
        }
        /// <summary>
        /// 执行数据库操作命令
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool eccom(string sql)
        {
            SqlConnection conn = this.getcon();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }

        }
        /// <summary>
        /// 将数据绑定到数据列表控件
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ecadabind(GridView gv, string sql)
        {
            SqlConnection conn = this.getcon();
            conn.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            sdr.Fill(ds);
            gv.DataSource = ds;
            try
            {
                gv.DataBind();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 绑定数据到下拉列表控件
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="sql"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ecDropDownList(DropDownList ddl, string sql, string name, string value)
        {
            SqlConnection conn = this.getcon();
            conn.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            sdr.Fill(ds);
            ddl.DataSource = ds;
            ddl.DataTextField = name;
            ddl.DataValueField = value;
            try
            {
                ddl.DataBind();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 在表格控件中获取数据主键字段
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="sql"></param>
        /// <param name="pk"></param>
        /// <returns></returns>
        public bool ecadabindinfostring(GridView gv, string sql, string pk)
        {
            SqlConnection conn = this.getcon();
            conn.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            sdr.Fill(ds);
            gv.DataSource = ds;
            gv.DataKeyNames = new string[] { pk };
            try
            {
                gv.DataBind();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 数据读取
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlDataReader ExceRead(string sql)
        {
            SqlConnection conn = this.getcon();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sqlRead = cmd.ExecuteReader();
            return sqlRead;
        }
    }
}
