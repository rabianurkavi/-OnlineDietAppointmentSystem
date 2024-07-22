using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace DietifyConsult.Controllers
{
    public class AdminMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        DietifyConsultContext context = new DietifyConsultContext();
        public IActionResult InBox()
        {
            var userName = User.Identity.Name;
            int userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            var values = messageManager.GetInboxListByClient(userID);
            var valuesSend = messageManager.GetSendBoxListByClient(userID).Count();
            var messageTotal = messageManager.GetInboxListByClient(userID).Count();
            ViewBag.messageTotal = messageTotal;
            ViewBag.messageSendTotal = valuesSend;
            return View(values);
        }
        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;
            int userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            var values = messageManager.GetSendBoxListByClient(userID);
            var valuesSend = messageManager.GetSendBoxListByClient(userID).Count();
            var messageTotal = messageManager.GetInboxListByClient(userID).Count();
            ViewBag.messageSendTotal = messageTotal;
            ViewBag.messageInboxTotal = valuesSend;
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var userName = User.Identity.Name;
            int userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            var valuesSend = messageManager.GetSendBoxListByClient(userID).Count();
            var messageTotal = messageManager.GetInboxListByClient(userID).Count();
            ViewBag.messageSendTotal = messageTotal;
            ViewBag.messageInboxTotal = valuesSend;
            var messageValue = messageManager.GetMessageClientById(id);
            return View(messageValue);
        }
        [HttpGet]
        public IActionResult MessageDetailsSendBox(int id)
        {
            var messageValue = messageManager.GetMessageClientById(id);
            return View(messageValue);
        }
        [HttpGet]
        public IActionResult SendMessage(int id)
        {
            var values = messageManager.GetMessageClientById(id);
            ViewBag.Mail = values.SenderUser.ClientEmail;
            ViewBag.SenderId = values.SenderID;
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            var userName = User.Identity.Name;
            int userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            message.SenderID = userID;
            message.MessageStatus = true;
            message.MessageDate = DateTime.Now;
            messageManager.TAdd(message);
            return RedirectToAction("Inbox", "AdminMessage");
        }
        [HttpGet]
        public IActionResult NewMessage()
        {
            var userName = User.Identity.Name;
            int userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            var valuesSend = messageManager.GetSendBoxListByClient(userID).Count();
            var messageTotal = messageManager.GetInboxListByClient(userID).Count();
            ViewBag.messageSendTotal = messageTotal;
            ViewBag.messageInboxTotal = valuesSend;
            ClientManager clientManager = new ClientManager(new EfClientDal());
            List<SelectListItem> clientValues = (from x in clientManager.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.ClientEmail,
                                                     Value = x.ClientID.ToString()
                                                 }).ToList();
            ViewBag.mailList = clientValues;
            return View();
        }
        [HttpPost]
        public IActionResult NewMessage(Message message)
        {
            var userName = User.Identity.Name;
            int userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            message.SenderID = userID;
            message.MessageStatus = true;
            message.MessageDate = DateTime.Now;
            messageManager.TAdd(message);
            return RedirectToAction("Inbox", "AdminMessage");
        }
    }
}
