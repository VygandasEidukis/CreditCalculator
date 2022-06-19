using Application.Calculator;
using Application.Validations;
using Infrastructure.Adapters;

namespace Infrastructure.Calculator;
public class CreditCalculator : ICalculator<CreditCalculationInput, CreditResult>
{
    private readonly CreditCalculationContext _context;
    public CreditCalculator(CreditCalculationContext context)
    {
        _context = context;
    }

    public CreditResult Calculate(CreditCalculationInput input)
    {
        if (!Validate(_context.Validations, input))
        {
            return CreditResult.Fail();
        }

        return GetCredit(input);
    }

    private CreditResult GetCredit(CreditCalculationInput input)
    {
        var verifiableRewards = _context.VerifiableRewardRules;
        if (verifiableRewards == null || !verifiableRewards.Any())
        {
            return CreditResult.Fail();
        }

        foreach (var verifiableReward in verifiableRewards)
        {
            if (!Validate(verifiableReward.Validations, input))
            {
                continue;
            }

            return GetResult(verifiableReward);
        }

        return CreditResult.Fail();
    }

    private static CreditResult GetResult(VerifiableRewardRule verifiableReward)
    {
        var rule = RewardRuleAdapter.GetRewardRuleHandler(verifiableReward.RewardRule);
        var result = rule.Calculate();
        return CreditResult.Success(result);
    }

    private bool Validate(IEnumerable<IValidation> validations, CreditCalculationInput input)
    {
        if (validations == null || !validations.Any())
        {
            return true;
        }

        foreach (var validation in validations)
        {
            if (!Validate(validation, input))
            {
                return false;
            }
        }

        return true;
    }

    private bool Validate(IValidation validation, CreditCalculationInput input)
    {
        var validationHandler = ValidationAdapter.GetValidationHandler(validation);
        if (!validationHandler.Validate(input))
        {
            return false;
        }
        return true;
    }
}
