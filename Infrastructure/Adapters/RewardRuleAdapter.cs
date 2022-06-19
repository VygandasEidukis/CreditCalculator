using Application.Exceptions;
using Application.RewardRules;
using Infrastructure.Calculator.RewardRuleHandlers;

namespace Infrastructure.Adapters;
internal static class RewardRuleAdapter
{
    public static IRewardRuleHandler GetRewardRuleHandler(IRewardRule rewardRule)
    {
        switch (rewardRule)
        {
            case StaticIntRewardRule:
                var rule = rewardRule as StaticIntRewardRule;
                return new StaticIntRewardRuleHandler(rule);
            default:
                throw new RewardRuleHandlerNotImplemented();
        }
    }
}
