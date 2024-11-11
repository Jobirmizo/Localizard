using AutoMapper.Configuration.Annotations;
using Localizard.Domain.Entites;
using Localizard.Domain.Enums;

namespace Localizard.Domain.ViewModel;

public class ProjectInfoDto
{
    public string Name { get; set; }
    public List<LanguageDto> DefaultLanguageId { get; set; }
    public List<LanguageDto> AvailableLanguageId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
}