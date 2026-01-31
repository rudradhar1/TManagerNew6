using System.Data;
using System.Data.SqlClient;

namespace TManagerNew6
{
    class DB
    {
        public static SqlConnection con = new SqlConnection(
            @"Data Source=RUDRA-DHAR\SQLEXPRESS;Initial Catalog=TManagerNew6DB;Integrated Security=True");

        public static DataTable GetData(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void Execute(string query)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
