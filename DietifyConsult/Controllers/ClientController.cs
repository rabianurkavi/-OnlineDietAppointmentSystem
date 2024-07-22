using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DietifyConsult.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers
{
    public class ClientController : Controller
	{
        ClientManager clientManager = new ClientManager(new EfClientDal());
        DietifyConsultContext context = new DietifyConsultContext();
		
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult ClientProfile()
		{
            var userName = User.Identity.Name;
            int userID = context.Clients.Where(x => x.ClientEmail == userName).Select(t => t.ClientID).FirstOrDefault();
            var values=clientManager.GetById(userID);
            return View(values);
		}
		[HttpPost]
        public IActionResult ClientProfile(AddClientImage clientVM)
        {
            var existingClient = clientManager.GetById(clientVM.ClientID);
            if (clientVM.ClientImage != null && clientVM.ClientImage.Length > 0)
            {
                var extension = Path.GetExtension(clientVM.ClientImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resim/", newImageName);
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    clientVM.ClientImage.CopyTo(stream);
                }
                existingClient.ClientImage = newImageName;
            }
            existingClient.CreateDate = clientVM.CreateDate;
            existingClient.ClientName = clientVM.ClientName;
            existingClient.ClientSurName = clientVM.ClientSurName;
            existingClient.ClientEmail = clientVM.ClientEmail;
            existingClient.ClientHeight = clientVM.ClientHeight;
            existingClient.ClientWeight = clientVM.ClientWeight;
            existingClient.ClientBirthDate = clientVM.ClientBirthDate;
            existingClient.ClientPassword = clientVM.ClientPassword;
            existingClient.PhoneNumber = clientVM.PhoneNumber;
            existingClient.DietitianStatus = clientVM.DietitianStatus;
            existingClient.AdminStatus = clientVM.AdminStatus;

            clientManager.TUpdate(existingClient);
            return RedirectToAction("ClientProfile", "Client");
        }

    }
}
