using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    public class NewsLetterValidator:AbstractValidator<NewsLetter>
    {
        public NewsLetterValidator()
        {
            RuleFor(x => x.NewsLetterMail).EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz. ");
        }
    }
}
