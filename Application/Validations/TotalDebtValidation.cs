namespace Application.Validations;
public class TotalDebtValidation : IValidation
{
    public int? From { get; set; }
    public int? To { get; set; }
}
