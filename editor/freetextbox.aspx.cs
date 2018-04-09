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
using Microsoft.Win32;  


namespace editor
{
  
    public partial class freetextbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
          //  AddNewSiteToCompatibilityViewList("localhost");
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


}/* private const string CLEARABLE_LIST_DATA = @"Software\Microsoft\Internet Explorer\BrowserEmulation\ClearableListData";
        private const string USERFILTER = "UserFilter";
        private byte[] header = new byte[] { 0x41, 0x1F, 0x00, 0x00, 0x53, 0x08, 0xAD, 0xBA };
        private byte[] delim_a = new byte[] { 0x01, 0x00, 0x00, 0x00 };
        private byte[] delim_b = new byte[] { 0x0C, 0x00, 0x00, 0x00 };
        private byte[] checksum = new byte[] { 0xFF, 0xFF, 0xFF, 0xFF };
        private byte[] filler = BitConverter.GetBytes(DateTime.Now.ToBinary());//new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01 };  
        private byte[] regbinary = new byte[] { };  
        private string[] GetDomains()
        {
            string[] domains = { };
            using (RegistryKey regkey = Registry.CurrentUser.OpenSubKey(CLEARABLE_LIST_DATA))
            {
                //可能不存在此key.  
                Object filterData = regkey.GetValue(USERFILTER);
                if (filterData != null)
                {
                    byte[] filter = filterData as byte[];
                    domains = GetDomains(filter);
                }
            }
            return domains;
        }
        private string[] GetDomains(byte[] filter)
        {
            List<string> domains = new List<string>();
            int length;
            int offset_filter = 24;
            int totalSize = filter.Length;
            while (offset_filter < totalSize)
            {
                length = BitConverter.ToUInt16(filter, offset_filter + 16);
                domains.Add(System.Text.Encoding.Unicode.GetString(filter, 16 + 2 + offset_filter, length * 2));
                offset_filter += 16 + 2 + length * 2;
            }
            return domains.ToArray();
        }  
        private void AddNewSiteToCompatibilityViewList(String domain)
        {
            String[] domains = GetDomains();
            if (domains.Length > 0)
            {
                if (domains.Contains(domain))
                {
                    return;
                }
                else
                {
                    domains = domains.Concat(new String[] { domain }).ToArray();
                }
            }
            else
            {
                domains = domains.Concat(new String[] { domain }).ToArray();
            }

            int count = domains.Length;
            byte[] entries = new byte[0];
            foreach (String d in domains)
            {
                entries = this.Combine(entries, this.GetDomainEntry(d));
            }
            regbinary = header;
            regbinary = this.Combine(regbinary, BitConverter.GetBytes(count));
            regbinary = this.Combine(regbinary, checksum);
            regbinary = this.Combine(regbinary, delim_a);
            regbinary = this.Combine(regbinary, BitConverter.GetBytes(count));
            regbinary = this.Combine(regbinary, entries);
            Registry.CurrentUser.OpenSubKey(CLEARABLE_LIST_DATA, true).SetValue(USERFILTER, regbinary, RegistryValueKind.Binary);
        }
        private byte[] Combine(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            System.Buffer.BlockCopy(a, 0, c, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
            return c;
        }
        private byte[] GetDomainEntry(String domain)
        {
            byte[] tmpbinary = new byte[0];
            byte[] length = BitConverter.GetBytes((UInt16)domain.Length);
            byte[] data = System.Text.Encoding.Unicode.GetBytes(domain);
            tmpbinary = Combine(tmpbinary, delim_b);
            tmpbinary = Combine(tmpbinary, filler);
            tmpbinary = Combine(tmpbinary, delim_a);
            tmpbinary = Combine(tmpbinary, length);
            tmpbinary = Combine(tmpbinary, data);
            return tmpbinary;
        }  
       */