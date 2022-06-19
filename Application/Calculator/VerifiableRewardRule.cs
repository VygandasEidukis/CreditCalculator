using System.Diagnostics.CodeAnalysis;
using Application.RewardRules;
using Application.Validations;

namespace Application.Calculator;

[ExcludeFromCodeCoverage]
public class VerifiableRewardRule
{
    public VerifiableRewardRule()
    {
        Validations = new List<IValidation>();
    }

    public IRewardRule RewardRule { get; set; }
    public List<IValidation> Validations { get; set; }
}
