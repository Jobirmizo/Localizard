using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Localizard.Domain.Enums;

namespace Localizard.Domain.Entites;

public class ProjectDetail
{
    [Key]
    public int Id { get; set; }
    public int Key { get; set; }
    public string Translation { get; set; }
    public string Description { get; set; }
    public string Tag { get; set; }
    public virtual ProjectInfo ProjectInfo { get; set; }
    public PlatformEnum PlatformCategories { get; set; }
}