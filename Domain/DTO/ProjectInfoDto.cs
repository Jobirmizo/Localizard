using AutoMapper.Configuration.Annotations;
using Localizard.Domain.Enums;

namespace Localizard.Domain.ViewModel;

public class ProjectInfoDto
{
    public string Name { get; set; }
    [Ignore]
    public LanguageEnum? DefaultLanguage { get; set; }
    [Ignore]
    public List<LanguageEnum>? AvailableLanguage { get; set; }
    [Ignore]
    public DateTime? CreatedAt { get; set; }
    [Ignore]
    public DateTime? UpdatedAt { get; set; }
}