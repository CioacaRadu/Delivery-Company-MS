using Curier.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curier.Controller
{
    static class DeliveryController
    {

        public static void AssignCommandStage1(int commandid)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = "INSERT INTO Livraredepozit(comandaid,depozitid,curierid,status) VALUES(@cid,@dep,@cur,0);";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                oCmd.Parameters.AddWithValue("@cid", commandid);

                int depid = GetAvailableDepozit().ID;
                oCmd.Parameters.AddWithValue("@dep", depid);

                int curid = GetAvailableCurier().ID;
                oCmd.Parameters.AddWithValue("@cur", curid);
                
                connection.Open();


                try

                {
                    oCmd.ExecuteNonQuery();
                    MessageBox.Show("Livrare_Depozit Inregistrata pentru pentru " + curid.ToString() + " depozit" + depid.ToString() );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                connection.Close();

            }



        }


        public static void UpdateCommand(int comandaid, int status)
        {
            if(status == 1 || status == 2 )
            {

                using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
                {
                    string oString = "UPDATE Livraredepozit SET status = @s WHERE comandaid = @cid";
                    SqlCommand oCmd = new SqlCommand(oString, connection);
                    oCmd.Parameters.AddWithValue("@s", status);
                    oCmd.Parameters.AddWithValue("@cid", comandaid);

                    connection.Open();
                    try
                    {
                        oCmd.ExecuteNonQuery();
                        MessageBox.Show("LD updated");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Not Saved");
                    }
                    finally
                    {
                        connection.Close();
                    }



                }

                if (status == 2)
                {
                    using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
                    {
                        string oString = "INSERT INTO LivrareClient(comandaid, curierid,status) VALUES(@cid, @curid,2)";
                        SqlCommand oCmd = new SqlCommand(oString, connection);
                        oCmd.Parameters.AddWithValue("@cid", comandaid);
                        int curid = GetAvailableCurier().ID;
                        oCmd.Parameters.AddWithValue("@curid", curid);

                        connection.Open();
                        try
                        {
                            oCmd.ExecuteNonQuery();
                            MessageBox.Show("LD inserted pentru" + curid.ToString());
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Not Saved");
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }

      

            if (status == 3 || status == 4)
            {
                using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
                {
                    string oString = "UPDATE Livrareclient SET status = @s WHERE comandaid = @cid";
                    SqlCommand oCmd = new SqlCommand(oString, connection);
                    oCmd.Parameters.AddWithValue("@s", status);
                    oCmd.Parameters.AddWithValue("@cid", comandaid);

                    connection.Open();
                    try
                    {
                        oCmd.ExecuteNonQuery();
                        MessageBox.Show("LC updated");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Not Saved");
                    }
                    finally
                    {
                        connection.Close();
                    }



                }

            }

      

        }

        public static Curierman GetAvailableCurier()
        {

            Curierman newcur = new Curierman();

          

            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = @"
                                SELECT x.curierid,COUNT(x.livrareid) as livactive FROM (

	                                SELECT Curier.id AS curierid ,Livrareclient.id as livrareid
	                                FROM Curier
	                                LEFT JOIN Livrareclient ON Curier.id = Livrareclient.curierid 
	                                WHERE Livrareclient.status <> 4 OR Livrareclient.status is null
	                                UNION ALL

	                                SELECT Curier.id AS curierid ,Livraredepozit.id as livrareid
	                                FROM Curier
	                                LEFT JOIN Livraredepozit ON Curier.id = Livraredepozit.curierid 
	                                WHERE Livraredepozit.status <> 2 OR Livraredepozit.status is null) as x

                                GROUP BY curierid
                                ORDER BY livactive 
                            ";






                SqlCommand oCmd = new SqlCommand(oString, connection);
               
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        if (oReader.Read())
                        {
                           
                            newcur.ID = Int32.Parse( oReader["curierid"].ToString());
                   


                        }
                    }
                    connection.Close();
                }
            }

            return newcur;


        }


        public static Depozit GetAvailableDepozit()
        {

            Depozit newdep = new Depozit();



            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = @"
                               Select x.depid,COUNT(x.livid) as nrlivrari 
                                FROM(
	                                Select Depozit.id as depid,Depozit.adresa as adresa,Depozit.chirie as chirie,Depozit.dimensiune as dimensiune,Livraredepozit.id as livid
	                                FROM Depozit
	                                LEFT JOIN Livraredepozit ON Livraredepozit.depozitid = Depozit.id
	                                WHERE Livraredepozit.status = 2 or Livraredepozit.status is null)as x
                                GROUP BY x.depid
                                ORDER BY nrlivrari

                            ";






                SqlCommand oCmd = new SqlCommand(oString, connection);

                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        if (oReader.Read())
                        {

                            newdep.ID = Int32.Parse(oReader["depid"].ToString());



                        }
                    }
                    connection.Close();
                }
            }

            return newdep;


        }

    }

}

 