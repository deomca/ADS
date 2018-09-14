using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;

namespace AdsCom
{
    
    public class deo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        

        public void Save()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
            //SqlConnection con = new SqlConnection("Data Source=DIPTI-A0DC34C8B;Initial Catalog=DeoAds;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand("insert into  [deo](FirstName,LastName,Password ) values (@FirstName,@LastName,@Password)", con);
            
            cmd.Parameters.AddWithValue("@FirstName",FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@Password", Password);
            con.Open();

            try
            {
                //execute the command
                cmd.ExecuteNonQuery();
                

            }

            finally
            {
                con.Close();
            }


        }
        
        
    }
}