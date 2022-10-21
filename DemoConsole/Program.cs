/*
 * Connection string
 * Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
 */

// See https://aka.ms/new-console-template for more information
using System.Configuration;
using System.Data.SqlClient;

Console.WriteLine("List of People from DB");

string connstr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

using (SqlConnection con = new SqlConnection(connstr))
{
    con.Open();
    string sql = "GetPeople";

    using (SqlCommand cmd = new SqlCommand(sql, con))
    {
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        var reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            Console.WriteLine($"ID: {reader[0].ToString()} Title: {reader[1].ToString()} First Name {reader[2].ToString()} Last Name: {reader[3].ToString()}");
        }
    }
}