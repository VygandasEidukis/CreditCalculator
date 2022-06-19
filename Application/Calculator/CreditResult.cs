namespace Application.Calculator;
public class CreditResult
{
    public int Reward { get; }
    public bool Successful { get; }

    private CreditResult(int reward, bool completed)
    {
        Reward = reward;
        Successful = completed;
    }

    public static CreditResult Fail()
    {
        return new CreditResult(0, false);
    }

    public static CreditResult Success(int value)
    {
        return new CreditResult(value, true);
    }
}