using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using WebForms.BAL;

namespace WebForms.DAL
{
    public class CustomerDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlParameter sprm = new SqlParameter();
        SqlDataAdapter adp;
        DataTable dt;

        public CustomerDAL()
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            string cnstr = ConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            con.ConnectionString = cnstr;
            cmd.Connection = con;
        }

        public DataTable GetCustomer(Int64 customerID)
        {
            try
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                cmd.CommandText = "GetCustomer";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                dt = new DataTable();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                con.Close();
                con.Dispose();
                adp.Dispose();
            }
            return dt;
        }

        public DataTable GetCustomerByName(string name)
        {
            try
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.CommandText = "GetCustomerByName";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                dt = new DataTable();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
                con.Close();
                con.Dispose();
                adp.Dispose();
            }
            return dt;
        }

        public int InsertUpdateCustomer(CustomerBAL obj)
        {
            cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
            cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
            cmd.Parameters.AddWithValue("@LastName", obj.LastName);
            cmd.Parameters.AddWithValue("@BirthDate", obj.BirthDate);
            cmd.Parameters.AddWithValue("@Email", obj.Email);
            cmd.Parameters.AddWithValue("@Address", obj.Address);

            sprm.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(sprm);

            int i, j = 0;
            try
            {
                cmd.CommandText = "InsertUpdateCustomer";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    j = int.Parse(sprm.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
                con.Dispose();
                cmd.Dispose();
            }
            return j;
        }

        public int DeleteCustomer(Int64 customerID)
        {
            cmd.Parameters.AddWithValue("@CustomerID", customerID);
            int i = 0;
            try
            {
                cmd.CommandText = "DeleteCustomer";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
                con.Dispose();
                cmd.Dispose();
            }
            return i;
        }

        //public CustomerBAL GetCustomerByName(string name)
        //{
        //    CustomerBAL obj = new CustomerBAL();
        //    SqlDataReader dr;
        //    try
        //    {
        //        cmd.Parameters.AddWithValue("@Name", name);
        //        cmd.CommandText = "GetCustomerByName";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        con.Open();

        //        dr = cmd.ExecuteReader();

        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                obj.CustomerID = dr.GetInt64(dr.GetOrdinal("CustomerID"));
        //                obj.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
        //                obj.LastName = dr.GetString(dr.GetOrdinal("LastName"));
        //                obj.BirthDate = dr.GetDateTime(dr.GetOrdinal("BirthDate"));
        //                obj.Email = dr.GetString(dr.GetOrdinal("Email"));
        //                obj.Address = dr.GetString(dr.GetOrdinal("Address"));
        //            }
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        cmd.Parameters.Clear();
        //        cmd.Dispose();
        //        con.Close();
        //        con.Dispose();
        //    }

        //    return obj;
        //}

        //public List<CustomerBAL> GetCustomer(Int64 customerID)
        //{
        //    List<CustomerBAL> lst = new List<CustomerBAL>();
        //    SqlDataReader dr;
        //    try
        //    {
        //        cmd.Parameters.AddWithValue("@CustomerID", customerID);
        //        cmd.CommandText = "GetCustomer";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        con.Open();

        //        dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            while (dr.Read())
        //            {
        //                CustomerBAL obj = new CustomerBAL();
        //                obj.CustomerID = dr.GetInt64(dr.GetOrdinal("CustomerID"));
        //                obj.FirstName = dr.GetString(dr.GetOrdinal("FirstName"));
        //                obj.LastName = dr.GetString(dr.GetOrdinal("LastName"));
        //                obj.BirthDate = dr.GetDateTime(dr.GetOrdinal("BirthDate"));
        //                obj.Email = dr.GetString(dr.GetOrdinal("Email"));
        //                obj.Address = dr.GetString(dr.GetOrdinal("Address"));

        //                lst.Add(obj);
        //            }
        //            //dr.NextResult();
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        cmd.Parameters.Clear();
        //        cmd.Dispose();
        //        con.Close();
        //        con.Dispose();
        //    }
        //    return lst;
        //}

        #region Deleted Code for Multiple Delete
        //public int DeleteCustomerWithTableType(DataTable dt)
        //{
        //    cmd.Parameters.AddWithValue("@DeleteCustomerType", dt);
        //    int i, j = 0;
        //    try
        //    {
        //        sprm.Direction = ParameterDirection.ReturnValue;
        //        cmd.Parameters.Add(sprm);
        //        cmd.CommandText = "DeleteCustomerWithTableType";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        i = cmd.ExecuteNonQuery();
        //        if (i > 0)
        //        {
        //            j = int.Parse(sprm.Value.ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        cmd.Parameters.Clear();
        //        con.Close();
        //        con.Dispose();
        //        cmd.Dispose();
        //    }
        //    return j;
        //}
        #endregion
    }

}
