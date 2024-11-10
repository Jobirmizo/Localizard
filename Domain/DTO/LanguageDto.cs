using Localizard.Domain.Enums;

namespace Localizard.Domain.ViewModel;

public class LanguageDto
{
    public LanguageEnum DefaultLanguage { get; set; }
    public List<LanguageEnum> AvailableLanguage { get; set; }
}