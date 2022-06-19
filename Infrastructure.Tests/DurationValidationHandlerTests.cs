using Application.Calculator;
using Application.Validations;
using FluentAssertions;
using Infrastructure.Calculator.ValidationHandlers;
using NUnit.Framework;

namespace Infrastructure.Tests;
public class DurationValidationHandlerTests
{
    [Test]
    [TestCase(1, 12, 1, true)]
    [TestCase(1, 12, 0, false)]
    [TestCase(1, 12, 13, false)]
    [TestCase(1, 12, 12, true)]
    public void GivenDurationValidation_ShouldReturnExpectedValue(int? from, int? to, int months, bool expected)
    {
        var validation = new DurationValidation
        {
            From = from,
            To = to,
        };

        var handler = new DurationValidationHandler(validation);
        var input = new CreditCalculationInput { Duration = months };
        var result = handler.Validate(input);

        result.Should().Be(expected);
    }
}
