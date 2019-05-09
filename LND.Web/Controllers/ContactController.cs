using AutoMapper;
using LND.Model.Models;
using LND.Service;
using LND.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LND.Web.Controllers
{
    public class ContactController : Controller
    {
        IContactDetailService _contactDetailService;
        public ContactController(IContactDetailService contactDetailService)
        {
            this._contactDetailService = contactDetailService;
        }
        public ActionResult Index()
        {
            var model = _contactDetailService.GetDefaultContact();
            var contactViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            return View(contactViewModel);
        }
    }
}