using System.Diagnostics.CodeAnalysis;

namespace Application.RewardRules;

[ExcludeFromCodeCoverage]
public class StaticIntRewardRule : IRewardRule
{
    public int Reward { get; set; }
}
