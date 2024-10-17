using System.Globalization;

namespace CashControl.Api.Middlewares;

public class LanguageMiddleware
{
    private readonly RequestDelegate _next;

    public LanguageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var availableCultures = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

        var requestedLanguage = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var selectedLanguage = new CultureInfo("en");

        if (!string.IsNullOrWhiteSpace(requestedLanguage) && availableCultures.Any(lang => lang.Name.Equals(requestedLanguage)))
        {
            selectedLanguage = new CultureInfo(requestedLanguage);
        }

        CultureInfo.CurrentCulture = selectedLanguage;
        CultureInfo.CurrentUICulture = selectedLanguage;

        await _next(context);
    }
}
