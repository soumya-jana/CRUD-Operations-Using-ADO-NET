using CRUD_ADO_NET.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_ADO_NET.DAL
{
    public class CustomerDAL
    {

        private readonly IConfiguration _configuration;
        private readonly string connString;
        public CustomerDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            connString = _configuration.GetConnectionString("SqlDbConnection");
        }

        public void CreateCustomer(Customer objCus)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_Add_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerName", objCus.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerEmail", objCus.CustomerEmail);
                cmd.Parameters.AddWithValue("@CustomerGender", objCus.CustomerGender);
                cmd.Parameters.AddWithValue("@CustomerDOB", objCus.CustomerDOB);
                cmd.Parameters.AddWithValue("@CustomerPhone", objCus.CustomerPhone);
                cmd.Parameters.AddWithValue("@CustomerSurvey", objCus.CustomerSurvey);

                // open connection
                if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
                {
                    con.Open();
                }

                cmd.ExecuteNonQuery();

                // close connection
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public IEnumerable<Customer> RetrieveCustomers(int CustomerID)
        {
            var customers = new List<Customer>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connString))
            {

                SqlCommand cmd = new SqlCommand("dbo.usp_Get_Customers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
                // open connection
                if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
                {
                    con.Open();
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                customers = (from r in dt.AsEnumerable()
                                select new Customer()
                                {
                                    CustomerID = r.Field<Int32>("CustomerID"),
                                    CustomerName = r.Field<string>("CustomerName"),
                                    CustomerEmail = r.Field<string>("CustomerEmail"),

                                    CustomerGender = r.Field<string>("CustomerGender"),
                                    CustomerDOB = r.Field<string>("CustomerDOB"),
                                    CustomerPhone = r.Field<string>("CustomerPhone"),
                                    CustomerSurvey = r.Field<string>("CustomerSurvey")
                                }).ToList<Customer>();

                // close connection
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return customers;
        }        

        public void UpdateCustomer(Customer objCus)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_Set_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerID", objCus.CustomerID);
                cmd.Parameters.AddWithValue("@CustomerName", objCus.CustomerName);
                cmd.Parameters.AddWithValue("@CustomerEmail", objCus.CustomerEmail);
                cmd.Parameters.AddWithValue("@CustomerGender", objCus.CustomerGender);
                cmd.Parameters.AddWithValue("@CustomerDOB", objCus.CustomerDOB);
                cmd.Parameters.AddWithValue("@CustomerPhone", objCus.CustomerPhone);
                cmd.Parameters.AddWithValue("@CustomerSurvey", objCus.CustomerSurvey);

                // open connection
                if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
                {
                    con.Open();
                }

                cmd.ExecuteNonQuery();

                // close connection
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public void DeleteCustomer(int CustomerID)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("dbo.usp_Del_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                // open connection
                if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
                {
                    con.Open();
                }

                cmd.ExecuteNonQuery();

                // close connection
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

    }
}
