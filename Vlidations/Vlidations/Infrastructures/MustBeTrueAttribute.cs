using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vlidations.Infrastructures
{
    public class MustBeTrueAttribute : Attribute, IModelValidator
    {
        public bool IsRequired { get; set; }
        public string ErrorMessage { get; set; } = "This Value Must Be True";
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            bool? vaule = context.Model as bool?;

            if (!vaule.HasValue || vaule.Value==false)
            {
                return new List<ModelValidationResult> { 
                new ModelValidationResult("",ErrorMessage)
                };
            }
            else
            {
                return Enumerable.Empty<ModelValidationResult>();
            }
         }
    }
}
