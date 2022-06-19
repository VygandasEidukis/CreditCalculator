using Application.Calculator;
using Infrastructure.Calculator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Infrastructure;
public static class DependencyInjection
{
    private const string CreditRulePath = "CreditRule.json";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationRoot configuration)
    {
        if (!File.Exists(CreditRulePath))
        {
            throw new ApplicationException($"{CreditRulePath} is missing");
        }

        var creditRuleRaw = File.ReadAllText(CreditRulePath);
        if (string.IsNullOrEmpty(creditRuleRaw))
        {
            throw new ApplicationException($"{CreditRulePath} content is missing");
        }

        JsonSerializerSettings jsonSetting = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto
        };
        var tmp = JsonConvert.DeserializeObject<CreditCalculationContext>(creditRuleRaw, jsonSetting);

        if (tmp == null)
        {
            throw new ApplicationException($"{CreditRulePath} has incorrect content");
        }

        services.AddSingleton(tmp);
        services.AddTransient<ICalculator<CreditCalculationInput, CreditResult>, CreditCalculator>();
        return services;
    }
}
