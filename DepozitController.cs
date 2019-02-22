using Curier.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curier
{
    static class DepozitController
    {
        public static Depozit GetDepozitByID(int id)
        {

            Depozit newdep= new Depozit();

            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = "Select * from Depozit where id=@cid";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                oCmd.Parameters.AddWithValue("@cid", id);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        while (oReader.Read())
                        {
                            newdep.ID = Int32.Parse(oReader["id"].ToString());
                            newdep.Adresa = oReader["adresa"].ToString();
                            newdep.Dimensiune = oReader["dimensiune"].ToString();
                            newdep.Chirie = Int32.Parse(oReader["chirie"].ToString());

                        }
                    }

                    connection.Close();
                }
            }

            return newdep;
        }
    }
}
