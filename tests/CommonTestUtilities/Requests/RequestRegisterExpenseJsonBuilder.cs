using Bogus;
using CashControl.Communication.Enums;
using CashControl.Communication.Requests;

namespace CommonTestUtilities.Requests;
public class RequestRegisterExpenseJsonBuilder
{
    public static RequestRegisterExpenseJson Build()
    {
        return new Faker<RequestRegisterExpenseJson>()
            .RuleFor(req => req.Title, faker => faker.Commerce.ProductName())
            .RuleFor(req => req.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(req => req.Date, faker => faker.Date.Past())
            .RuleFor(req => req.PaymentType, faker => faker.PickRandom<PaymentType>())
            .RuleFor(req => req.Amount, faker => faker.Random.Decimal(min: 1, max: 1000));
    }
}
