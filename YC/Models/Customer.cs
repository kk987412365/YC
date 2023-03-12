using System;
using System.Collections.Generic;
using YC.Attributes;
using YC.Utilities;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;
using YC.Enums;
using YC.Extension;

namespace YC.Models
{
    public class Customer
    {
        public int SN { get; set; }
        [VerifyAttribute(Required = true, Length = 10)]
        public string Id { get; set; }
        [VerifyAttribute(Required = true, Length = 50)]
        public string Name { get; set; }
        [VerifyAttribute(Required = true)]
        public int Age { get; set; }
        [VerifyAttribute(Required = true, Length = 100)]
        public string Email { get; set; }

        public static string InsertFunc(Customer data)
        {
            try
            {
                var verifyResult = data.Verify();
                if (verifyResult != "success")
                    return verifyResult;

                using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DbConnection.YC.GetDescription()].ConnectionString.ToString()))
                {
                    var insertCommand = new StringBuilder()
                        .Append("insert into Costumer ")
                        .Append("([ID],[Name],[Age],[Email])")
                        .Append("values (@ID,@Name,@Age,@Email)");
                    var sqlCommand = new SqlCommand(insertCommand.ToString(), con);
                    sqlCommand.Parameters.AddWithValue("@ID", data.Id);
                    sqlCommand.Parameters.AddWithValue("@Name", data.Name);
                    sqlCommand.Parameters.AddWithValue("@Age", data.Age);
                    sqlCommand.Parameters.AddWithValue("@Email", data.Email);
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                return "success";
            }
            catch (Exception ex)
            {
                return ErrorUtility.GetTrail(ex);
            }
        }
        public static string UpdateFunc(Customer data)
        {
            try
            {
                var verifyResult = data.Verify();
                if (verifyResult != "success")
                    return verifyResult;

                using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DbConnection.YC.GetDescription()].ConnectionString.ToString()))
                {
                    var updateCommand = new StringBuilder()
                        .Append("update Costumer ")
                        .Append("set [Name] = @Name,[Age] = @Age ,[Email] = @Email ")
                        .Append("where [ID] = @ID ");
                    var sqlCommand = new SqlCommand(updateCommand.ToString(), con);
                    sqlCommand.Parameters.AddWithValue("@ID", data.Id);
                    sqlCommand.Parameters.AddWithValue("@Name", data.Name);
                    sqlCommand.Parameters.AddWithValue("@Age", data.Age);
                    sqlCommand.Parameters.AddWithValue("@Email", data.Email);
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                return "success";
            }
            catch (Exception ex)
            {
                return ErrorUtility.GetTrail(ex);
            }
        }
        public static IEnumerable<Customer> GetCustomerByID(string id)
        {
            try
            {
                using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DbConnection.YC.GetDescription()].ConnectionString.ToString()))
                {
                    var customerList = new List<Customer>();
                    var sqlCommand = string.Format("select * from Costumer where ID = '{0}'", id);
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlCommand, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        customerList.Add(
                            new Customer() { Id = dr[1].ToString(), Name = dr[2].ToString(), Age = (int)dr[3], Email = dr[4].ToString() });
                    }
                    con.Close();
                    return customerList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorUtility.GetTrail(ex));
            }

        }
        public static string DeleteCustomerByID(string id)
        {
            try
            {
                using (var con = new SqlConnection(WebConfigurationManager.ConnectionStrings[DbConnection.YC.GetDescription()].ConnectionString.ToString()))
                {
                    var updateCommand = new StringBuilder()
                        .Append("delete Costumer ")
                        .Append("where [ID] = @ID ");
                    var sqlCommand = new SqlCommand(updateCommand.ToString(), con);
                    sqlCommand.Parameters.AddWithValue("@ID", id);
                    con.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                return "success";
            }
            catch (Exception ex)
            {
                return ErrorUtility.GetTrail(ex);
            }
        }
    }
}