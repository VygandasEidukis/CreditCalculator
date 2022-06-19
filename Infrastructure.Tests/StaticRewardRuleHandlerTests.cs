using Application.Exceptions;
using Application.RewardRules;
using FluentAssertions;
using Infrastructure.Calculator.RewardRuleHandlers;
using NUnit.Framework;

namespace Infrastructure.Tests;
public class StaticRewardRuleHandlerTests
{

    [Test]
    [TestCase(1)]
    [TestCase(10)]
    [TestCase(20)]
    public void GivenStaticReward_ShouldReturnGivenReward(int expected)
    {
        var rewardRule = new StaticIntRewardRule
        {
            Reward = expected
        };

        var handler = new StaticIntRewardRuleHandler(rewardRule);
        var result = handler.Calculate();

        result.Should().Be(expected);
    }

    [TestCase]
    public void GivenNullRewardRule_ShouldThrowNullRewardRuleException()
    {
        var act = () => new StaticIntRewardRuleHandler(null);

        act.Should().ThrowExactly<NullRewardRuleException>();
    }
}