using EasySchoolMananger.Model.Base;

namespace EasySchoolMananger.Model.Entities;

public class SchoolClass : BaseMetaData
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
