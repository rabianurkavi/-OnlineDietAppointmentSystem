using Entities.Concrete;
using FluentValidation;

namespace Business.FluentValidation;

public class ClientValidator : AbstractValidator<Client>
{
    public ClientValidator()
    {
        RuleFor(x => x.ClientName)
            .NotEmpty().WithMessage("Danışan adı boş geçilemez.")
            .MinimumLength(1).WithMessage("Lütfen geçerli bir isim giriniz.")
            .MaximumLength(40).WithMessage("Danışan adı en fazla 40 karakter olmalıdır.");

        RuleFor(x => x.ClientSurName)
            .NotEmpty().WithMessage("Danışan soyadı boş geçilemez.")
            .MinimumLength(1).WithMessage("Lütfen geçerli bir soyadı girin.")
            .MaximumLength(40).WithMessage("Danışan soyadı en fazla 40 karakter olmalıdır.");

        RuleFor(x => x.ClientEmail)
            .NotEmpty().WithMessage("Danışan maili boş geçilemez.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz. ");

        RuleFor(x => x.ClientPassword)
            .NotEmpty().WithMessage("Lütfen şifre giriniz.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$")
            .WithMessage("Şifre en az 6 karakter uzunluğunda olmalı ve en az bir küçük harf, bir büyük harf ve bir sayı içermelidir.");

        RuleFor(x => x.ClientHeight)
            .NotEmpty().WithMessage("Danışan boyu boş geçilemez.")
            .Must(x => int.TryParse(x, out var height) && height >= 100 && height <= 220)
            .WithMessage("Danışan boyu en az 100 cm ve en fazla 220 cm olabilir.");

        RuleFor(x => x.ClientWeight)
            .NotEmpty().WithMessage("Danışan kilosu boş geçilemez.")
            .Must(x => int.TryParse(x, out var weight) && weight >= 20 && weight <= 400)
            .WithMessage("Danışan kilosu en az 20 kg ve en fazla 400 kg olabilir.");

        RuleFor(x => x.ClientBirthDate)
            .Must(BeAtLeast8YearsOld).WithMessage("Danışan en az 8 yaşında olmalıdır.");
    }

    private bool BeAtLeast8YearsOld(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        if (birthDate > today.AddYears(-age))
            age--;

        return age >= 8;
    }
}