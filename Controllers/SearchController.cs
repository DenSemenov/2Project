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
    public class SearchController : ApiController
    {
        // GET: api/Search
        public IEnumerable<string> Get(string id)
        {
            id = id.Replace("[", "").Replace("]", "").Replace("\"", "").Replace("_", ".");

            string[] values = id.Split(',');

            SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS; Integrated Security = true; Initial Catalog = Documents");
            string sql = "select * from statusHistory where ";
            bool[] tr = new bool[2];
            if (values[2].Length != 0)
            {
                sql += " id_doc=" + values[2];
                tr[0] = true;
            }
            if (values[0] != "01.01.0001")
            {
                if (tr[0])
                {
                    sql += " and";
                }
                sql += " date>='" + values[0]+"'";
                tr[1] = true;
            }

            if (values[1] != "01.01.0001")
            {
                if (tr[1] || tr[0])
                {
                    sql += " and";
                }
                sql += " date<='" + values[1] + "'";
            }

            sql += " order by date desc";

            SqlCommand com = new SqlCommand(sql, con);
            SqlDataAdapter a = new SqlDataAdapter(com);
            DataTable data = new DataTable();
            a.Fill(data);

            string[] statuses = new string[data.Rows.Count * 3];

            for (int i = 0; i < data.Rows.Count; i++)
            {
                statuses[i] = data.Rows[i][0].ToString();
                statuses[i + data.Rows.Count] = data.Rows[i][1].ToString();
                statuses[i + data.Rows.Count * 2] = data.Rows[i][2].ToString();
            }

            return statuses;
        }


        // POST: api/Search
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Search/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Search/5
        public void Delete(int id)
        {
        }
    }
}
