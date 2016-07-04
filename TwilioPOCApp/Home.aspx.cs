using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;
using System.Data.SqlClient;
using System.Data;

namespace TwilioPOCApp
{
    public partial class Home : System.Web.UI.Page
    {

        string constring = "Data Source=SQL5020.Smarterasp.net;Initial Catalog=DB_9D55E2_hnidev;User ID=DB_9D55E2_hnidev_admin;Password=devhni01";
        protected void Page_Load(object sender, EventArgs e)
        {
           
               
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string ACCOUNT_SID = "AC058c29b86fd293d42292a700240d1948";
            string AUTH_TOKEN = "a80e6d26c741ebbfdbfca114b0a3d88f";

            TwilioRestClient client = new TwilioRestClient(ACCOUNT_SID, AUTH_TOKEN);
            for (int i = 0; i < lstnum.Items.Count; i++)
            {

                var retval = client.SendMessage(from.Text,lstnum.Items[i].ToString(), txtsend.Text);
                if (string.IsNullOrEmpty(retval.Body))
                {
                    response.Text += lstnum.Items[i].ToString();
                }
                else
                {
                    RecordSuccessTrans(lstnum.Items[i].ToString(), txtsend.Text, Select.SelectedValue.ToString());
                }
            }


            // var retval =  client.SendSmsMessage(from.Text, to.Text, txtsend.Text);

            response.Visible = true;
            //response.Text = retval.Body;

        }
        private void RecordSuccessTrans(string phoneNumber,string mess,string messSentfor)
        {
            string sql = "dbo.sp_logsenttransactions";
            using (SqlConnection conn = new SqlConnection(constring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.Add("@phone", SqlDbType.VarChar, 100).Value = phoneNumber;
                    cmd.Parameters.Add("@msgsentfor", SqlDbType.VarChar, 100).Value = messSentfor;
                    cmd.Parameters.Add("@msgsent", SqlDbType.VarChar, 100).Value = mess;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);

                }
            }

        }

        private void GetPhoneNumber(string type)
        {
            string sql = "dbo.sp_messagessend";

            using (SqlConnection conn = new SqlConnection(constring))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.Add("@type", SqlDbType.VarChar, 100).Value = type;
                    cmd.Parameters.Add("@phone", SqlDbType.VarChar, 100).Value = DBNull.Value;
                    cmd.Parameters.Add("@sentmessage", SqlDbType.VarChar, 100).Value = DBNull.Value;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    foreach (DataRow item in dt.Rows)
                    {
                        lstnum.Items.Add(item.ItemArray[0].ToString());
                        txtsend.Text = item.ItemArray[1].ToString();
                    }
                   // lstnum.Items.Add("5187509634");
                    sendcount.Text ="Message Length:- "+ txtsend.Text.Length.ToString();
                    sendcount.Visible = true;


                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);

                }
            }


            //   return new DataTable();
        }

        protected void Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstnum.Items.Clear();
            if (Select.SelectedValue.ToString() == "Select")
            {
                lstnum.Items.Clear();
                txtsend.Text = string.Empty;
            }


            GetPhoneNumber(Select.SelectedValue.ToString());
        }
    }
}