using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curier.Model;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Curier.Controller
{
    static class ComandaController
    {
        
        public static Comanda GetComandaByID( int id )
        {

            Comanda newcomanda = new Comanda();

            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = "Select * from Comanda where id=@cid";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                oCmd.Parameters.AddWithValue("@cid", id);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        while (oReader.Read())
                        {
                            newcomanda.ID = Int32.Parse(oReader["id"].ToString());
                            newcomanda.AdresaDest = oReader["adresa_destinatie"].ToString();
                            newcomanda.Descriere = oReader["descriere"].ToString();
                            newcomanda.Expeditor = Int32.Parse(oReader["expeditorid"].ToString());

                        }
                    }

                    connection.Close();
                }
            }

            return newcomanda;
        }


        public static List<Comanda> GetComandaByClientID(int id)
        {

           

            List<Comanda> commandlist = new List<Comanda>();

            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = "Select * from Comanda where expeditorid=@cid";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                oCmd.Parameters.AddWithValue("@cid", id);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        while (oReader.Read())
                        {
                            Comanda newcomanda = new Comanda();
                            newcomanda.ID = Int32.Parse(oReader["id"].ToString());
                            newcomanda.AdresaDest = oReader["adresa_destinatie"].ToString();
                            newcomanda.Descriere = oReader["descriere"].ToString();
                            newcomanda.Expeditor = Int32.Parse(oReader["expeditorid"].ToString());

                            commandlist.Add(newcomanda);

                        }
                    }

                    connection.Close();
                }
            }

            return commandlist;
        }

        public static int InsertCommand(Comanda com)
        {

            int newid = -1;
            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = "INSERT INTO Comanda(expeditorid,descriere,adresa_destinatie) output INSERTED.ID VALUES(@exp,@desc,@adr);";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                oCmd.Parameters.AddWithValue("@desc", com.Descriere);
                oCmd.Parameters.AddWithValue("@adr", com.AdresaDest);
                oCmd.Parameters.AddWithValue("@exp", com.Expeditor);

                connection.Open();

             
                try
                
                {
                    newid = (int) oCmd.ExecuteScalar();
                    MessageBox.Show("Comanda Inregistrata");
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


           

            return newid;
        }

        public static int GetStatus(int id)
        {

            int status = -1;

            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = "Select status from Livraredepozit where comandaid=@cid ";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                oCmd.Parameters.AddWithValue("@cid", id);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        while (oReader.Read())
                        {
                           
                            status= Int32.Parse(oReader["status"].ToString());
                        }
                    }

                    connection.Close();
                }
            }

           /* if (status == 0) return 0; //COMANDA IN RIDICARE DE LA CLIENT
            if (status == 1) return 1; //COMANDA IN DRUM SPRE DEPOZIT
            if (status == 2) return 2; //COMANDA A AJUNS IN DEPOZIT*/


            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = "Select status from Livrareclient where comandaid=@cid ";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                oCmd.Parameters.AddWithValue("@cid", id);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        while (oReader.Read())
                        {

                            status = Int32.Parse(oReader["status"].ToString());
                        }
                    }

                    connection.Close();
                }
            }

            /*
            if (status == 3) return 3; //COMANDA IN DRUM SPRE CLIENT
            if (status == 4) return 4; //COMANDA LIVRATA*/

            return status;
        }

        public static string StatusToText(int status)
        {
            string text = "neprocesata";
            if (status == 0) text = "Ridicare de la client";
            if (status == 1) text = "In drum spre depozit";
            if (status == 2) text = "In depozit";
            if (status == 3) text = "In drum spre destinatar";
            if (status == 4) text = "Comanda Livrata";
    

            return text;
        }

    }
}
