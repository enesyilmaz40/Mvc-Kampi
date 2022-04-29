using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemessiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemessiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapın");
            RuleFor(x => x.CategoryName).MaximumLength(30).WithMessage("Lütfen 30 Karakterden Fazla Değer Girişi Yapmayın");
        }
    }
}
