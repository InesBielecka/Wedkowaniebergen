using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Wedkowaniebergen.Models;

namespace Wedkowaniebergen.Controllers
{
    public class ReservationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index(ReservationForm form)
        {
            if (ModelState.IsValid)
            {
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
                addcmd.Parameters.AddWithValue("@Uwagi", form.Comments == null? string.Empty : form.Comments);

                SqlParameter IDParameter = new SqlParameter();
                IDParameter.ParameterName = "@ID";
                IDParameter.SqlDbType = System.Data.SqlDbType.Int;
                IDParameter.Direction = System.Data.ParameterDirection.Output;
                addcmd.Parameters.Add(IDParameter);

                con.Open();
                addcmd.ExecuteNonQuery();
            }

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add("ines.bielecka@gmail.com");
            mail.From = new MailAddress("ines.bielecka@gmail.com", "Test", System.Text.Encoding.UTF8);
            mail.Subject = "Rezerwacja";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = string.Format("{0} {1}, {2}, {3}", form.Name, form.LastName, form.Email, form.Phone);
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("ines.bielecka@gmail.com", "lgtpxhwb93");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
            }
                TempData["Success"] = "Rezerwacja powiodła się, wkrótce odezwiemy się do Ciebie.";
            }
            else
            {
                TempData["Error"] = "Rezerwacja nie powiodła się, spróbuj jeszcze raz.";
            }
            return View("~/Views/Home/Index.cshtml");
        }
        
    }
}