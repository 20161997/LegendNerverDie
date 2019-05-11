using AutoMapper;
using BotDetect.Web.Mvc;
using LND.Common;
using LND.Model.Models;
using LND.Service;
using LND.Web.Infrastructure.Extensions;
using LND.Web.Models;
using System.Web.Mvc;

namespace LND.Web.Controllers
{
    public class ContactController : Controller
    {
        private IContactDetailService _contactDetailService;
        private IFeedbackService _feedbackService;

        public ContactController(IContactDetailService contactDetailService, IFeedbackService feedbackService)
        {
            this._contactDetailService = contactDetailService;
            this._feedbackService = feedbackService;
        }
        [OutputCache(Duration = 3600, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            /* var model = _contactDetailService.GetDefaultContact();
             var contactViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
             return View(contactViewModel);*/
            FeedbackViewModel viewModel = new FeedbackViewModel();
            viewModel.ContactDetail = GetDetail();
            return View(viewModel);
        }

        [HttpPost]
      //  [CaptchaValidation("CaptchaCode", "contactCaptcha", "Mã xác nhận không đúng")]
        public ActionResult SendFeedback(FeedbackViewModel feedbackViewModel)
        {
            if (ModelState.IsValid)
            {
                Feedback newFeedback = new Feedback();
                newFeedback.UpdateFeedback(feedbackViewModel);
                _feedbackService.Create(newFeedback);
                _feedbackService.Save();

                ViewData["SuccessMsg"] = "Gửi phản hồi thành công";

                string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/client/mail/contact_mail.html"));
                content = content.Replace("{{Name}}", feedbackViewModel.Name);
                content = content.Replace("{{Email}}", feedbackViewModel.Email);
                content = content.Replace("{{Message}}", feedbackViewModel.Message);
                string adminEmail = "20161997@student.hust.edu.vn";
                MailHelper.SendMail(adminEmail, "Thông tin liên hệ từ Legend Never Die", content);
            }
            feedbackViewModel.ContactDetail = GetDetail();

            return View("Index", feedbackViewModel);
        }

        private ContactDetailViewModel GetDetail()
        {
            var model = _contactDetailService.GetDefaultContact();
            var contactViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            return contactViewModel;
        }
    }
}