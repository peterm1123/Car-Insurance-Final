using CarInsurance.Models;
using CarInsurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class AdminController : Controller
    {
        private string _connectionString = @"Data Source=DESKTOP-TCT093C\SQLEXPRESS;Initial Catalog=Insurance1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // GET: Admin
        public ActionResult Index()
        {
            using (var db = new CarInsuranceEntities1())
            {
                var quotes = db.InsuranceQuotes;
                var quoteVms = new List<QuoteVm>();
                foreach (var quote in quotes)
                {
                    var quoteVm = new QuoteVm();
                    quoteVm.FirstName = quote.FirstName;
                    quoteVm.LastName = quote.LastName;
                    quoteVm.EmailAddress = quote.EmailAddress;
                    quoteVm.QuoteAmount = (decimal)quote.Quote;

                    quoteVms.Add(quoteVm);
                }
                return View(quoteVms);
            }
        }
    }
}