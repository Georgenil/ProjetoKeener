using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoKeener.Extension
{
    /// <summary>
    /// Validação customizada para CPF
    /// </summary>
    public class CnpjAttribute : ValidationAttribute
    {
        /// <summary>
        /// Construtor
        /// </summary>
        ///
        /// public CustomValidationCPFAttribute() { }

        /// <summary>
        /// Validação server
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return true;

            bool valido = Util.Util.ValidaCNPJ(value.ToString());
            return valido;
        }

        /// <summary>
        /// Validação client
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
        //    ModelMetadata metadata, ControllerContext context)
        //{
        //    yield return new ModelClientValidationRule
        //    {
        //        ErrorMessage = this.FormatErrorMessage(null),
        //        ValidationType = "customvalidationcpf"
        //    };
        //}

        //public class CnpjValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
        //{
        //    private readonly IValidationAttributeAdapterProvider _baseProvider = new ValidationAttributeAdapterProvider();

        //    public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        //    {
        //        if (attribute is CnpjAttribute moedaAttribute)
        //        {
        //            return new CnpjAttributeAdapter(moedaAttribute, stringLocalizer);
        //        }

        //        return _baseProvider.GetAttributeAdapter(attribute, stringLocalizer);
        //    }
        //}
    }
}
