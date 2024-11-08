using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using Localizard.Domain.Enums;

namespace Localizard.Domain.Entites;

public class ProjectInfo
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
    public LanguageEnum DefaultLanguage { get; set; }
    public List<LanguageEnum> AvailableLanguage { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int ProjectDetailId { get; set; }
    public virtual ProjectDetail ProjectDetail { get; set; }
    
}