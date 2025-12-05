using EasySchoolMananger.Model.Base;

namespace EasySchoolMananger.Model.Entities;

public class Matter : BaseMetaData
{
    public int TeacherId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
