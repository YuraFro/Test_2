using Newtonsoft.Json;
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

namespace Test_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url1 = "http://uniserver.vesysoft.ru:8123/core/plugins/WeightIndicator1/Enable?Enable=true&auth_user=user&auth_password=user";
            string url2 = "http://uniserver.vesysoft.ru:8123/core/SendMsg?Name=WeightIndicator1_GetParameters&auth_user=user&auth_password=user";


            HttpWebRequest httpWebRequest1 = (HttpWebRequest)WebRequest.Create(url1);

            HttpWebResponse httpWebResponse1 = (HttpWebResponse)httpWebRequest1.GetResponse();


            HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(url2);

            HttpWebResponse httpWebResponse2 = (HttpWebResponse)httpWebRequest2.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse2.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            var modul = JsonConvert.DeserializeObject<Moduls>(response);

            textBox1.Text = modul.Massa.ToString();

            //string url3 = "http://uniserver.vesysoft.ru:8123/core/SendMsg?Name=Camera1_Enable&Value=true&auth_user=user&auth_password=user";
            string url4 = "http://uniserver.vesysoft.ru:8123/core/plugins/Camera1/Video?Width=596&Height=409&auth_user=user&auth_password=user";
            //HttpWebRequest httpWebRequest1 = (HttpWebRequest)WebRequest.Create(url3);

            //HttpWebResponse httpWebResponse1 = (HttpWebResponse)httpWebRequest1.GetResponse();


            HttpWebRequest httpWebRequest3 = (HttpWebRequest)WebRequest.Create(url4);

            HttpWebResponse httpWebResponse3 = (HttpWebResponse)httpWebRequest3.GetResponse();

            //using (StreamReader streamReader = new StreamReader(httpWebResponse2.GetResponseStream()))
            //{
            //    pictureBox1 = streamReader.ReadToEnd();
            //}

            Bitmap b = new Bitmap(httpWebResponse3.GetResponseStream());

            pictureBox1.Image = b;
        }
    }
}
