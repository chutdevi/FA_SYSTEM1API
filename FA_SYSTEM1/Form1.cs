//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FA_SYSTEM1
{
    public partial class Form1 : Form
    {
  
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string reqUrl = "http://192.168.161.102/api_system/Api_emptransfer/user_ck?user=01802";

            Uri address = new Uri(reqUrl);

            // Create the web request
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            // Set type to POST
            request.Method = "GET";
            request.ContentType = "text/json";
            string strOutputXml;
            try
            {
                   using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        // Get the response stream
                        StreamReader reader = new StreamReader(response.GetResponseStream());

                        // Console application output
                        strOutputXml = reader.ReadToEnd();
                    //Console.WriteLine(strOutputXml);

                    JArray json = JArray.Parse(strOutputXml);
                    //JObject json = JObject.Parse(strOutputXml);
                    Console.WriteLine(json);
                    // Console.WriteLine( textArray[0]["USER_CD"] + "  " + textArray[0]["USER_TNAME"]);

                    //label1.Text = json["rates"]["JPY"].ToString();
                    }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
 
        }
    }
}
