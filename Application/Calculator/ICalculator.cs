namespace Application.Calculator;
public interface ICalculator<Input, Result>
{
    Result Calculate(Input input);
}
