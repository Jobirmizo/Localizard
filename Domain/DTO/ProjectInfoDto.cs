using AutoMapper.Configuration.Annotations;
using Localizard.Domain.Enums;

namespace Localizard.Domain.ViewModel;

public class ProjectInfoDto
{
    public string Name { get; set; }
    public LanguageEnum DefaultLanguage { get; set; }
    public List<LanguageEnum> AvailableLanguage { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}