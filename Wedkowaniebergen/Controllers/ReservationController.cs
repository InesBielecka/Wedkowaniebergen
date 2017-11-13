using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wedkowaniebergen.Models;

namespace Wedkowaniebergen.Controllers
{
    public class ReservationController : Controller
    {
        public object Email { get; private set; }
        public object Flam { get; private set; }
        public object LastName { get; private set; }
        public object Name { get; private set; }
        public object Telefon { get; private set; }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(ReservationForm form)
        {
            return View();
            string ConString = ConfigurationManager.ConnectionStrings["LocalHost"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                SqlCommand addcmd = new SqlCommand("NowaRezerwacja", con);
                addcmd.CommandType = System.Data.CommandType.StoredProcedure;

                addcmd.Parameters.AddWithValue("@Imię", form.Name);
                addcmd.Parameters.AddWithValue("@Nazwisko", form.LastName);
                addcmd.Parameters.AddWithValue("@Email", form.Email);
                addcmd.Parameters.AddWithValue("@Telefon", form.Phone);
                addcmd.Parameters.AddWithValue("@Flam", form.Flam);
                addcmd.Parameters.AddWithValue("@PływanieŁodzią", form.PływanieŁodzią);
                addcmd.Parameters.AddWithValue("@Trolltunga", form.Trolltunga);
                addcmd.Parameters.AddWithValue("@Wodospady", form.Wodospady);
                addcmd.Parameters.AddWithValue("@ZwiedzanieBergen", form.ZwiedzanieBergen);
                addcmd.Parameters.AddWithValue("@Floyen", form.Floyen);
                addcmd.Parameters.AddWithValue("@Urliken", form.Ulriken);
                addcmd.Parameters.AddWithValue("@TransportLotnisko", form.TransportLotnisko);
                addcmd.Parameters.AddWithValue("@Nocleg", form.Nocleg);
                addcmd.Parameters.AddWithValue("@Lodowiec", form.Lodowiec);
                addcmd.Parameters.AddWithValue("@Uwagi", form.Comments);

                SqlParameter IDParameter = new SqlParameter();
                IDParameter.ParameterName = "@ID";
                IDParameter.SqlDbType = System.Data.SqlDbType.Int;
                IDParameter.Direction = System.Data.ParameterDirection.Output;
                addcmd.Parameters.Add(IDParameter);

                con.Open();
                addcmd.ExecuteNonQuery();
            }

        }
    }
}