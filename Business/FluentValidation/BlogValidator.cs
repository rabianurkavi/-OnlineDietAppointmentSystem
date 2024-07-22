using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle)
                .NotEmpty().WithMessage("Blog başlığı boş geçilemez.")
                .MinimumLength(5).WithMessage("Lütfen geçerli bir blog başlığı giriniz.")
                .MaximumLength(50).WithMessage("Danışan adı en fazla 40 karakter olmalıdır.");

            RuleFor(x => x.BlogDescription)
                .NotEmpty().WithMessage("Blog içeriği boş geçilemez.")
                .MinimumLength(30).WithMessage("En az 30 karakter uzunluğunda blog açıklaması girebilirsiniz.")
                .MaximumLength(4000).WithMessage("En fazla 4000 karakter uzunluğunda blog açıklaması girebilirsiniz.");

        }
    }
}
