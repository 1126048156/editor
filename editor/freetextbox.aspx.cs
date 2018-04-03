using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace editor
{
    public partial class freetextbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" || FreeTextBox1.Text == "")
            {
                Response.Write("名称和内容不能为空");
            }
            else
            {
                String str = ConfigurationManager.ConnectionStrings["editorConnectionString"].ConnectionString.ToString();
                SqlConnection con = new SqlConnection(str);
                con.Open();
                String insert = "insert into tb_sj_news values(@title,@contents,@source,@dates,@author,@editor)";
                SqlCommand cmd = new SqlCommand(insert,con);
                cmd.Parameters.Add("@title",SqlDbType.VarChar,50);
                cmd.Parameters.Add("contents", SqlDbType.VarChar, 5000);
                cmd.Parameters.Add("source", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("dates", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("author", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("editor", SqlDbType.VarChar, 50);
                cmd.Parameters["@title"].Value = TextBox1.Text.ToString();
                cmd.Parameters["contents"].Value = FreeTextBox1.ViewStateText.Replace("'","'");//通过replace属性，替换控件中的特殊字符
                cmd.Parameters["source"].Value = TextBox3.Text.ToString();
                cmd.Parameters["dates"].Value = DateTime.Now.ToString();
                cmd.Parameters["author"].Value = TextBox2.Text.ToString();
                cmd.Parameters["editor"].Value = TextBox4.Text.ToString();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script language='javascript'>alert('成功')</script>");
            }
        }
    }
}