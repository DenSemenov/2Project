using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _2Project.Controllers
{
    public class SaveStatusController : ApiController
    {
        // GET: api/SaveStatus
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SaveStatus/5
        public string Get(string id)
        {
            id = id.Replace("[", "").Replace("]", "").Replace("\"", "");

            string[] values = id.Split(',');

            SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS; Integrated Security = true; Initial Catalog = Documents");

            SqlCommand com = new SqlCommand("insert into StatusHistory values('" + values[0] + "', getdate(), '" + values[1] + "')", con);
            SqlDataAdapter a = new SqlDataAdapter(com);
            DataTable data = new DataTable();
            a.Fill(data);

            return "Успешно сохранено";

        }

        // POST: api/SaveStatus
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SaveStatus/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SaveStatus/5
        public void Delete(int id)
        {
        }
    }
}
