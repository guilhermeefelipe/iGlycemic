using System.Reflection;

namespace iGlycemic.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ForceCase : Attribute
    {
        private static readonly Dictionary<CaseConversionType, Func<string, string>> Conversions =
            new Dictionary<CaseConversionType, Func<string, string>>
            {
                {CaseConversionType.Upper, str => str.ToUpperInvariant()},
                {CaseConversionType.Lower, str => str.ToLowerInvariant()}
            };

        public CaseConversionType ConversionType { get; }

        public ForceCase(CaseConversionType conversionType)
        {
            ConversionType = conversionType;
        }

        /// <summary>
        /// Método para aplicar as alterações de caixa nas propriedades marcadas como <see cref="ForceCase"/> de um objeto.
        /// </summary>
        /// <param name="obj">O objeto para alterãção das propriedades.</param>
        public static void Apply(object obj)
        {
            var type = obj.GetType();

            foreach (var property in type.GetProperties())
            {
                var propVal = property.GetValue(obj) as string;
                if (propVal == null) continue;

                foreach (var attr in property.GetCustomAttributes())
                {
                    var caseAttribute = attr as ForceCase;
                    if (caseAttribute == null) continue;

                    property.SetValue(obj, Conversions[caseAttribute.ConversionType](propVal));
                }
            }
        }
    }

    /// <summary>
    /// Especifica o tipo de conversão de caixa a se aplicar.
    /// </summary>
    public enum CaseConversionType
    {
        /// <summary>
        /// Realiza conversão para caixa alta.
        /// </summary>
        Upper,
        /// <summary>
        /// Realiza conversão para caixa baixa.
        /// </summary>
        Lower
    }
}
