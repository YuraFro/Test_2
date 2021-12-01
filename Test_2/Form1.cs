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

        //Создание переменых для выделение памяти в начале запуска приложения
        Bitmap b;
        Moduls moduls;

        string response;
        string urlVideo = "http://uniserver.vesysoft.ru:8123/core/plugins/Camera1/Video?Width=596&Height=409&auth_user=user&auth_password=user";
        string urlMass = "http://uniserver.vesysoft.ru:8123/core/SendMsg?Name=AutoScale1_GetParameters&auth_user=user&auth_password=user";

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //Получение данных о весах
        private async void timer1_Tick(object sender, EventArgs e)
        {
            //Отсылаем запрос по url и получаем ответ в виде потока
            HttpWebRequest httpWebRequest2 = (HttpWebRequest)WebRequest.Create(urlMass);

            HttpWebResponse httpWebResponse2 = await httpWebRequest2.GetResponseAsync() as HttpWebResponse;

            //читаем поток и выводим структуру json файла в переменную
            using (StreamReader streamReader = new StreamReader(httpWebResponse2.GetResponseStream()))
            {
                response = await streamReader.ReadToEndAsync();
            }

            //Десерелезируем переменную в объект класса, совподающий по структуре переменных с json файлом
            moduls = JsonConvert.DeserializeObject<Moduls>(response);


            //помещаем данные о весах
            textBox1.Text = moduls.Massa.ToString();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //проверяем включены таймеры
            if ((timer1.Enabled & timer1.Enabled) != true)
            {
                button1.Text = "Стоп";
                timer1.Enabled = true;
                timer2.Enabled = true;
            }
            else
            {
                button1.Text = "Старт";
                timer1.Enabled = false;
                timer2.Enabled = false;
            }
        }

        //Получение данных с видеокамеры
        private async void timer2_Tick(object sender, EventArgs e)
        {
            //Отсылаем запрос по url и получаем ответ в виде потока
            HttpWebRequest httpWebRequest3 = (HttpWebRequest)WebRequest.Create(urlVideo);

            HttpWebResponse httpWebResponse3 = await httpWebRequest3.GetResponseAsync() as HttpWebResponse;

            //читаем поток и преобразуем в тип данных bitmap
            using (StreamReader stream = new StreamReader(httpWebResponse3.GetResponseStream()))
            {
                b = new Bitmap(stream.BaseStream);
            }

            //помещаем картинку в picturebox
            pictureBox1.Image = b;
        }
    }
}
