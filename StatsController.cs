using Curier.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curier.Controller
{
    static class StatsController
    {
        //TODO: IMPLEMENT ALL OF THESE


        public static int GetSuccessCommands()
        {

            int nrc = -1;
            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = @"SELECT COUNT(id) as nr FROM Livrareclient
                                    WHERE Livrareclient.status = 4";

                SqlCommand oCmd = new SqlCommand(oString, connection);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        if (oReader.Read() ) nrc = Int32.Parse(oReader["nr"].ToString());
                    }
                    connection.Close();
                }
            }

            return nrc;
        }


        public static int GetClientsNumber()
        {
            int nrc = -1;
            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = @"SELECT COUNT(id) as nr FROM Client";

                SqlCommand oCmd = new SqlCommand(oString, connection);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        if (oReader.Read()) nrc = Int32.Parse(oReader["nr"].ToString());
                    }
                    connection.Close();
                }
            }

            return nrc;
        }

        public static int GetActiveCommands()
        {
            int nrc = -1;
            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = @"SELECT COUNT(x.id) as nr 
                                    FROM(SELECT id,status FROM Livrareclient
	                                    WHERE status <> 4
	                                    UNION
	                                    SELECT id,status FROM Livraredepozit) as x";

                SqlCommand oCmd = new SqlCommand(oString, connection);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        if (oReader.Read()) nrc = Int32.Parse(oReader["nr"].ToString());
                    }
                    connection.Close();
                }
            }

            return nrc;
        }


        public static int GetDepositsNumber()
        {
            int nrc = -1;
            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = @"SELECT COUNT(id) as nr FROM Depozit";

                SqlCommand oCmd = new SqlCommand(oString, connection);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        if (oReader.Read()) nrc = Int32.Parse(oReader["nr"].ToString());
                    }
                    connection.Close();
                }
            }

            return nrc;
        }

        public static Curierman GetBestCurier()
        {
            Curierman cur = new Curierman();

            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = @"SELECT curierid,nume,prenume,data_nasterii,salariu,nr
                                    FROM
	                                    (SELECT curierid,COUNT(Livrareclient.id) as nr
	                                    FROM Livrareclient 
	                                    WHERE Livrareclient.status = 4 
	                                    GROUP BY curierid) as x
                                    INNER JOIN Curier ON x.curierid = Curier.id
                                    ORDER BY nr DESC";

                SqlCommand oCmd = new SqlCommand(oString, connection);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        if (oReader.Read())
                        {
                            cur.ID = Int32.Parse(oReader["curierid"].ToString());
                            cur.Nume = oReader["nume"].ToString();
                            cur.Prenume = oReader["prenume"].ToString();
                            cur.Data_Nasterii = oReader["data_nasterii"].ToString();
                            cur.Salariu = oReader["salariu"].ToString();
                        }
                    }
                    connection.Close();
                }
            }


            return cur;
        }
    }
}
