using Application.Calculator;
using Application.Validations;
using FluentAssertions;
using Infrastructure.Calculator.ValidationHandlers;
using NUnit.Framework;

namespace Infrastructure.Tests;
public class CreditAmountValidationHandlerTests
{
    [Test]
    [TestCase(2000, 69000, 2000, true)]
    [TestCase(2000, 69000, 69000, true)]
    [TestCase(2000, 69000, 69001, false)]
    [TestCase(2000, 69000, 1999, false)]
    [TestCase(2000, null, int.MaxValue, true)]
    [TestCase(null, 69000, int.MinValue, true)]
    public void WhenGivenCreditAmount_ShouldReturnExpectedResult(int? from, int? to, int given, bool expected)
    {
        var validation = new CreditAmountValidation()
        {
            From = from,
            To = to
        };

        var handler = new CreditAmountValidationHandler(validation);
        var input = new CreditCalculationInput { RequestedCredit = given };
        var result = handler.Validate(input);

        result.Should().Be(expected);
    }
}
