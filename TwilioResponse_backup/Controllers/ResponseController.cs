using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;
using Twilio;
using Twilio.TwiML;
using System.Data.SqlClient;
using System.Data;


namespace TwilioResponse.Controllers
{
    public class ResponseController : ApiController
    {
        //
        string constring = "Data Source=SQL5020.Smarterasp.net;Initial Catalog=DB_9D55E2_hnidev;User ID=DB_9D55E2_hnidev_admin;Password=devhni01";
        // GET: /Response/
        [HttpGet]
        public HttpResponse GetResponse(string Body, string FROM)
        {
            var response = new Twilio.TwiML.TwilioResponse();
            string apppath = HttpRuntime.AppDomainAppPath;
            System.IO.File.AppendAllText(apppath + "\\Log.txt", FROM+"\t\n"+"--- "+DateTime.Now.ToString());

            string ACCOUNT_SID = "AC058c29b86fd293d42292a700240d1948";
            string AUTH_TOKEN = "a80e6d26c741ebbfdbfca114b0a3d88f";

            TwilioRestClient client = new TwilioRestClient(ACCOUNT_SID, AUTH_TOKEN);
            //string msg = string.Empty;
            string FromNumber ="+1954-880-3970";
            //string ToNumber = "+15187509634";
            //if (Body == "2")
            //{
            //    msg = "Order not placed. For help or questions please call 1-800-123-1234";
            //    client.SendMessage(FromNumber, TO, msg);
            //}

            //string retval = "'1' Restaurant \n'2' Restaurant \n'3' Restaurnt";
            string retval = GetResp("1", "+15187509634");
            //string retval = GetResp(Body, FROM);
            System.IO.File.AppendAllText(apppath + "\\Log.txt", ",,,---" + retval + "\t\n" + "--- " + DateTime.Now.ToString());
            client.SendMessage(FromNumber, FROM, retval);


            return null;
        }

        private string GetResp(string response, string ToNumber)
        {
            string retval = string.Empty;
             string sql = "dbo.sp_receivedmessages";

             using (SqlConnection conn = new SqlConnection(constring))
             {
                 try
                 {
                     SqlCommand cmd = new SqlCommand(sql, conn);
                     conn.Open();
                     cmd.Parameters.Add("@phone", SqlDbType.VarChar, 100).Value = ToNumber;
                     cmd.Parameters.Add("@choice", SqlDbType.VarChar, 100).Value = response;
                     cmd.Parameters.Add("@returnmessage", SqlDbType.VarChar, 100).Value = DBNull.Value;
                     cmd.CommandType = CommandType.StoredProcedure;
                     SqlDataAdapter adp = new SqlDataAdapter(cmd);
                     DataTable dt = new DataTable();
                     adp.Fill(dt);

                     if (dt.Rows.Count == 1)
                     {
                         return dt.Rows[0][0].ToString();
                     }
                     string[] arr = new string[dt.Rows.Count];
                     for (int i = 0; i < dt.Rows.Count; i++)
                     {
                         
                         arr[i]= dt.Rows[i][0].ToString().Replace("\"", "'");
                     }
                     retval = string.Join("\n", arr);
                     
                     return retval;
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
            return "Error while retrieving the response";
        }
    }
}
