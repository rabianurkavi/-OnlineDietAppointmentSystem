using Business.Concrete;
using Business.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using DietifyConsult.Models;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.Controllers;

[AllowAnonymous]
public class RegisterController : Controller
{
    private readonly ClientManager clientManager = new(new EfClientDal());

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(AddClientImage clientVM)
    {
        var client = new Client();
        client.ClientName = clientVM.ClientName;
        client.ClientSurName = clientVM.ClientSurName;
        client.PhoneNumber = clientVM.PhoneNumber;
        client.ClientEmail = clientVM.ClientEmail;
        client.ClientWeight = clientVM.ClientWeight;
        client.ClientHeight = clientVM.ClientHeight;
        client.ClientPassword = clientVM.ClientPassword;
        var validationRules = new ClientValidator();
        var validationResult = validationRules.Validate(client);


        if (validationResult.IsValid)
        {
            var extension = Path.GetExtension(clientVM.ClientImage.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resim/", newImageName);
            var stream = new FileStream(location, FileMode.Create);
            clientVM.ClientImage.CopyTo(stream);
            client.ClientImage = newImageName;
            client.CreateDate = DateTime.Now;
            client.DietitianStatus = false;
            client.AdminStatus = false;

            clientManager.TAdd(client);

            return RedirectToAction("Index", "Blog");
        }

        foreach (var item in validationResult.Errors) ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        return View();
    }
}