using Application.Exceptions;
using Application.RewardRules;

namespace Infrastructure.Calculator.RewardRuleHandlers;
public class StaticIntRewardRuleHandler : IRewardRuleHandler
{
    private readonly StaticIntRewardRule _rewardRule;

    public StaticIntRewardRuleHandler(StaticIntRewardRule rewardRule)
    {
        _rewardRule = rewardRule ?? throw new NullRewardRuleException();
    }

    public int Calculate()
    {
        return _rewardRule.Reward;
    }
}
