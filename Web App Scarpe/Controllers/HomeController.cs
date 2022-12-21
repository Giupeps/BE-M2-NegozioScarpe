using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_App_Scarpe.Models;

namespace Web_App_Scarpe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SqlConnection con = new SqlConnection();
            List<Prodotto> ListaProdotto = new List<Prodotto>();

            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ScarpeDB"].ToString();
                con.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "select * from Prodotti where Disponibile = 1 ";
                command.Connection = con;

                SqlDataReader reader = command.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Prodotto Prodotto = new Prodotto();
                        Prodotto.IdProdotto = Convert.ToInt32(reader["IdProdotto"]);
                        Prodotto.Nome = reader["Nome"].ToString();
                        Prodotto.Prezzo = Convert.ToDouble(reader["Prezzo"]);
                        Prodotto.Descrizione = reader["Descrizione"].ToString();
                        Prodotto.ImmagineCopertina = reader["ImgCover"].ToString();
                        Prodotto.ImmagineAgg1 = reader["ImgAdd1"].ToString();
                        Prodotto.ImmagineAgg2 = reader["ImgAdd2"].ToString();
                        Prodotto.Disponibile = Convert.ToBoolean(reader["Disponibile"]);

                        ListaProdotto.Add(Prodotto);
                    }
                }



            }
            catch 
            {
                con.Close();
            }

            con.Close();


            return View(ListaProdotto);
        }


    }
}