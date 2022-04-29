using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan Kısmını Boş Geçemessiniz");
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemessiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemessiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda Kısmını Boş Geçemessiniz");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapın");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen 50 Karakterden Fazla Değer Girişi Yapmayın");
            RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Hakkında kısmında en az bir a harfi içermelidir");

        }
    }
}
