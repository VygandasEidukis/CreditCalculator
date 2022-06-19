using System.Diagnostics.CodeAnalysis;
using Application.Validations;

namespace Application.Calculator;

[ExcludeFromCodeCoverage]
public class CreditCalculationContext
{
    public CreditCalculationContext()
    {
        Validations = new List<IValidation>();
        VerifiableRewardRules = new List<VerifiableRewardRule>();
    }

    public List<IValidation> Validations { get; set; }
    public List<VerifiableRewardRule> VerifiableRewardRules { get; set; }
}
