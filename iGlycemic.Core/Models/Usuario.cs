using FluentResults;
using iGlycemic.Core.Attributes;
using iGlycemic.Core.Validation;
using iGlycemic.Domain.Entities;

namespace iGlycemic.Core.Models
{
    public class Usuario : Entity, ICoreValidation
    {
        [ForceCase(CaseConversionType.Upper)]
        public string Nome { get; set; }
        public string Senha { get; set; }

        [ForceCase(CaseConversionType.Lower)]
        public string Email { get; set; }



        public Result Validate() 
        {
            
            if(string.IsNullOrEmpty(Email))
                return new Error("Informe o Email");

            return Result.Ok();
        }
    }

}
