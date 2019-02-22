using Curier.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curier.Controller
{
    class CuriermanController
    {


        public static Curierman GetCurierByID(int id)
        {
            Curierman newcurier = null; 

            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = "Select * from Curier where id=@id";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                oCmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        while (oReader.Read())
                        {
                            newcurier = new Curierman();
                            newcurier.ID = id;
                            newcurier.Nume = oReader["nume"].ToString();
                            newcurier.Prenume = oReader["prenume"].ToString();
                            newcurier.Data_Nasterii = oReader["data_nasterii"].ToString();
                            newcurier.Salariu = oReader["salariu"].ToString();


                        }
                    }
                    connection.Close();
                }
            }

            return newcurier;
        }


        public static List<LivrareDepozit> GetLDs(int id)
        {

            List<LivrareDepozit> commandlist = new List<LivrareDepozit>();

            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = @"Select Comanda.id,Livraredepozit.depozitid,Client.adresa,Client.telefon,Client.nume,Livraredepozit.status
                                FROM Comanda

                                    INNER JOIN Client ON Client.id = Comanda.expeditorid

                                    INNER JOIN Livraredepozit ON Livraredepozit.comandaid = Comanda.id
                                WHERE Livraredepozit.curierid = @cid AND Livraredepozit.status <> 2";
                SqlCommand oCmd = new SqlCommand(oString, connection);
                oCmd.Parameters.AddWithValue("@cid", id);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        while (oReader.Read())
                        {
                            LivrareDepozit newcomanda = new LivrareDepozit();
                            newcomanda.Comanda = Int32.Parse(oReader["id"].ToString());
                            newcomanda.Depozit = Int32.Parse(oReader["depozitid"].ToString());
                            newcomanda.AdresaExp = oReader["adresa"].ToString();
                            newcomanda.NumeExp = oReader["telefon"].ToString();
                            newcomanda.TelefonExp = oReader["nume"].ToString();
                            newcomanda.Status = Int32.Parse(oReader["status"].ToString());
                            commandlist.Add(newcomanda);

                        }
                    }

                    connection.Close();
                }
            }

            return commandlist;

        }


        public static List<LivrareDepozit> GetLCs(int id)
        {

            List<LivrareDepozit> commandlist = new List<LivrareDepozit>();

            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = @"Select Livrareclient.comandaid,Livraredepozit.depozitid,Comanda.adresa_destinatie,Livrareclient.status
                                    FROM Livrareclient 
	                                    INNER JOIN Livraredepozit ON Livraredepozit.comandaid = Livrareclient.comandaid 
	                                    INNER JOIN Comanda ON Comanda.id = Livrareclient.comandaid
                                    WHERE Livrareclient.curierid = @cid AND Livrareclient.status <> 4";

                SqlCommand oCmd = new SqlCommand(oString, connection);
                oCmd.Parameters.AddWithValue("@cid", id);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        while (oReader.Read())
                        {
                            LivrareDepozit newcomanda = new LivrareDepozit();
                            newcomanda.Comanda = Int32.Parse(oReader["comandaid"].ToString());
                            newcomanda.Depozit = Int32.Parse(oReader["depozitid"].ToString());
                            newcomanda.AdresaExp = oReader["adresa_destinatie"].ToString();
                            newcomanda.Status = Int32.Parse(oReader["status"].ToString());

                            commandlist.Add(newcomanda);

                        }
                    }

                    connection.Close();
                }
            }

            return commandlist;

        }

        public static Masina GetCarByID(int id)
        {
            Masina newcar = new Masina();

            using (SqlConnection connection = new SqlConnection(SqlConnectionDB.ConnectionString))
            {
                string oString = @"Select Masina.numar,Masina.model 
                                  FROM Programmasini 
                                  INNER JOIN Masina ON Masina.id = Programmasini.masinaid 
                                  WHERE Programmasini.curierid = @cid";

                SqlCommand oCmd = new SqlCommand(oString, connection);
                oCmd.Parameters.AddWithValue("@cid", id);
                connection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader != null)
                    {
                        while (oReader.Read())
                        {
                            newcar.Numar = oReader["numar"].ToString();
                            newcar.Model = oReader["model"].ToString();



                        }
                    }
                    connection.Close();
                }
            }

            return newcar;


        }

        public static string StatusToText(int status)
        {

            string text = "neprocesat";

            switch (status)
            {

                case 0:
                    text = "Ridicare de la adresa";
                    break;
                case 1:
                    text = "Livrare la depozit";
                    break;
                case 2:
                    text = "Ridicare din depozit";
                    break;
                case 3:
                    text = "Livrare catre adresa";
                    break;


            }

            return text;




        }
    }
}
