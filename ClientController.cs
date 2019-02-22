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
    static class ClientController
    {


        public static Client GetClientByEmail(string email)
        {
            Client newclient = null;

            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = "Select * from Client where [e-mail]=@em";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                oCmd.Parameters.AddWithValue("@em", email);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        while (oReader.Read())
                        {
                            newclient = new Client();
                            newclient.ID = Int32.Parse(oReader["id"].ToString());
                            newclient.Nume = oReader["nume"].ToString();
                            newclient.Prenume = oReader["prenume"].ToString();
                            newclient.Adresa = oReader["adresa"].ToString();
                            newclient.Email = email;
                            newclient.Telefon = oReader["telefon"].ToString();

                        }
                    }
                    connection.Close();
                }
            }

            return newclient;





        }

        public static void UpdateClientByID(int id, Client client)
        {

            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = "UPDATE Client SET [e-mail] = @em, adresa=@ad ,telefon=@tel WHERE id = @cid";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                oCmd.Parameters.AddWithValue("@em", client.Email);
                oCmd.Parameters.AddWithValue("@ad", client.Adresa);
                oCmd.Parameters.AddWithValue("@tel", client.Telefon);
                oCmd.Parameters.AddWithValue("@cid", id);
                connection.Open();
               try
                {
                    oCmd.ExecuteNonQuery();
                    MessageBox.Show("Salvat!");
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

        public static void InsertClient(Client client)
        {
            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = "INSERT INTO Client(nume,prenume,[e-mail],adresa,telefon) VALUES(@num,@pren,@em,@adr,@tel);";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                oCmd.Parameters.AddWithValue("@num", client.Nume);
                oCmd.Parameters.AddWithValue("@pren", client.Prenume);
                oCmd.Parameters.AddWithValue("@em", client.Email);
                oCmd.Parameters.AddWithValue("@tel", client.Telefon);
                oCmd.Parameters.AddWithValue("@adr", client.Adresa);


                connection.Open();


                try

                {
                    oCmd.ExecuteNonQuery();
                    MessageBox.Show("Inregistrare cu succes,te poti loga!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    connection.Close();
                }



            }
        }
    }
}
