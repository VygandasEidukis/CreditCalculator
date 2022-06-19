using Application.Calculator;
using Application.Validations;
using FluentAssertions;
using Infrastructure.Calculator.ValidationHandlers;
using NUnit.Framework;

namespace Infrastructure.Tests;
public class TotalDebtValidationHandlerTests
{
    [Test]
    [TestCase(null, 20000, 0, 20000, true)]
    [TestCase(null, 20000, 0, 20001, false)]
    [TestCase(null, 20000, 0, 20000, true)]
    [TestCase(null, 20000, 1, 19999, true)]
    [TestCase(null, 20000, 1, 20000, false)]
    [TestCase(20000, 39000, 0, 20000, true)]
    [TestCase(20000, 39000, 20000, 20000, false)]
    [TestCase(60000, null, 30000, 30000, true)]
    [TestCase(60000, null, int.MaxValue, 0, true)]
    public void GivenTotalDebtValidation_ShouldReturnExpectedValue(int? from, int? to, int alreadyOwed, int requested, bool expected)
    {
        var validation = new TotalDebtValidation()
        {
            From = from,
            To = to
        };

        var handler = new TotalDebtValidationHandler(validation);
        var input = new CreditCalculationInput { PreExistingCredit = alreadyOwed, RequestedCredit = requested };
        var result = handler.Validate(input);

        result.Should().Be(expected);
    }
}
