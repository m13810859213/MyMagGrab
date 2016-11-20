using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagGrab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            //HttpClient client = new HttpClient();
            //var result = client.GetStringAsync(tbUrl.Text);
            //var content = result.Result;
            webBrowser1.Url =new Uri( tbUrl.Text);
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument document = webBrowser1.Document;
            var dl = document.GetElementsByTagName("dl");
            var dds = document.GetElementsByTagName("dd");
            Regex reg = new Regex(@"^(.*E\d{2}.*)|(.*Ep\d{2}.*)$");
            foreach (HtmlElement dd in dds)
            {
                if(reg.IsMatch(dd.InnerText))
                {
                    dd.OuterHtml = null;
                }
            }
        }
    }
}
