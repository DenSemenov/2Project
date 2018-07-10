using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace _2Project.Controllers
{
    public class GetStatusesController : ApiController
    {
        // GET: api/AddDocOnHistory
        public IEnumerable<string> Get()
        {
            SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS; Integrated Security = true; Initial Catalog = Documents");

            SqlCommand com = new SqlCommand("select * from statusHistory order by date desc", con);
            SqlDataAdapter a = new SqlDataAdapter(com);
            DataTable data = new DataTable();
            a.Fill(data);

            string[] statuses = new string[data.Rows.Count*3];

            for (int i = 0; i < data.Rows.Count; i++)
            {
                statuses[i] = data.Rows[i][0].ToString();
                statuses[i+data.Rows.Count] = data.Rows[i][1].ToString();
                statuses[i+data.Rows.Count*2] = data.Rows[i][2].ToString();
            }

            return statuses;
        }

        // GET: api/AddDocOnHistory/5
        public string Get(int id)
        {
            return null;
        }

        // POST: api/AddDocOnHistory
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AddDocOnHistory/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AddDocOnHistory/5
        public void Delete(int id)
        {
        }
    }
}
