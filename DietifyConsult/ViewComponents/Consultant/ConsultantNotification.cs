using Microsoft.AspNetCore.Mvc;

namespace DietifyConsult.ViewComponents.Consultant;

public class ConsultantNotification : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}