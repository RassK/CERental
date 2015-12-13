using CERental.Core.Contract.Services;
using CERental.Core.Models;
using CERental.Web.Public.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace CERental.Web.Public.Controllers.Mvc
{
    [Authorize]
    public partial class HomeController : BaseController
    {
        public ICommunicationService CommunicatorService { get; set; }

        [HttpGet]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public virtual ActionResult ThankYou()
        {
            var rentalResult = Session["LastOrderResult"] as RentalResult;
            if (rentalResult == null)
            {
                return RedirectToAction(MVC.Home.Index());
            }

            return View(rentalResult);
        }

        [HttpGet]
        public virtual ActionResult Download()
        {
            var rentalResult = Session["LastOrderResult"] as RentalResult;
            if (rentalResult == null)
            {
                return RedirectToAction(MVC.Home.Index());
            }

            var invoice = InvoiceBuilder.Build(CurrentUser, rentalResult);
            var content = Encoding.UTF8.GetBytes(invoice);

            return File(content, "text/plain", "invoice.txt");
        }

        [HttpPost]
        public virtual ActionResult PostOrder(IEnumerable<EquipmentRental> items)
        {
            if (items.Any(x => x.Days < 1))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var result = CommunicatorService.RegisterRent(CurrentUserId, items);
            Session["LastOrderResult"] = result;

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}