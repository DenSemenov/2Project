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
    public class GetIDDocsController : ApiController
    {
        // GET: api/GetIDDocs
        public IEnumerable<string> Get()
        {
            SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS; Integrated Security = true; Initial Catalog = Documents");

            SqlCommand com = new SqlCommand("select id_doc from docs", con);
            SqlDataAdapter a = new SqlDataAdapter(com);
            DataTable data = new DataTable();
            a.Fill(data);
            string[] ids = new string[data.Rows.Count];

            for (int i = 0; i < data.Rows.Count; i++)
            {
                ids[i] = data.Rows[i][0].ToString();
            }

            return ids;
        }

        // GET: api/GetIDDocs/5
        public string Get(int id)
        {
            return null;
        }

        // POST: api/GetIDDocs
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetIDDocs/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetIDDocs/5
        public void Delete(int id)
        {
        }
    }
}
