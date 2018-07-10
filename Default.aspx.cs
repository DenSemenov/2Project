using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

namespace _2Project
{
    public partial class Default : System.Web.UI.Page
    {
        public string num;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetHistory();
            GetIDs();
        }

        void GetIDs()
        {

            HttpClient client = new HttpClient();

            var response = client.GetStringAsync("http://localhost:2099/api/GetIDDocs");

            string res = response.Result.ToString().Replace("[", "").Replace("]", "").Replace("\"", "");

            string[] elems = res.Split(',');

            for (int i = 0; i < elems.Length; i++)
            {
                IDDoc.Items.Add(elems[i]);
            }
        }

        void GetHistory()
        {
            History.Controls.Clear();

            HttpClient client = new HttpClient();

            var response = client.GetStringAsync("http://localhost:2099/api/GetStatuses");

            string res = response.Result.ToString().Replace("[", "").Replace("]", "").Replace("\"", "");

            string[] elems = res.Split(',');

            for (int i = 0; i < elems.Length / 3; i++)
            {
                Label l1 = new Label();
                l1.Width = 50;
                Label l2 = new Label();
                l2.Width = 150;
                Label l3 = new Label();

                l1.Text = elems[i];
                l2.Text = elems[i + elems.Length / 3];
                l3.Text = elems[i + elems.Length / 3 * 2] + " <br>";

                History.Controls.Add(l1);
                History.Controls.Add(l2);
                History.Controls.Add(l3);
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();

            var response = client.GetStringAsync("http://localhost:2099/api/savestatus/"+IDDoc.Text+","+Statuses.Text);

            Label3.Text = response.Result.ToString().Replace("\"","");

            GetHistory();
            IDDoc.Items.Clear();
            GetIDs();
        }

        protected void IDDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        void Search()
        {
            History.Controls.Clear();

            HttpClient client = new HttpClient();
            string url = "http://localhost:2099/api/search/" + Calendar1.SelectedDate.Date.ToString().Replace(" 0:00:00", "").Replace("{", "").Replace("}", "").Replace(".","_") + "," + Calendar2.SelectedDate.Date.ToString().Replace(" 0:00:00", "").Replace("{", "").Replace("}", "").Replace(".", "_") + "," + idSearch.Text;
            var response = client.GetStringAsync(url);

            string res = response.Result.ToString().Replace("[", "").Replace("]", "").Replace("\"", "");

            string[] elems = res.Split(',');

            for (int i = 0; i < elems.Length / 3; i++)
            {
                Label l1 = new Label();
                l1.Width = 50;
                Label l2 = new Label();
                l2.Width = 150;
                Label l3 = new Label();

                l1.Text = elems[i];
                l2.Text = elems[i + elems.Length / 3];
                l3.Text = elems[i + elems.Length / 3 * 2] + " <br>";

                History.Controls.Add(l1);
                History.Controls.Add(l2);
                History.Controls.Add(l3);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}