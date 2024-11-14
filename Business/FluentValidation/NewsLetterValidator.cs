using Entities.Concrete;
using FluentValidation;

namespace Business.FluentValidation;

public class NewsLetterValidator : AbstractValidator<NewsLetter>
{
    public NewsLetterValidator()
    {
        RuleFor(x => x.NewsLetterMail).EmailAddress().WithMessage("Lütfen geçerli bir e-posta adresi giriniz. ");
    }
}